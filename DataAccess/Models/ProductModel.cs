namespace DataAccess.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int SectionId { get; set; }
        public int OrganiserId { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
