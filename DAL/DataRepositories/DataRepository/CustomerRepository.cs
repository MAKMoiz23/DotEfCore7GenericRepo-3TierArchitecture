using DAL.DataRepositories.IDataRepository;
using DAL.Models;
using DAL.Repository.GenericRepository;
using DAL.Data;

namespace DAL.DataRepositories.DataRepository
{
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(DataContext dbContext)
			: base(dbContext)
		{

		}

	}
}
