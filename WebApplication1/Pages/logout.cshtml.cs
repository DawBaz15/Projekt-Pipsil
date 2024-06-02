using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class logoutModel : PageModel
    {
		public void OnGet()
		{
			HttpContext.Session.Remove("_Email");
			HttpContext.Session.Remove("_Name");
			Response.Redirect("Index");
		}
	}
}
