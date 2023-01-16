namespace WayToDev.Core.DTOs;

public class VacancyCreateDto
{
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public List<Guid> TagsIds { get; set; }
    public string Description { get; set; }
}