﻿namespace Spodify.Service.Interfaces.Common;

public interface IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
}
