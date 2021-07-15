using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            RedirectToAction();

            return View("Action");
        }

        public IActionResult Delete(int Id)
        {
            Item item = _context.Items.Where(i => i.Id == Id).FirstOrDefault();
            _context.Items.Remove(item);
            _context.SaveChanges();
            RedirectToAction();

            return View("Delete");
        }
    }
}
