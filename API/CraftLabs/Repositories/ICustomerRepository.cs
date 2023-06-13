using CraftLabs.Model;

namespace CraftLabs.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task AddCustomerAsync(Customer customer);

    }
}
