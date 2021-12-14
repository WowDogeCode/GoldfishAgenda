using DataAccess.Entities;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IRepository<Expense> _repository;
        public ExpenseController(IRepository<Expense> repository) => _repository = repository;

        [HttpGet]
        public IActionResult Index()
        {
            var expenses = _repository.GetAll();
            return View(expenses);
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid == true)
            {
                _repository.Add(expense);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var expense = _repository.GetById(id);
            return expense == null ? NotFound() : View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var expense = _repository.GetById(id);
            if (expense != null)
            {
                _repository.Remove(expense);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var expense = _repository.GetById(id);
            return expense == null ? NotFound() : View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            var expenseToUpdate = _repository.GetById(expense.ExpenseId);
            expenseToUpdate.ExpenseName = expense.ExpenseName;
            expenseToUpdate.Amount = expense.Amount;

            if(ModelState.IsValid == true)
            {
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(expense);
        }
    }
}
