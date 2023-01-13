namespace WayToDev.Core.Entities;

public class VacancyStack : BaseEntity
{
    public Vacancy Vacancy { get; set; }
    public Tag Tag { get; set; }
}