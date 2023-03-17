using Hotel_Registration_Program.IRepositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Registration_Program.Repositories
{
    public class ReservationsRepository : IReservationsRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;

        public DataTable SelectAllReservationsData()
        {
            sql = "select * from [reservations]";
            list = new List<SqlParameter>();
            return dbHelper.ExecuteReader(sql, list);
        }

        public int DeleteReservation(int id)
        {
            sql = "delete from [reservations] where id=@ID";
            list = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            return dbHelper.ExecuteNonQuery(sql, list);
        }

        public DataTable FindCustomer(int id)
        {
            sql = "select id, name, surname, room_category, room_number, arrival_date, departure_date from [customers] where id=@ID and status=1";
            list = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            return dbHelper.ExecuteReader(sql, list);
        }

    }
}
