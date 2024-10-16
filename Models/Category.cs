namespace ttcm_api.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        // Has Many, one to many relationship
        public ICollection<ttcm_api.Models.Program> Programs { get; set; }
    }
}
