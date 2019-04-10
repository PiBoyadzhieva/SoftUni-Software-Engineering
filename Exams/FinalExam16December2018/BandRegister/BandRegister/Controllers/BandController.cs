using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandRegisterDbContext())
            {
                var allTasks = db.Bands.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string members, double honorarium, string genre)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Band band = new Band
            {
                Name = name,
                Members = members,
                Honorarium = honorarium,
                Genre = genre
            };

            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.Find(id);

                if (bandToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Update(band);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelete = db.Bands.Find(id);

                if(bandToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}