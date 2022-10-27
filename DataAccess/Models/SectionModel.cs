namespace DataAccess.Models
{
    public class SectionModel
    {
        public int? SectionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HierarchyId { get; set; }
        public int VenueId { get; set; }
        public int DefaultCapacity { get; set; }
    }
}
