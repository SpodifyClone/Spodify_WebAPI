namespace Spodify.Domain.Exceptions.Musics;

public class MusicAlreadyExistsException : AlreadyExistsExcaption
{
	public MusicAlreadyExistsException()
	{
		TitleMessage = "Music already exists";
	}

}
