using System.ComponentModel.DataAnnotations.Schema;
using ttcm_api.Models;

namespace ttcm_api.DTOs
{
    public class CourseDTO
    {
        public int ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; } // PascalCase
        public string Currency { get; set; } // "USD", "IQD"

    }

    public class CourseDTOResponse : CourseDTO
    {
        public int Id { get; set; }
        public ProgramDTOResponseBase Program { get; set; }

      
    }
}
