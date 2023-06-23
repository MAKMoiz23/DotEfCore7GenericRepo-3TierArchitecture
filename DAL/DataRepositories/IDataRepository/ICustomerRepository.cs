using DAL.Models;
using DAL.Repository.IGenericRepository;

namespace DAL.DataRepositories.IDataRepository
{
	public interface ICustomerRepository : IGenericRepository<Customer>
	{
	}
}
