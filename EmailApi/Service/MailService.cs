using EmailSender_Api.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;


namespace EmailSender_Api.Service
{

	// In this crucial section, we inherit from our interface
	// and utilize Dependency Injection for cleaner code. 
	// To send an email, we require the data from 'MailSettings',
	// which we inject here for use in the email sending process. 
	// We then create our email configuration for sending. 
	// Following this, we configure SMTP, a protocol used for
	// sending emails. In this instance, we use Google's SMTP. 
	// Finally, we send the email.


	public class MailService : IMailService
	{
		private readonly MailSettings _mailsettings;
        public MailService(IOptions<MailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }
        public async Task<bool> SendEmailAsync(MailData mailData)
		{
			try
			{
				using (MimeMessage email = new MimeMessage())
				{
					// Create Email Message 
					MailboxAddress emailFrom = new MailboxAddress(mailData.Email, _mailsettings.SenderMail);
					email.From.Add(emailFrom);
					MailboxAddress emailTo = new MailboxAddress(mailData.Name , _mailsettings.ReceiverMail);
					email.To.Add(emailTo);

					email.Subject = mailData.Name;

					BodyBuilder builder = new BodyBuilder();
					builder.TextBody = mailData.Body;

					email.Body = builder.ToMessageBody();

					// Configuration of Smtp protocol and Sending Mail
					using (SmtpClient client = new SmtpClient())
					{
						await client.ConnectAsync(_mailsettings.Host, _mailsettings.Port,SecureSocketOptions.StartTls);
						await client.AuthenticateAsync(_mailsettings.SenderMail, _mailsettings.Password);
						await client.SendAsync(email);
						await client.DisconnectAsync(true);
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}

