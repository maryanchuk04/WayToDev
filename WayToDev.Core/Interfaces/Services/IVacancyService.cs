using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface IVacancyService
{
    Task<VacancyDto> CreateVacancy(VacancyCreateDto vacancyDto);
    Task Deactivate(Guid vacancyId);
    Task Update(VacancyDto vacancyDto);
    List<VacancyDto> GetAllVacancies();
    VacancyDto GetById(Guid id);
}