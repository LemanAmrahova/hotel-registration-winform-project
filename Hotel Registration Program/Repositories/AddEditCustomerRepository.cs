using System.Collections.Generic;
using System.Data.SqlClient;
using Hotel_Registration_Program.Entities;
using Hotel_Registration_Program.IRepositories;

namespace Hotel_Registration_Program.Repositories
{
    public class AddEditCustomerRepository : IAddEditCustomerRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;
        public int AddCustomer(Customers customers)
        {
            sql = "insert into [customers] (name, surname, gender, pin, phone, email, address, room_category, room_number, arrival_date, departure_date)" +
                               "values (@NAME, @SURNAME, @GENDER, @PIN, @PHONE, @EMAIL, @ADDRESS, @ROOM_CATEGORY, @ROOM_NUMBER, @ARRIVAL_DATE, @DEPARTURE_DATE)";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@NAME", customers.Name),
                new SqlParameter("@SURNAME", customers.Surname),
                new SqlParameter("@GENDER", customers.Gender),
                new SqlParameter("@PIN", customers.Pin),
                new SqlParameter("@PHONE", customers.Phone),
                new SqlParameter("@EMAIL", customers.Email),
                new SqlParameter("@ADDRESS", customers.Address),
                new SqlParameter("@ROOM_CATEGORY", customers.Room_category),
                new SqlParameter("@ROOM_NUMBER", customers.Room_number),
                new SqlParameter("@ARRIVAL_DATE", customers.Arrival_date),
                new SqlParameter("@DEPARTURE_DATE", customers.Departure_date)
            };
            
            return dbHelper.ExecuteNonQuery(sql, list);
        }
        public int UpdateCustomer(Customers customers)
        {
            sql = "update [customers] set name=@NAME, surname=@SURNAME, gender=@GENDER, pin=@PIN, phone=@PHONE, email=@EMAIL, address=@ADDRESS, room_category=@ROOM_CATEGORY, room_number=@ROOM_NUMBER, arrival_date=@ARRIVAL_DATE, departure_date=@DEPARTURE_DATE where id=@ID";

            list = new List<SqlParameter>()
            {
                new SqlParameter("@NAME", customers.Name),
                new SqlParameter("@SURNAME", customers.Surname),
                new SqlParameter("@GENDER", customers.Gender),
                new SqlParameter("@PIN", customers.Pin),
                new SqlParameter("@PHONE", customers.Phone),
                new SqlParameter("@EMAIL", customers.Email),
                new SqlParameter("@ADDRESS", customers.Address),
                new SqlParameter("@ROOM_CATEGORY", customers.Room_category),
                new SqlParameter("@ROOM_NUMBER", customers.Room_number),
                new SqlParameter("@ARRIVAL_DATE", customers.Arrival_date),
                new SqlParameter("@DEPARTURE_DATE", customers.Departure_date),

                new SqlParameter("@ID", customers.Id)
            };

            return dbHelper.ExecuteNonQuery(sql, list);
        }

        public int UpdateEmpty(Rooms rooms)
        {
            sql = "update [rooms] set is_empty=0 where number=@NUMBER";

            list = new List<SqlParameter>()
            {
                new SqlParameter("@NUMBER", rooms.Number),
            
            };

            return dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
