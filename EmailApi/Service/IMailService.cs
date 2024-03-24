using EmailSender_Api.Model;

namespace EmailSender_Api.Service
{
	// This section defines our interface which
	// accepts data from the 'MailData' class. 
	// In the implementation of this interface,
	// we will execute the email sending process.

	public interface IMailService
	{
		Task<bool> SendEmailAsync(MailData mailData);
	}
}
