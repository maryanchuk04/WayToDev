namespace WayToDev.Core.DTOs;

public class VacancyDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public UserDto User { get; set; }
    public string Description { get; set; }
    public bool IsActual { get; set; }
    public Guid CompanyId { get; set; }
    public List<TagDto> Tags { get; set; }
}