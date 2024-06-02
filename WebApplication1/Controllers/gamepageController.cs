using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class gamepageController : Controller
	{
		[Route("game2")]
		public IActionResult Index()
		{
			return RedirectToAction("");
		}
	}
}
