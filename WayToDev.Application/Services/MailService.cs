using System.Net.Mail;
using WayToDev.Core.Interfaces.Infrastructure;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Services;

public class MailService : IMailService
{
    private const string DefaultEmail = "waytodev@gmail.com";
    private const string DefaultName = "WayToDevAcc";
    
    private readonly IMailClient _mailClient;

    public MailService(IMailClient mailClient)
    {
        _mailClient = mailClient;
    }

    public async Task SendRegistrationMessageAsync(string email, string? url)
    {
        const string subject = "Welcome to WayToDev";
        var htmlContentWelcomeContent = $"<h1>Welcome to WayToDev!!!</h1><br/><br/>Confirm your mail <a href='{url}'>link</a>";
        await _mailClient.SendHtmlMessageAsync(subject, htmlContentWelcomeContent, DefaultEmail, email, DefaultName);
    }
    
}