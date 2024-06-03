namespace Spodify.Service.Common.Helpers
{
    public class MediaHelper
    {
        public static string MakeMusicFileName(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            string extension = fileInfo.Extension;
            string name = "MUSIC_" + Guid.NewGuid() + extension;
            return name;
        }

        public static string[] GetMusicExtensions()
        {
            return new string[]
            {
                ".mp3",
                ".wav",
                ".flac",
                ".aac",
                ".ogg",
                ".wma"
            };
        }
    }
}
