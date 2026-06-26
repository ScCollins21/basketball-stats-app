using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
