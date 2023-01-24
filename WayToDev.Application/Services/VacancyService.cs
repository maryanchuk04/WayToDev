using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class VacancyService : Dao<Vacancy>, IVacancyService
{
    public VacancyService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }

    public async Task<VacancyDto> CreateVacancy(VacancyCreateDto vacancyDto)
    {
        var newVacancy = new Vacancy
        {
            Description = vacancyDto.Description,
            Title = vacancyDto.Title,
            Date = DateTime.Now,
            User = Context.Users.FirstOrDefault(x => x.Id == vacancyDto.UserId)
                   ?? throw new VacancyException("User with this id not found"),
            Company = Context.Companies.FirstOrDefault(x => x.Id == vacancyDto.CompanyId)
                      ?? throw new VacancyException("Company with this id not found"),
            VacancyStack = GetVacancyStacks(vacancyDto.TagsIds)
        };

        var vacancy = Insert(newVacancy);
        
        await Context.SaveChangesAsync();

        return Mapper.Map<Vacancy, VacancyDto>(vacancy);
    }

    public async Task Deactivate(Guid vacancyId)
    {
        var vacancy = Context.Vacancies.FirstOrDefault(x => x.Id == vacancyId);
        if (vacancy == null)
            throw new VacancyException("Vacancy not found");
        
        vacancy.IsActual = false;
        Update(vacancy);
        await Context.SaveChangesAsync();
    }

    public Task Update(VacancyDto vacancyDto)
    {
        throw new NotImplementedException();
    }

    public List<VacancyDto> GetAllVacancies()
    {
        var vacancies = Context.Vacancies.Where(x => x.IsActual == true);
        return vacancies.Any() 
            ? Mapper.Map<List<Vacancy>, List<VacancyDto>>(vacancies
                .OrderByDescending(x=>x.Date.Date)
                    .ThenByDescending(x=>x.Date.TimeOfDay)
                .ToList()) 
            : new List<VacancyDto>();
    }

    public VacancyDto GetById(Guid id)
    {
        var vacancy = Context.Vacancies.FirstOrDefault(x => x.Id == id);
        if (vacancy == null)
            throw new VacancyException("Vacancy not found");
        return Mapper.Map<Vacancy, VacancyDto>(vacancy);
    }

    private List<VacancyStack> GetVacancyStacks(List<Guid> tagsIds)
    {
        var vacancyStack = new List<VacancyStack>();
        if (tagsIds.Any())
            return vacancyStack;
        
        var list = tagsIds.Select(tagId => Context.Tags.FirstOrDefault(x => x.Id == tagId) 
                                           ?? throw new VacancyException("Tag not found")).ToList();
        
        vacancyStack.AddRange(list.Select(tag => new VacancyStack { Tag = tag }));

        return vacancyStack;
    }
}