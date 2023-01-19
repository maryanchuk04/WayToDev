using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class CompanyService : Dao<Company>, ICompanyService
{
    private readonly ISecurityContext _securityContext;

    public CompanyService(ApplicationContext context, IMapper mapper, ISecurityContext securityContext) : base(context,
        mapper)
    {
        _securityContext = securityContext;
    }

    public CompanyDto GetCompany(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateCompany(CompanyDto company)
    {
        var currentCompany = CurrentCompany();

        currentCompany.CompanyName = company.CompanyName;
        if (currentCompany.Image == null)
            currentCompany.Image = new Image(company.ImageUrl ?? "");
        else
            currentCompany.Image.ImageUrl = company.ImageUrl ?? "";

        currentCompany.Description = company.Description;
        
        Update(currentCompany);
        await Context.SaveChangesAsync();
    }

    public CompanyDto GetCurrentCompany()
    {
        return Mapper.Map<Company, CompanyDto>(CurrentCompany());
    }


    private Company CurrentCompany()
    {
        var companyQueryable = Context.Companies
            .Where(x => x.AccountId == _securityContext.GetCurrentAccountId());

        if (!companyQueryable.Any())
            throw new CompanyExceptions("Company not found");

        return companyQueryable
            .Include(x => x.Account)
            .Include(x => x.Image)
            .Include(x=>x.Feedbacks)
            .Include(x=>x.TechStack)
                .ThenInclude(x=>x.Tag)
            .First();
    }
}
