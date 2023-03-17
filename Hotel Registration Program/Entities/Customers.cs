using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Registration_Program.Entities
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Room_category { get; set; }
        public int Room_number { get; set; }
        public DateTime Arrival_date { get; set; }
        public DateTime Departure_date { get; set; }
        public bool Status { get; set; }
    }
}
