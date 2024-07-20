using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriptionBasedFlowInMVCCore.Data;
using SubscriptionBasedFlowInMVCCore.Models;
using System.Security.Claims;

namespace SubscriptionBasedFlowInMVCCore.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var subscription = _context.Subscriptions
                                       .Include(s => s.Features)
                                       .FirstOrDefault(s => s.UserId == userId);

            ViewBag.Subscription = subscription;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Subscribe(string subscriptionType)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var subscription = new Subscription
            {
                UserId = userId,
                SubscriptionType = subscriptionType,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            };

            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();

            // Set session and cookie
            HttpContext.Session.SetString("SubscriptionType", subscriptionType);
            Response.Cookies.Append("SubscriptionType", subscriptionType, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(1)
            });

            return RedirectToAction("Details");
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var subscription = _context.Subscriptions
                                       .Include(s => s.Features)
                                       .FirstOrDefault(s => s.UserId == userId);

            if (subscription == null)
            {
                return RedirectToAction("Index");
            }

            var features = _context.SubscriptionFeatures
                                   .Where(f => f.SubscriptionType == subscription.SubscriptionType)
                                   .ToList();

            ViewBag.Subscription = subscription;
            ViewBag.Features = features;

            return View();
        }
    }
}