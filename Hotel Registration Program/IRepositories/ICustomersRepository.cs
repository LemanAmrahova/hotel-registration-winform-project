using System.Data;

namespace Hotel_Registration_Program.IRepositories
{
    public interface ICustomersRepository
    {
        DataTable SelectAllCustomersData();
        int DeleteCustomer(int id);
    }
}
