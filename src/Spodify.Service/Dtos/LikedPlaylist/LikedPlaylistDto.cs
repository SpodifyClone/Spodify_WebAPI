namespace Spodify.Service.Dtos
{
    public class LikedPlaylistDto
    {
        public int UserId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}