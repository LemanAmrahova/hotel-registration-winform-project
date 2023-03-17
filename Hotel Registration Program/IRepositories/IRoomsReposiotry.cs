using System.Data;

namespace Hotel_Registration_Program.IRepositories
{
    public interface IRoomsReposiotry
    {
        DataTable SelectAllRoomsData();
    }
}
