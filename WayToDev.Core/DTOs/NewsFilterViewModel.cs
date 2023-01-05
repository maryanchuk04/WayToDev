using WayToDev.Core.Enums;

namespace WayToDev.Core.DTOs;

public class NewsFilterViewModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public string? SearchWord { get; set; }
    public SortBy SortBy { get; set; }
}