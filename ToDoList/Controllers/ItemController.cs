using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemController : Controller
    {

        private ItemDbContext context = new ItemDbContext();
        
        // GET: Item
        public ActionResult Index()
        {
            var items = from i in context.Items select i;
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Title,Description,IsFinished")] Item item)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(item);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}