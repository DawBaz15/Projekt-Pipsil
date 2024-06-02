using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Pages
{
    public class WelcomeModel : PageModel
    {
		public void OnGet()
		{
			if (!HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("Index");
			}
		}
	}
}
