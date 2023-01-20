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

    public async Task<CompanyDto> GetCompanyAsync(Guid id)
    {
        var company = await Context.Companies
            .Include(x => x.Account)
            .Include(x=>x.BannerImage)
            .Include(x=>x.Image)
            .Include(x => x.Feedbacks)
            .Include(x => x.TechStack)
                .ThenInclude(x => x.Tag)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (company == null)
            throw new UserNotFoundException("User not found");

        return Mapper.Map<Company, CompanyDto>(company);
    } 

    public async Task UpdateCompany(CompanyDto company)
    {
        var currentCompany = CurrentCompany();

        currentCompany.CompanyName = company.CompanyName;
        if (currentCompany.Image == null)
            currentCompany.Image = new Image(company.ImageUrl ?? "");
        else
            currentCompany.Image.ImageUrl = company.ImageUrl ?? "";
        
        if (currentCompany.BannerImage == null)
            currentCompany.BannerImage = new Image(company.BannerImage ?? "");
        else
            currentCompany.BannerImage.ImageUrl = company.BannerImage ?? "";

        currentCompany.Description = company.Description;
        currentCompany.WebsiteLink = company.WebsiteLink;
        currentCompany.CountOfWorkers = company.CountOfWorkers;
        
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
            .Include(x=>x.BannerImage)
            .Include(x=>x.Feedbacks)
            .Include(x=>x.TechStack)
                .ThenInclude(x=>x.Tag)
            .First();
    }
}
