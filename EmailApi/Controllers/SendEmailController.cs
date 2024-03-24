using EmailSender_Api.Model;
using EmailSender_Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender_Api.Controllers
{
	// here in our controller we simply inject our mailservice 
	// and use the method which is responsible for sending email 
	// and we are done , also HttpPost for Post Action

	[Route("/")]
	[ApiController]
	public class SendEmailController : ControllerBase
	{
		private readonly IMailService _mailService;
        public SendEmailController(IMailService mailService)
        {
            _mailService = mailService;
        }

		[HttpPost]
		[Route("SendEmail")]
		public Task<bool> SendEmailAsync(MailData mail)
		{
			return _mailService.SendEmailAsync(mail);
		}

	}
}
