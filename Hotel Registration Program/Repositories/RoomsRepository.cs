using Hotel_Registration_Program.IRepositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Registration_Program.Repositories
{
    public class RoomsRepository : IRoomsReposiotry
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;
        public DataTable SelectAllRoomsData()
        {
            sql = "select * from [rooms]";
            list = new List<SqlParameter>();
            return dbHelper.ExecuteReader(sql, list);
        }
        public DataTable SelectEmpty()
        {
            sql = "select * from [rooms] where is_empty=1";
            list = new List<SqlParameter>();
            return dbHelper.ExecuteReader(sql, list);
        }
    }
}
