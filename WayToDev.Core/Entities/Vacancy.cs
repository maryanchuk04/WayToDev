namespace WayToDev.Core.Entities;

public class Vacancy : BaseEntity
{
    public string Title { get; set; }
    //creater
    public User User { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public ICollection<VacancyStack> VacancyStack { get; set; }
    public bool IsActual { get; set; } = true;
    public Company Company { get; set; }
}