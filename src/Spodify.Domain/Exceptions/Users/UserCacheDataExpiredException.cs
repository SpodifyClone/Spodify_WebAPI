namespace Spodify.Domain.Exceptions.Users;

public class MusicCacheDataExpiredException : ExpiredException
{
	public MusicCacheDataExpiredException()
	{
		TitleMessage = "User data has expired!";
	}
}
