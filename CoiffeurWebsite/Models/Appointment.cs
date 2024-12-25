using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoiffeurWebsite.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";

        // UserDetails ile ilişki
        [Required]
        public string userId { get; set; }

        [ForeignKey("userId")]
        public UserDetails User { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

        public int TreatmentID { get; set; }

        [ForeignKey("TreatmentID")]
        public Treatment Treatment { get; set; }
    }

}