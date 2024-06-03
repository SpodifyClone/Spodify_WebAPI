namespace Spodify.Domain.Entities
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
