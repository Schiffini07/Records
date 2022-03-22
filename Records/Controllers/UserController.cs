using Microsoft.AspNetCore.Mvc;
using Records.Data;
using Records.Models;
using Records.Repository;
using System.Collections.Generic;

namespace Records.Controllers
{
    public class UserController : Controller
    {
        private readonly RecordsDbContext _db;

        public UserController(RecordsDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _db.Users.ToList();
            return View(objUserList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (user.Name != "")
            {
                User user1 = new User()
                {
                    Name = user.Name,
                    Amount = user.Amount,
                    Date = user.Date,
                    LiteralAmount = Converter.NumberToWords(user.Amount)

                };
                _db.Users.Add(user1);
                _db.SaveChanges();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (user.Id > 0)
            {
                user.Amount = user.Amount;
                user.Name = user.Name;
                user.Date = user.Date;
                user.LiteralAmount = Converter.NumberToWords(user.Amount);
                _db.Users.Update(user);
                _db.SaveChanges();
                TempData["success"] = "User updated successfully";
                return RedirectToAction("Index");
            }
           
            return View(user);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
        
        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            _db.SaveChanges();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
        }

        //Get
        public IActionResult ListCheck(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }
    }
}
