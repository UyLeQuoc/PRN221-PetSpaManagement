using Domain.Entities;
using System.Linq.Expressions;

namespace RepositoryLayer.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : BaseEntity
	{
		Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
		Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes);
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void UpdateRange(List<TEntity> entities);
		void SoftRemove(TEntity entity);
		Task AddRangeAsync(List<TEntity> entities);
		void SoftRemoveRange(List<TEntity> entities);
		Task<int> SaveChangesAsync();
	}
}
