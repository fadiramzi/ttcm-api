using System.ComponentModel.DataAnnotations.Schema;

namespace ttcm_api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public decimal Price { get; set; } // PascalCase
        public string Currency { get; set; } // "USD", "IQD"

        public int TrainerId { get; set; } // 

        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }


        public int ProgramId { get; set; }

        [ForeignKey("ProgramId")]
        public Models.Program Program { get; set; }

    }
}
