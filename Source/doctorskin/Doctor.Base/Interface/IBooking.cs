using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IBooking: IRepository<Booking>
    {
        List<Booking> GetBookingListAllPaging(string search, int offset, int limit);
    }
}
