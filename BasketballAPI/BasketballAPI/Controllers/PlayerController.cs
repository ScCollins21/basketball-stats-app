using Microsoft.AspNetCore.Mvc;

namespace BasketballAPI.Controllers
{
  public class PlayerController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
