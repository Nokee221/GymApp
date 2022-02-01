using Data.EntityModel;
using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EventController(ApplicationDbContext context, IWebHostEnvironment webHostEnviromnet)
        {
            _context = context;
            _webHostEnvironment = webHostEnviromnet;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult TableIndex()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult Edit(int EventId)
        {

            EventAddVM g;
            if (EventId == 0)
                g = new EventAddVM() { };
            else
                g = _context.Events
                    .Where(w => w.EventId == EventId)
                    .Select(s => new EventAddVM
                    {
                        EventId = s.EventId,
                        Name = s.Name,
                        Description = s.Description,
                        FinishDate = s.FinishDate,
                        StartDate = s.StartDate,
                        NameOfCoach = s.NameOfCoach

                    }).Single();




            return View("Edit", g);
        }

        [HttpPost]
        public IActionResult Save(EventAddVM x)
        {
            string stringFileName = UploadFile(x);
            Event e;

            if(x.EventId == 0)
            {
                e = new Event();
                _context.Add(e);
            }
            else
            {
                e = _context.Events.Find(x.EventId);
            }

            e.Description = x.Description;
            e.StartDate = x.StartDate;
            e.FinishDate = x.FinishDate;
            e.Name = x.Name;
            e.NameOfCoach = x.NameOfCoach;
            e.EventImage = stringFileName;
            e.GymID = x.GymID;

            _context.SaveChanges();

            return Redirect("/TableIndex");
        }


        private string UploadFile(EventAddVM ea)
        {
            string fileName = null;
            if (ea.EventImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "EventImages");
                fileName = Guid.NewGuid().ToString() + "-" + ea.EventImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ea.EventImage.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public IActionResult Delete(int EventId)
        {

            Event g = _context.Events.Find(EventId);

            _context.Remove(g);
            _context.SaveChanges();

            TempData["PorukaInfo"] = "Uspjesno izbrisan evenet sa ID-om " + g.EventId;

            return Redirect("/Gym/Message");
        }
    }
}
