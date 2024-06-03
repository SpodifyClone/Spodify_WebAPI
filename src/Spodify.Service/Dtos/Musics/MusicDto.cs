using Microsoft.AspNetCore.Http;

namespace Spodify.Service.Dtos
{
    public class CreateMusicDto
    {
        public string Title { get; set; }
        public IFormFile  Artist { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }

    public class UpdateMusicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile  Artist { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }

    public class GetMusicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Artist { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}