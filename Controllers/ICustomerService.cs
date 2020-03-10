namespace customer_service.Controllers
{
    public interface ICustomerService
    {
        Customers GetAllCustomers();
        Customer GetCustomer(string email);
    }
}