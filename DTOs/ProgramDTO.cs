namespace ttcm_api.DTOs
{
    public class ProgramDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }

    public class ProgramDTORequestWithCategory:ProgramDTO
    {
        public int CategoryId { get; set; }

    }
    public class ProgramDTOResponseCategory:ProgramDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public CategoryDTOResponse Category { get; set; }

    }

    public class ProgramDTOResponseBase:ProgramDTO
    {
        public int Id { get; set; }

    }
}
