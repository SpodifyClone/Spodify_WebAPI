using Spodify.Service.Interfaces.Common;

namespace Spodify.Service.Services.Common;

public class ShortStorageService : IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
	public ShortStorageService()
	{
		KeyValuePairs = new Dictionary<string, string>();
	}
}
