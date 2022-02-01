using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GymApp.Models;
using GymApp.Data;
using Data.EntityModel;
using Microsoft.AspNetCore.Identity;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context , UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var gyms = _context.Gyms.ToList();

            return View(gyms);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateInfo(InfoMessageAddVM im)
        {
            
                var result = new InfoMessage
                {
                    Name = im.Name,
                    Email = im.Email,
                    Phone = im.Phone,
                    Message = im.Message

                };

                _context.infoMessages.Add(result);
                _context.SaveChanges();

                return RedirectToAction("index", "home");

           
        }

        
        public IActionResult Info(InfoMessageAddVM im)
        {
           

            return View();
        }

        public IActionResult Paymant()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateMembershipHome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMembershipHome(int gymid)
        {

            var membership = new Membership
            {
                GymID = gymid,
                ApplicationUserId = userManager.GetUserId(User),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                
            };

            _context.Memberships.Add(membership);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
