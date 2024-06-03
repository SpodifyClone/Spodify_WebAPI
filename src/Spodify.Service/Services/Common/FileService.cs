using Microsoft.AspNetCore.Hosting;
using Spodify.Service.Common.Helpers;
using Spodify.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;

namespace Spodify.Service.Services.Common;

public class FileService : IFileService
{
    private const string MEDIA = "Media";
    private const string MUSIC = "Music";
    
    private readonly string ROOTPATH;
    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    

    public async Task<bool> DeleteMusicAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }
    
    public  async Task<string> UploadMusicAsync(IFormFile musicFile)
    {
        string newMusicFileName = MediaHelper.MakeMusicFileName(musicFile.FileName);
        string subpath = Path.Combine(MEDIA, MUSIC, newMusicFileName);
        string path = Path.Combine(ROOTPATH, subpath);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await musicFile.CopyToAsync(stream);
        }

        return subpath;
    }

}
