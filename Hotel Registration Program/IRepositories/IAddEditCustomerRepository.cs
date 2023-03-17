using Hotel_Registration_Program.Entities;

namespace Hotel_Registration_Program.IRepositories
{
    public interface IAddEditCustomerRepository
    {
        int AddCustomer(Customers customers);
        int UpdateCustomer(Customers customers);
    }
}
