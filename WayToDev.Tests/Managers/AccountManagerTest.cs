using Moq;
using WayToDev.Application.Managers;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Tests.Managers;

[TestFixture]
public class AccountManagerTest
{
    private AccountManager manager;
    private Mock<IPasswordHelper> passwordHelperMock;
    private string _userName = "userName";
    private string _email = "lion20914king@gmail.com";
    private string _password = "THISisCOOLPassWOrd!";
    private string _companyName = "CoolCompany";
        
    [SetUp]
    public void Initialize()
    {
        passwordHelperMock = new Mock<IPasswordHelper>();
        passwordHelperMock.Setup(x => x.HashPassword(_password))
            .Returns("ThisISHashingPassword");
        manager = new AccountManager(passwordHelperMock.Object);
    }

    [Test]
    public void Should_Return_NewUserAccount_DoesNotThrow()
    {
        Assert.DoesNotThrow(
            ()=> manager.CreateUserAccount(_userName,_email, _password));
    }
    
    [Test]
    public void Should_Return_NewValidUserAccount()
    {
        var account = manager.CreateUserAccount(_userName, _email, _password);
        
        Assert.Multiple(() =>
        {
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Email, Is.EqualTo(_email));
            Assert.That(account.User, Is.Not.Null);
            Assert.That(account.Company, Is.Null);
            Assert.That(account.RefreshTokens, Is.Not.Null);
            Assert.That(account.Password, Is.Not.EqualTo(_password));
        });
    }

    [Test]
    public void Should_Return_NewCompanyAccount_DoesNotThrows()
    {
        Assert.DoesNotThrow(()=> manager.CreateCompanyAccount(_companyName, _email, _password));
    }

    [Test]
    public void Should_Return_NewValidCompanyAccount()
    {
        var account = manager.CreateCompanyAccount(_companyName, _email, _password);
        
        Assert.Multiple(() =>
        {
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Email, Is.EqualTo(_email));
            Assert.That(account.User, Is.Null);
            Assert.That(account.Company, Is.Not.Null);
            Assert.That(account.RefreshTokens, Is.Not.Null);
            Assert.That(account.Password, Is.Not.EqualTo(_password));
        });
    }
}