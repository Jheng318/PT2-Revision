namespace PT2Revision.Models.ViewModels
{
    public class StudentResultsVM
    {
        public StudentResults studentResults { get; set; }
        public List<Modules> modules { get; set; }
        public List<Students> students { get; set; }
        public int SelectedModule { get; set; }
    }
}
