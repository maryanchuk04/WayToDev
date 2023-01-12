using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface ICompanyService
{
    CompanyDto GetCompany(Guid id);
    Task<CompanyDto> UpdateCompany(CompanyDto company);
    CompanyDto GetCurrentCompany();
}