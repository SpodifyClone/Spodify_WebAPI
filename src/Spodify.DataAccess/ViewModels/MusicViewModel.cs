namespace Spodify.DataAccess.ViewModels
{
    public class MusicViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
