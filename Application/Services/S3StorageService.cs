using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class S3StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName = "image-petspamanagement";

        public S3StorageService()
        {
            _s3Client = new AmazonS3Client();
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = file.FileName,
                FilePath = filePath,
                ContentType = file.ContentType
            };

            await _s3Client.PutObjectAsync(putRequest);
            return $"https://{_bucketName}.s3.amazonaws.com/{file.FileName}";
        }

        public async Task DeleteAsync(string imageUrl)
        {
            // Parse image key from URL
            Uri uri;
            if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out uri))
            {
                throw new ArgumentException("Invalid image URL");
            }

            var imageKey = Path.GetFileName(uri.LocalPath);

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = imageKey
            };

            await _s3Client.DeleteObjectAsync(deleteRequest);
        }
    }
}
