namespace CoiffeurWebsite.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string TreatmentName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
