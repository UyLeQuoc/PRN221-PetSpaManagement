using Application;
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
        private readonly PetSpaManagementDbContext _context;
        //private readonly ICurrentTime _timeService;
        //private readonly IClaimsService _claimsService;

        public GenericRepository(PetSpaManagementDbContext context/*, ICurrentTime timeService, IClaimsService claimsService*/)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
            //_timeService = timeService;
            //_claimsService = claimsService;
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
            // todo should throw exception when not found
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            //entity.CreationDate = _timeService.GetCurrentTime();
            //entity.CreatedBy = _claimsService.GetCurrentUserId;
            entity.IsDeleted = false;
            await _dbSet.AddAsync(entity);
        }

        public void SoftRemove(TEntity entity)
        {
            entity.IsDeleted = true;
            //entity.DeleteBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public void Update(TEntity entity)
        {
            //entity.ModificationDate = _timeService.GetCurrentTime();
            //entity.ModificationBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                //entity.CreationDate = _timeService.GetCurrentTime();
                //entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public void SoftRemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                //entity.DeletionDate = _timeService.GetCurrentTime();
                //entity.DeleteBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                //entity.CreationDate = _timeService.GetCurrentTime();
                //entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
