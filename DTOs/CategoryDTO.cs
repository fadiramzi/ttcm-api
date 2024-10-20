namespace ttcm_api.DTOs
{
    public class CategoryDTO
    {
            public string Name { get; set; }
        
    }
    public class CategoryDTOResponse:CategoryDTO
    {
        public int Id { get; set; }
    }
}
