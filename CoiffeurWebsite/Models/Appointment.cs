namespace CoiffeurWebsite.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public int CustomerID { get; set; }
        public Customer customer { get; set; }
        public int EmployeeID { get; set; }
        public Employee employee { get; set; }
    }
}
