using Microsoft.AspNetCore.Http;

namespace Spodify.Service.Interfaces.Common;

public interface IFileService
{
    public Task<string> UploadMusicAsync(IFormFile image);

    public Task<bool> DeleteMusicAsync(string subpath);
}
