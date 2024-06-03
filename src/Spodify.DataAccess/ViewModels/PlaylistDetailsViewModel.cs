namespace Spodify.DataAccess.ViewModels
{
    public class PlaylistDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MusicViewModel> Tracks { get; set; }
    }
}
