using WayToDev.Core.Configuration;
using WayToDev.Core.Interfaces.Infrastructure;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Application.Services;

public class MailService : IMailService
{
    private const string FromEmail = "waytodev@gmail.com";
    private const string FromName = "WayToDevAcc";
    private readonly IMailClient _mailClient;
    private readonly EmailTemplatePathModel _model;

    public MailService(IMailClient mailClient, EmailTemplatePathModel model, IPinGenerator generator)
    {
        _mailClient = mailClient;
        _model = model;
    }

    public async Task SendRegistrationMessageAsync(string email, string token)
    {
        const string subject = "Welcome to WayToDev";
        using var streamReader = File.OpenText($"{_model.RootPath}/welcome-template.html");
        var pin = token.Select(x=>x.ToString()).ToArray();
        var htmlContent = string.Format(await streamReader.ReadToEndAsync(), pin[0], pin[1], pin[2], pin[3]);
        await _mailClient.SendHtmlMessageAsync(
            subject, 
            htmlContent, 
            FromEmail, 
            email, 
            FromName);
    }
}