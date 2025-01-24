namespace PatientManager.ViewModels
{
    public class SearchVM
    {
        public string Filter { get; set; } = "";
        public string OrderBy { get; set; } = "";
        public IEnumerable<PatientVM> Patients { get; set; } = new List<PatientVM>();
    }
}
