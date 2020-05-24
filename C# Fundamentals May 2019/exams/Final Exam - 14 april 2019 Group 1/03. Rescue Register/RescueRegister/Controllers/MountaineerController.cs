using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            using(var db = new RescueRegisterDbContext())
            {
                var allMounteners = db.Mountaineers.ToList();
                return View(allMounteners);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Add(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using(var db = new RescueRegisterDbContext())
            {
                var mounteneerToEdit = db.Mountaineers.FirstOrDefault(m => m.Id == id);
                if (mounteneerToEdit==null)
                {
                     RedirectToAction("Index");
                }
                return this.View(mounteneerToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
           using (var db = new RescueRegisterDbContext())
            {
                var mounteneerToEdit = db.Mountaineers.FirstOrDefault(m => m.Id == mountaineer.Id);
                mounteneerToEdit.Age = mountaineer.Age;
                mounteneerToEdit.Name = mountaineer.Name;
                mounteneerToEdit.LastSeenDate = mountaineer.LastSeenDate;
                mounteneerToEdit.Gender = mountaineer.Gender;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using(var db = new RescueRegisterDbContext())
            {
                Mountaineer mountaineerToDelete = db.Mountaineers.FirstOrDefault(m => m.Id == id);
                if (mountaineerToDelete==null)
                {
                    RedirectToAction("Index");
                }
                return this.View(mountaineerToDelete);
            }
           
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            using(var db = new RescueRegisterDbContext())
            {
                var mountaineerToDelete = db.Mountaineers.FirstOrDefault(m => m.Id == mountaineer.Id);
                if (mountaineerToDelete==null)
                {
                    RedirectToAction("Index");
                }
                db.Mountaineers.Remove(mountaineerToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}