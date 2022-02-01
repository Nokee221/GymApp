using GymApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    public class MembershipTypeController : Controller
    {
        private ApplicationDbContext _context;

        public MembershipTypeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            var types = _context.MembershipTypes.ToList();

            return View(types);
        }
    }
}
