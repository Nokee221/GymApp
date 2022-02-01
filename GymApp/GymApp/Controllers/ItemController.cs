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
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ItemController(ApplicationDbContext context , IWebHostEnvironment webHostEnviromnet)
        {
            _context = context;
            _webHostEnvironment = webHostEnviromnet;
        }


        public IActionResult Index()
        {
            var items = _context.Items.ToList();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ItemIndexVM vm)
        {

            string stringFileName = UploadFile(vm);
            var item = new Item
            {
                Name = vm.Name,
                Description = vm.Description,
                Price = vm.Price,
                ItemImage = stringFileName
            };
            _context.Items.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string UploadFile(ItemIndexVM vm)
        {
            string fileName = null;
            if(vm.ItemImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "ItemImages");
                fileName = Guid.NewGuid().ToString() + "-" + vm.ItemImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.ItemImage.CopyTo(fileStream);
                }
            }

            return fileName;
        }
    }
}
