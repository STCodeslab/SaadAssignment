using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ekka_Shopping.Controllers
{
    [Authorize(Roles = "1")]
    public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
