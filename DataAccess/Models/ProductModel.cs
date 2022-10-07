namespace DataAccess.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int VenueId { get; set; }
        public int Capacity { get; set; }
        public int OrganiserId { get; set; }
        public int HierarchyId { get; set; }
        public decimal Price { get; set; }
    }
}
