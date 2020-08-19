using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Salon_Mgt_Arshdeep.Models
{
    public class Appointment_Mst
    {
        public int ID { get; set; }
        public int Staff_MstID { get; set; }
        public int Customer_MstID { get; set; }
        [ForeignKey("Staff_MstID")]
        public Staff_Mst Staff_Mst { get; set; }
        [ForeignKey("Customer_MstID")]
        public Customer_Mst Customer_Mst { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<DateTime> AppointmentDate { get; set; }
        public decimal Charges { get; set; }
    }
}
