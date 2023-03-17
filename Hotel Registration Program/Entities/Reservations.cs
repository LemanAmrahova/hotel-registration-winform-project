using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Registration_Program.Entities
{
    public class Reservations
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public string Fullname { get; set; }
        public string Room_category { get; set; }
        public int Room_number { get; set; }
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
        public int Number_days { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public double Bill { get; set; }

    }
}
