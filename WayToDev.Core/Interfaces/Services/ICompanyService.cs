using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface ICompanyService
{
    CompanyDto GetCompany(Guid id);
    Task UpdateCompany(CompanyDto company);
    CompanyDto GetCurrentCompany();
}