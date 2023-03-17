using System.Collections.Generic;
using System.Data.SqlClient;
using Hotel_Registration_Program.Entities;
using Hotel_Registration_Program.IRepositories;

namespace Hotel_Registration_Program.Repositories
{
    public class AddEditReservationRepository : IAddEditReservationRepository
    {
        string sql;
        DbHelper dbHelper = new DbHelper();
        List<SqlParameter> list;
        public int AddReservation(Reservations reservations)
        {
            sql = "insert into [reservations] (customer_id, fullname, room_category, room_number, checkin_date, checkout_date, number_days, price, discount, bill)" 
                +"values (@CUSTOMER_ID, @FULLNAME, @ROOM_CATEGORY, @ROOM_NUMBER, @CHECKIN_DATE, @CHECKOUT_DATE, @NUMBER_DAYS, @PRICE, @DISCOUNT, @BILL)";

            list = new List<SqlParameter>()
            {
                new SqlParameter("@CUSTOMER_ID", reservations.Customer_id),
                new SqlParameter("@FULLNAME", reservations.Fullname),
                new SqlParameter("@ROOM_CATEGORY", reservations.Room_category),
                new SqlParameter("@ROOM_NUMBER", reservations.Room_number),
                new SqlParameter("@CHECKIN_DATE", reservations.Checkin_date),
                new SqlParameter("@CHECKOUT_DATE", reservations.Checkout_date),
                new SqlParameter("@NUMBER_DAYS", reservations.Number_days),
                new SqlParameter("@PRICE", reservations.Price),
                new SqlParameter("@DISCOUNT", reservations.Discount),
                new SqlParameter("@BILL", reservations.Bill)
            };

            return dbHelper.ExecuteNonQuery(sql, list);
        }
        public int UpdateReservation(Reservations reservations)
        {
            sql = "update [reservations] set customer_id=@CUSTOMER_ID, fullname=@FULLNAME, room_category=@ROOM_CATEGORY, room_number=@ROOM_NUMBER, checkin_date=@CHECKIN_DATE, checkout_date=@CHECKOUT_DATE, number_days=@NUMBER_DAYS, price=@PRICE, discount=@DISCOUNT, bill=@BILL where id=@ID";
            list = new List<SqlParameter>()
            {
                new SqlParameter("@CUSTOMER_ID", reservations.Customer_id),
                new SqlParameter("@FULLNAME", reservations.Fullname),
                new SqlParameter("@ROOM_CATEGORY", reservations.Room_category),
                new SqlParameter("@ROOM_NUMBER", reservations.Room_number),
                new SqlParameter("@CHECKIN_DATE", reservations.Checkin_date),
                new SqlParameter("@CHECHOUT_DATE", reservations.Checkout_date),
                new SqlParameter("@NUMBER_DAYS", reservations.Number_days),
                new SqlParameter("@PRICE", reservations.Price),
                new SqlParameter("@DISCOUNT", reservations.Discount),
                new SqlParameter("@BILL", reservations.Bill),

                new SqlParameter("@ID",reservations.Id)
            };
            return dbHelper.ExecuteNonQuery(sql, list);
        }
    }
}
