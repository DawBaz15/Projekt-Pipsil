using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Pages
{
    public class contactpageModel : PageModel
    {
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? Notification { get; set; }
        public void OnGet()
        {
			if (HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("welcome");
			}
		}
        public async void OnPostAsync()
        {
            Notification = "";
			string Name = HttpContext.Session.GetString("_Name");
			string Email = HttpContext.Session.GetString("_Email");
			Subject = Request.Form["Subject"];
			Content = Request.Form["Content"];

			var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Name, Email));
            message.To.Add(new MailboxAddress("","dawid.bazylewicz@studenci.collegiumwitelona.pl"));
            message.Subject = Subject;
            message.Body = new TextPart("plain")
            {
                Text = Content
            };
            Notification=await SendEmailAsync(message);
		}
        protected async Task<string> SendEmailAsync(MimeMessage message)
        {
			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
				client.Authenticate("dawid.bazylewicz@studenci.collegiumwitelona.pl", "xccl buaw pelt fkpb");
				client.Send(message);
				client.Disconnect(true);
			}
            return "Message sent";
		}
    }
}
