using Microsoft.AspNetCore.Mvc;

namespace SubscriptionBasedFlowInMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            ViewData["Title"]= "Home Page";
            var context = _httpContextAccessor.HttpContext;
            var cookieValue = context.Request.Cookies["SubscriptionType"];
            return View();
        }
    }
}
