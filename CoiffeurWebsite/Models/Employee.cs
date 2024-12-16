namespace CoiffeurWebsite.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int TreatmentID { get; set; }
        public Treatment treatment { get; set; }
        public int SalonID { get; set; }
        public Salon Salon { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }

}
