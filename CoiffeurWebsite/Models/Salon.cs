namespace CoiffeurWebsite.Models
{
    public class Salon
    {
        public int SalonID { get; set; }
        public string SalonName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
