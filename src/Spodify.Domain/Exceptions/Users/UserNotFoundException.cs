namespace Spodify.Domain.Exceptions.Users;

public class MusicNotFoundException : NotFoundException
{
	public MusicNotFoundException()
	{
		this.TitleMessage = "User not found";
	}
}
