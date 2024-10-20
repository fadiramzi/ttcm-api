namespace ttcm_api.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TraineeId { get; set; }
        public DateTime EnrollmentDate { get; set; }
       
    }
}
