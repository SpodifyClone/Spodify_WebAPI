﻿namespace Spodify.Service.Dtos;

public class EmailMessage
{
    public string Recipent { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
