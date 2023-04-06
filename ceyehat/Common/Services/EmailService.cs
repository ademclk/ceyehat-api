using SendGrid;
using SendGrid.Helpers.Mail;

namespace ceyehat.Common.Services;

public class EmailService
{
    private readonly string _sendGridApiKey;

    public EmailService(string sendGridApiKey)
    {
        _sendGridApiKey = sendGridApiKey;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var client = new SendGridClient(_sendGridApiKey);
        var from = new EmailAddress("ademonurcelik@gmail.com", "Ceyehat");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        await client.SendEmailAsync(msg);
    }
}