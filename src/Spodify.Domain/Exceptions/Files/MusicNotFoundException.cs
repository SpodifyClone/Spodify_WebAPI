namespace Spodify.Domain.Exceptions.Files;

public class MusicNotFoundException : NotFoundException
{
    MusicNotFoundException()
    {
        TitleMessage = "Music not Found";
    }
}
