using Moq;
using WayToDev.Application.Exceptions;
using WayToDev.Application.Services;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Enums;
using WayToDev.Core.Interfaces.Managers;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Tests.Services;

[TestFixture]
public class AuthServiceTest : TestInitializer
{
    private AuthService service;
    private Mock<ITokenService> tokenServiceMock;
    private Mock<IPasswordHelper> passwordServiceMock;
    private Mock<IAccountManager> accountManagerMock;
    private Mock<IMailService> mailSenderMock;
    private Account userAccount;
    private Account companyAccount;
    private RegistrDto registrDto;
    private Guid accId;
    private AccountToken emailToken;
    private AccountToken refreshToken;
    
    [SetUp]
    protected override void Initialize()
    {
        base.Initialize();
        tokenServiceMock = new Mock<ITokenService>();
        passwordServiceMock = new Mock<IPasswordHelper>();
        accountManagerMock = new Mock<IAccountManager>();
        mailSenderMock = new Mock<IMailService>();
        
        userAccount = new Account()
        {
            Id = accId,
            Email = "user@gmail.com",
            Password = "pass",
            RefreshTokens = new List<AccountToken>(),
            IsBlocked = false,
            User = new User
            {
                FirstName = "userFirstName",
                LastName = "userLastName",
                UserName = "user",
            }
        };
        
        companyAccount = new Account()
        {
            Id = accId,
            Email = "user@gmail.com",
            Password = "pass",
            RefreshTokens = new List<AccountToken>(),
            IsBlocked = false,
            Company= new Company()
            {
                CompanyName = "company",
                WebsiteLink = "https://company.com"
            }
        };

        registrDto = new RegistrDto
        {
            Email = "user@gmail.com",
            UserName = "user",
            Password = "pass",
            Role = Role.User
        };
        
        emailToken = new AccountToken()
        {
            Account = userAccount,
            AccountId = accId,
            Created = DateTime.Now,
            Expires = DateTime.MaxValue,
            Id = Guid.NewGuid(), Token = "ThisIsToken",
            Type = TokenType.EmailConfirmationType
        };
        
        refreshToken = new AccountToken()
        {
            Account = userAccount,
            AccountId = accId,
            Created = DateTime.Now,
            Expires = DateTime.MaxValue,
            Id = Guid.NewGuid(), Token = "ThisIsToken",
            Type = TokenType.RefreshToken
        };

        mailSenderMock.Setup(x => x.SendRegistrationMessageAsync(userAccount.Email, emailToken.Token));
        
        accountManagerMock.Setup(x => x.CreateUserAccount("user", "user@gmail.com", "pass"))
            .Returns(()=>
            {
                userAccount.Id = It.IsAny<Guid>(); 
                return userAccount;
            });

        tokenServiceMock.Setup(x => x.GenerateEmailConfirmationToken(It.IsAny<Guid>())).Returns(Task.FromResult(emailToken));
        
        tokenServiceMock.Setup(x => x.GenerateAccessToken(userAccount))
            .Returns("this is access token");
        
        tokenServiceMock.Setup(x => x.GenerateRefreshToken())
            .Returns(refreshToken);
        
        service = new AuthService(Context,
            tokenServiceMock.Object,
            passwordServiceMock.Object,
            mailSenderMock.Object,
            MockMapper.Object,
            accountManagerMock.Object);
        
        Context.Accounts.Add(userAccount);
        Context.Accounts.Add(companyAccount);
        Context.SaveChanges();
    }

    [Test]
    public async Task Should_RegisterNewAccount_Return_AccId()
    {
        var res = await service.RegistrationAsync(registrDto);
        
        Assert.That(res, Is.Not.Empty);
    }
    
    [Test]
    public void Should_Throws_RegisterNewAccount()
    {
        Assert.ThrowsAsync<AuthenticateException>(async () =>
        {
            registrDto.Role = (Role)3;
            await service.RegistrationAsync(registrDto);
        });
    }
}