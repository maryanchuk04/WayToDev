using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface ICompanyService
{
    Task<CompanyDto> GetCompanyAsync(Guid id);
    Task UpdateCompany(CompanyDto company);
    CompanyDto GetCurrentCompany();
}