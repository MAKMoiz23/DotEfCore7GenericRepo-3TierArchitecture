using DAL.Data;
using DAL.Repository.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
	where TEntity : BaseEntity
	{
		private readonly DataContext _dbContext;

		public GenericRepository(DataContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IQueryable<TEntity>> GetAll()
		{
			return await Task.FromResult(_dbContext.Set<TEntity>().AsQueryable());
		}

		public async Task<TEntity?> GetById(int id)
		{
			return await _dbContext.Set<TEntity>()
						.AsNoTracking()
						.FirstOrDefaultAsync(e => e.ID == id);
		}

		public async Task Create(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Update(TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);
			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
