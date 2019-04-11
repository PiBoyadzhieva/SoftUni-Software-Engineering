using System.Linq;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using GameStore.Data;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new GameStoreDbContext())
            {
                var allTasks = db.Games.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string dlc, double price, string platform)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dlc) || string.IsNullOrEmpty(platform) || price == 0)
            {
                return RedirectToAction("Index");
            }

            Game game = new Game
            {
                Name = name,
                Dlc = dlc,
                Price = price,
                Platform = platform
            };

            using (var db = new GameStoreDbContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var gameToEdit = db.Games.Find(id);

                if (gameToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(gameToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new GameStoreDbContext())
            {
                db.Games.Update(game);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var gameToDelete = db.Games.Find(id);

                if (gameToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return View(gameToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            using (var db = new GameStoreDbContext())
            {
                db.Games.Remove(game);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}