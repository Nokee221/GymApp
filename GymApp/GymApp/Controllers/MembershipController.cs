using Data.EntityModel;
using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GymApp.Controllers
{
    [Authorize]
    public class MembershipController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public MembershipController(ApplicationDbContext context , UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateMembership(int id)
        {
            var membershipType = context.MembershipTypes.Find(id);
            var model = new MembershipCreateVM();
            model.Gyms = context.Gyms
                .Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList();
            model.MembershipTypeId = membershipType.MembershipTypeId;
            model.TypeName = membershipType.TypeName;
            model.Price = membershipType.Price;

            ViewData["model"] = model;
            return View(model);
        }

        [HttpPost]

        public IActionResult Save(MembershipCreateVM m)
        {
            var membershipType = context.MembershipTypes.Where(i => i.TypeName.Equals(m.TypeName)).FirstOrDefault();

            var membership = new Membership();

            foreach (var user in userManager.Users.ToList())
            {
                if (user.UserName == userManager.GetUserName(User))
                {
                    if (context.Memberships.Count() != 0)
                    {
                        foreach (var x in context.Memberships)
                        {
                            if (x != null && x.EndDate.Month > DateTime.Now.Month || x.EndDate.Year < DateTime.Now.Year && x.ApplicationUser.ToString() == userManager.GetUserName(User))
                            {

                                return RedirectToAction("AlertMessage", "Membership");

                            }
                            else
                            {

                                membership.GymID = m.Gym;
                                membership.ApplicationUserId = userManager.GetUserId(User);
                                membership.MembershipTypeId = membershipType.MembershipTypeId;
                                membership.StartDate = DateTime.Now;
                                if(m.TypeName == "BASIC")
                                {  
                                    membership.EndDate = DateTime.Now.AddDays(30);

                                }else if(m.TypeName == "STANDARD")
                                {
                                    membership.EndDate = DateTime.Now.AddDays(60);
                                }else if(m.TypeName == "PREMIUM")
                                {
                                    membership.EndDate = DateTime.Now.AddDays(90);

                                }


                            }
                        }

                    }
                    else
                    {
                        membership.GymID = m.Gym;
                        membership.ApplicationUserId = userManager.GetUserId(User);
                        membership.MembershipTypeId = m.MembershipTypeId;
                        membership.StartDate = DateTime.Now;
                        if (m.TypeName == "BASIC")
                        {
                            membership.EndDate = DateTime.Now.AddDays(30);

                        }
                        else if (m.TypeName == "STANDARD")
                        {
                            membership.EndDate = DateTime.Now.AddDays(60);
                        }
                        else if (m.TypeName == "PREMIUM")
                        {
                            membership.EndDate = DateTime.Now.AddDays(90);

                        }

                    }
                }
            }



            context.Memberships.Add(membership);
            context.SaveChanges();

            return RedirectToAction("index", "Membership");
        }

        public IActionResult Index()
        {
            List<MembershipIndexVM.Row> result = context.Memberships
                .Select(x => new MembershipIndexVM.Row
                {
                    Gym = x.Gym.Name,
                    ApplicationUser = x.ApplicationUser.UserName,
                    MembershipTypeName = x.MembershipType.TypeName,
                    Price = x.MembershipType.Price,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,


                }).Where(x => x.ApplicationUser == userManager.GetUserName(User))
                .ToList();

            MembershipIndexVM m = new MembershipIndexVM();
            m.memberships = result;


            return View(m);
        }

        public IActionResult AlertMessage()
        {

            return View();
        }
    }
}
