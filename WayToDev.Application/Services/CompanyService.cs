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

    public Task<CompanyDto> UpdateCompany(CompanyDto company)
    {
        throw new NotImplementedException();
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
            .First();
    }
}
