using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Registration_Program
{
    public class DbHelper
    {
        const string ConnectionString = "Data Source=DESKTOP-1BUMBP5;Initial Catalog=HotelDb;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand;

        public int ExecuteNonQuery(string sql, List<SqlParameter> list)
        {
            int result = 0;
            try
            {
                sqlConnection.ConnectionString = ConnectionString;
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sql, sqlConnection);

                foreach (var item in list)
                    sqlCommand.Parameters.AddWithValue(item.ParameterName, item.Value);

                result = sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                sqlConnection.Close();
            }catch(Exception r) 
            {
               
            }
            

            return result;
        }

        public int ExecuteScalar(string sql, List<SqlParameter> list)
        {
            sqlConnection.ConnectionString = ConnectionString;
            sqlConnection.Open();
            sqlCommand = new SqlCommand(sql, sqlConnection);

            foreach (var item in list)
                sqlCommand.Parameters.AddWithValue(item.ParameterName, item.Value);

            int result = Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlCommand.Dispose();
            sqlConnection.Close();

            return result;
        }

        public DataTable ExecuteReader(string sql, List<SqlParameter> list)
        {
            DataTable dataTable = new DataTable();
            sqlConnection.ConnectionString = ConnectionString;
            sqlConnection.Open();
            sqlCommand = new SqlCommand(sql, sqlConnection);

            foreach (var item in list)
                sqlCommand.Parameters.AddWithValue(item.ParameterName, item.Value);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            sqlCommand.Dispose();
            sqlDataReader.Close();
            sqlConnection.Close();

            return dataTable;
        }
    }
}
