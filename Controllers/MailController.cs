using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;

namespace MUNICIPALIDAD_V4.Controllers
{
    public class MailController : Controller
    {
        private readonly IEmailService _EmailService;

        public MailController(IEmailService emailService)
        {
            _EmailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Email()
        {
            ViewData["Message"] = "ASP.NET Core mvc send email example";

            _EmailService.Send("shenbo.128@163.com", "ASP.NET Core mvc send email example", "Send from asp.net core mvc action");

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}




