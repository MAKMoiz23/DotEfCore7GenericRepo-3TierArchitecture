using BAL.Services.IService;
using DAL.DataRepositories.IDataRepository;
using DAL.Models;

namespace BAL.Services.Service
{
    public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _repository;

		public CustomerService(ICustomerRepository repository)
		{
			_repository = repository;
		}

		public async Task<IQueryable<Customer>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<Customer?> GetById(int id)
		{
			return await _repository.GetById(id);
		}

		public async Task Create(Customer entity)
		{
			await _repository.Create(entity);
		}

		public async Task Update(Customer entity)
		{
			await _repository.Update(entity);
		}

		public async Task Delete(int id)
		{
			await _repository.Delete(id);
		}
	}
}
