using Doctors.Base.Models;

namespace Doctorskin.Models
{
    public class ServiceModel
    {
        public Service Service { get; set; }
        public List<ServicesDetail> ListServiceDetail { get; set; }
    }
}
