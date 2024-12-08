namespace CoiffeurWebsite.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string TreatmentName { get; set; }
        public int EmployeeID { get; set; }
        public Employee employee { get; set; }
    }
}
