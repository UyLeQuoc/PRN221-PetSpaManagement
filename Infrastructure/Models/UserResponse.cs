using Domain.Entities;

namespace RepositoryLayer.Models
{
    public class UserResponse
    {
        public List<User> Users { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
    }
}
