namespace EmailSender_Api.Model
{

	// This section contains the mail settings that need to be configured. 
	// These properties will utilize the 'MailSettings' section in the
	// 'appsettings.json' file for initialization. We will use these
	// settings when we need to send an email.

	public class MailSettings
	{
		public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string Password { get; set;}
		public string DisplayName { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }
	}
}
