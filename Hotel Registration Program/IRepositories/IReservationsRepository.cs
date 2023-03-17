using System.Data;

namespace Hotel_Registration_Program.IRepositories
{
    public interface IReservationsRepository
    {
        DataTable SelectAllReservationsData();
        int DeleteReservation(int id);
        DataTable FindCustomer(int id);
    }
}
