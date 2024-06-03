namespace Spodify.Domain.Exceptions.Musics;

public class MusicNotFoundException : NotFoundException
{
	public MusicNotFoundException()
	{
		this.TitleMessage = "User not found";
	}
}
