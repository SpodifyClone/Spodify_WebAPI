namespace Spodify.Service.Dtos
{
    public class LikedMusicDto
    {
        public int UserId { get; set; }
        public int MusicId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}