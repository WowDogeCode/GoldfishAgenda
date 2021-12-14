using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Controllers
{
    public class ItemController : Controller
    {
        private readonly IRepository<Item> _repository;
        public ItemController(IRepository<Item> repository) => _repository = repository;

        [HttpGet]
        public IActionResult Index()
        {
            var items = _repository.GetAll();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid == true)
            {
                _repository.Add(item);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _repository.GetById(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                _repository.Remove(item);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _repository.GetById(id);
            return item == null ? NotFound() : View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item item)
        {
            var itemToUpdate = _repository.GetById(item.ItemId);
            itemToUpdate.ItemName = item.ItemName;
            itemToUpdate.Borrower = item.Borrower;
            itemToUpdate.Lender = item.Lender;

            if (ModelState.IsValid == true)
            {
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(itemToUpdate);
        }
    }
}
