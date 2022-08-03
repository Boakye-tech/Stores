using Microsoft.AspNetCore.Mvc;
using Stores.App_Data;
using System.Collections.Generic;
using Stores.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stores.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _dal;

        public ItemsController(ApplicationDbContext appDb)
        {
            _dal = appDb;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Items> objList = _dal.Items;
            return View(objList);
        }

        // GET: /<create item>/
        public IActionResult CreateItem()
        {
            return View();
        }

        // POST: /<create item>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateItem(Items itemObj)
        {
            if (ModelState.IsValid)
            {
                _dal.Items.Add(itemObj);
                _dal.SaveChanges();
                return RedirectToAction("Index", "Items");
            }

            return View(itemObj);
        }


        // GET: /<delete item>/
        public IActionResult DeleteItem(string itemcode)
        {
            if (itemcode == null || itemcode == "0")
            {
                return NotFound();
            }
            var itemObj = _dal.Items.Find(itemcode);
            if (itemObj == null)
            {
                return NotFound();
            }
            return View(itemObj);
        }

        // POST: /<delete item>/
        //[HttpPost, ActionName("DeleteItem")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string itemcode)
        {
            var itemObj = _dal.Items.Find(itemcode);
            if (itemObj == null)
            {
                return NotFound();
            }

            _dal.Items.Remove(itemObj);
            _dal.SaveChanges();
            return RedirectToAction("Index", "Items");
        }

        // GET: /<update item>/
        public IActionResult UpdateItem(string itemcode)
        {
            if (itemcode == null || itemcode == "0")
            {
                return NotFound();
            }
            var itemObj = _dal.Items.Find(itemcode);
            if (itemObj == null)
            {
                return NotFound();
            }
            return View(itemObj);
        }

        // POST: /<update item>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateItem(Items itemObj)
        {
            if (ModelState.IsValid)
            {
                _dal.Items.Update(itemObj);
                _dal.SaveChanges();
                return RedirectToAction("Index", "Items");
            }
            return View(itemObj);
        }

    }
}
