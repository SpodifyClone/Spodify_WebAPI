namespace Spodify.Service.Dtos
{
    public class CreatePlaylistDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdatePlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GetPlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}