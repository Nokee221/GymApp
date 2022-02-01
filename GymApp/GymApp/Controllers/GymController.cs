using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Data;
using GymApp.EntityModel;
using GymApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Data.EntityModel;

namespace GymApp.Controllers
{
    public class GymController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GymController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Delete(int GymID)
        {

            Gym g = _context.Gyms.Find(GymID);

            _context.Remove(g);
            _context.SaveChanges();

            TempData["PorukaInfo"] = "Uspjesno izbrisana teretana sa nazivom " + g.Name;

            return Redirect("/Gym/Message");
        }

        public IActionResult Message()
        {
            return View("Message");
        }

        public IActionResult Edit(int GymID)
        {

            GymAddVM g;
            if (GymID == 0)
                g = new GymAddVM() { };
            else
                g = _context.Gyms
                    .Where(w => w.ID == GymID)
                    .Select(s => new GymAddVM
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Description = s.Description,
                        Address = s.Address,
                    }).Single();




            return View("Edit" , g);
        }

        public IActionResult Save(GymAddVM x)
        {
            string stringFileName = UploadFile(x);
            Gym gym;

            if(x.ID == 0)
            {
                gym = new Gym();
                _context.Add(gym);
                TempData["PorukaInfo"] = "Uspjesno ste dodali novu teretanu pod nazivom " + x.Name;
            }
            else
            {
                gym = _context.Gyms.Find(x.ID);
                TempData["PorukaInfo"] = "Uspjesno ste uredili teretanu " + x.Name;
            }

            gym.Name = x.Name;
            gym.Description = x.Description;
            gym.Address = x.Address;
            gym.GymImage = stringFileName;

            _context.SaveChanges();


            return Redirect("/Gym/Message");
        }

        private string UploadFile(GymAddVM x)
        {
            string fileName = null;
            if(x.GymImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "GymImages");
                fileName = Guid.NewGuid().ToString() + "-" + x.GymImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using(var fileStream = new FileStream(filePath , FileMode.Create))
                {
                    x.GymImage.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public IActionResult Index()
        {

            var gyms = _context.Gyms.ToList();
            return View(gyms);
        }
    }
}