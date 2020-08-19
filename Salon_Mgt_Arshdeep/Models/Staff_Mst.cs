using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon_Mgt_Arshdeep.Models
{
    public class Staff_Mst
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public List<Appointment_Mst> Appointment_Msts { get; set; }
    }
}
