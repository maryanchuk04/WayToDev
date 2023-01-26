using WayToDev.Application.Services;

namespace WayToDev.Tests.Services;

[TestFixture]
public class PasswordHelperTest
{
    private PasswordHelper helper;
    private string password;
    private string incommingPasswordGood;
    private string incommingPasswordBad;
    private string hashingPassword;
    
    [SetUp]
    public void Initialize()
    {
        password = "THISisSUPER_PUPER_password123!";
        incommingPasswordBad = "THISisBADExample";
        helper = new PasswordHelper();
        incommingPasswordGood = password;
        hashingPassword = helper.HashPassword(password);
    }

    [Test]
    public void Should_Return_HashPassword()
    {
        var resPass = helper.HashPassword(password);
        Assert.That(resPass, Is.Not.Empty);
    }
    
    [Test]
    public void Should_Verify_Password()
    {
        var resPass = helper.VerifyPassword(incommingPasswordGood, hashingPassword);
        Assert.That(resPass, Is.EqualTo(true));
    }

    [Test]
    public void Should_Verify_PasswordNotValid()
    {
        var resPass = helper.VerifyPassword(incommingPasswordBad, hashingPassword);
        Assert.That(resPass, Is.EqualTo(false));
    }
}