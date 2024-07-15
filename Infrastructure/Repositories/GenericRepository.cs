using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Commons;
using RepositoryLayer.Interfaces;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories
{
    //public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> _dbSet;
        private readonly PetSpaManagementDbContext _context;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public GenericRepository(PetSpaManagementDbContext context, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            var result = await query.FirstOrDefaultAsync(x => x.Id == id);
            // todo should throw exception when not found
            return result;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                entity.CreatedAt = _timeService.GetCurrentTime();
                //var user = await _dbContext.Users.FindAsync(_claimsService.GetCurrentUserId);
                //if (user == null) throw new Exception("This user is no longer existed");
                entity.CreatedBy = _claimsService.GetCurrentUserId == -1 ? 1 : _claimsService.GetCurrentUserId;
                var result = await _dbSet.AddAsync(entity);
                //await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SoftRemove(TEntity entity)
        {
            entity.IsDeleted = true;
            //entity.DeleteBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
        }

        public async Task SoftRemove(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Non-existed pet id");
            }
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