namespace CoiffeurWebsite.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
