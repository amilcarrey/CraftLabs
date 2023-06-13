using CraftLabs.Model;

namespace CraftLabs.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task AddCustomerAsync(Customer customer);
    }
}
