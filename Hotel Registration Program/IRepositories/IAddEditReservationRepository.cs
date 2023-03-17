using Hotel_Registration_Program.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Registration_Program.IRepositories
{
    public interface IAddEditReservationRepository
    {
        int AddReservation(Reservations reservations);
        int UpdateReservation(Reservations reservations);

    }
}
