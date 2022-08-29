namespace DataAccess.Models
{
    public class OrganiserModel
    {
        public int OrganiserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }
}
