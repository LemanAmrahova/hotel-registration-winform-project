using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Registration_Program.Entities
{
    public class Rooms
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public bool Is_vip { get; set; }
        public bool Is_empty { get; set; }
    }
}
