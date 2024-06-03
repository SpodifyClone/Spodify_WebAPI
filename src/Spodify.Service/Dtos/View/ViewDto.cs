namespace Spodify.Service.Dtos
{
    public class ViewDto
    {
        public int UserId { get; set; }
        public int MusicId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}