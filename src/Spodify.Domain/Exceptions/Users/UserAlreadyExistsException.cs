namespace Spodify.Domain.Exceptions.Users;

public class MusicAlreadyExistsException : AlreadyExistsExcaption
{
	public MusicAlreadyExistsException()
	{
		TitleMessage = "User already exists";
	}

	public MusicAlreadyExistsException(string phone)
	{
		TitleMessage = "This phone is already registered";
	}
}
