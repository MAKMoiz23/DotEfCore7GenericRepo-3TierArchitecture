using DAL.Models;

namespace BAL.Services.IService
{
    public interface ICustomerService
    {
        Task Create(Customer entity);
        Task Delete(int id);
        Task<IQueryable<Customer>> GetAll();
        Task<Customer?> GetById(int id);
        Task Update(Customer entity);
    }
}