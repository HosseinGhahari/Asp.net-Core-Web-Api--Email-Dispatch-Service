namespace EmailSender_Api.Model
{

	// In this section, I define the properties
	// that are required to be submitted by my
	// client through a contact form

	public class MailData
	{
        public string Name { get; set; }
        public string Email { get; set; }
		public string Body { get; set; }
	}
}
