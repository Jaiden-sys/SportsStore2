using Microsoft.AspNetCore.Mvc;
using SportsStore2.Models;

namespace SportsStore2.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());
    }
}
