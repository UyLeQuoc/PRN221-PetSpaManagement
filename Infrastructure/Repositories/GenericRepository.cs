﻿using Application;
using Application.Interfaces.Commons;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    //public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> _dbSet;
        private readonly PetSpaManagementDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public GenericRepository(PetSpaManagementDbContext context, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbSet = context.Set<TEntity>();
            _dbContext = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedAt = _timeService.GetCurrentTime();
            entity.CreatedBy = _claimsService.GetCurrentUserId;
            var result = await _dbSet.AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        // riêng hàm này đã sửa để adapt theo Unit Of Work
        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedAt = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var result = await query.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemove(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = _timeService.GetCurrentTime();
            entity.DeletedBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
            // await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftRemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedAt = _timeService.GetCurrentTime();
                entity.DeletedBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
            //  await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftRemoveRangeById(List<int> entitiesId) // update hàng loạt cùng 1 trường thì làm y chang
        {
            var entities = await _dbSet.Where(e => entitiesId.Contains(e.Id)).ToListAsync();

            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedAt = _timeService.GetCurrentTime();
                entity.DeletedBy = _claimsService.GetCurrentUserId;
            }

            _dbContext.UpdateRange(entities);
            return true;
        }

        public async Task<bool> Update(TEntity entity)
        {
            entity.ModifiedAt = _timeService.GetCurrentTime();
            entity.ModifiedBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
            //   await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ModifiedAt = _timeService.GetCurrentTime();
                entity.ModifiedBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
            //  await _dbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet;
        }
    }
}