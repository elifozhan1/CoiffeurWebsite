namespace CoiffeurWebsite.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public string userId { get; set; } 
        public UserDetails User { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}