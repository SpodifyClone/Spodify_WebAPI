namespace Spodify.Domain.Exceptions.Musics;

public class MusicCacheDataExpiredException : ExpiredException
{
	public MusicCacheDataExpiredException()
	{
		TitleMessage = "Music data has expired!";
	}
}
