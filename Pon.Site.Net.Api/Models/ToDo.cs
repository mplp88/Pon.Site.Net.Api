namespace Pon.Site.Net.Api.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
    }
}
