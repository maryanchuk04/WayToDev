using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using WayToDev.Application.Services;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Tests.Services;

[TestFixture]
public class TokenServiceTest : TestInitializer
{
    private TokenService service;
    private Mock<IHttpContextAccessor> _httpContextAccessor;
    private Mock<IPinGenerator> _pinGenerator;
    private string token;

    [SetUp]
    protected override void Initialize()
    {
        base.Initialize();
        //must refactor this service because i`m using IConfiguration
    }
}