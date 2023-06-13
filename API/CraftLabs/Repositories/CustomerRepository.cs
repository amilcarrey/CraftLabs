using CraftLabs.Model;

namespace CraftLabs.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        List<Customer> customers = new List<Customer>(){
            new Customer () {
                Id = 1,
                Name  = "Juan",
                LastName = "Perez"
            },
            new Customer () {
                Id = 2,
                Name  = "Carlos",
                LastName = "Perez"
            },
            new Customer () {
                Id = 3,
                Name  = "Maria",
                LastName = "Perez"
            },
            new Customer () {
                Id = 4,
                Name  = "Laura",
                LastName = "Perez"
            }
        };

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(customers);
        }

        public Task AddCustomerAsync(Customer customer)
        {
            customers.Add(customer);
            return Task.CompletedTask;

        }
    }
}
