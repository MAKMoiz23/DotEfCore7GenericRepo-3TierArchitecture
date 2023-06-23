using DAL.Data;
using DAL.Models;

namespace DAL.Repository.IGenericRepository
{
    public interface IGenericRepository<TEntity>
     where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> GetAll();

        Task<TEntity?> GetById(int id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
	}
}