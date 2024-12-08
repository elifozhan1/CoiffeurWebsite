namespace CoiffeurWebsite.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ExpertiseArea { get; set; }
        public string AvailabilityHours { get; set; }
        public int SalonID { get; set; }
        public Salon Salon { get; set; }
    }

}
