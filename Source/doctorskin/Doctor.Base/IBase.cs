using Doctors.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base
{
    public interface IBase
    {
        IServiceDetail serviceDetail { get; }
        IService services { get; }
        IProduct products { get; }
        ICategories categories { get; }
        IBrand brands { get; }
        IBlogType blogTypes { get; }
        IBlogDetail blogDetails { get; }
        IUser users { get; }
        IOrder orders { get; }
        IOrderDetail orderDetails { get;}
        IBooking bookings { get; }
        IDoctor doctors { get; }
        IBanner banners { get; }
        IAdmin admins { get; }
        IRole roles { get; }
        IRoleGroup roleGroups { get; }
        ICart carts { get; }
        void Commit();
    }
}
