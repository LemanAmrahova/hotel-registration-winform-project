using Hotel_Registration_Program.IRepositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Registration_Program.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;

        public DataTable SelectAllCustomersData()
        {
            sql = "select * from [customers] where status=1";
            list = new List<SqlParameter>();
            return dbHelper.ExecuteReader(sql, list);
        }

        public int DeleteCustomer(int id)
        {
            sql = "delete from [customers] where id=@ID";
            list = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            return dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
