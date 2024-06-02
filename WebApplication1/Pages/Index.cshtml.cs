using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace LangApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

		public string username = "";
		public void OnGet()
		{
			if (HttpContext.Session.GetString("_Email").IsNullOrEmpty())
			{
				Response.Redirect("welcome");
			} else
			{
				username = HttpContext.Session.GetString("_Name");
			}
		}
	}
}
