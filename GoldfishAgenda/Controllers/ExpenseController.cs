using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repository;
using GoldfishAgenda.Models;
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
        private readonly IMapper _mapper;
        public ExpenseController(IRepository<Expense> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var expenses = _repository.GetAll();
            return View(_mapper.Map<IEnumerable<ExpenseReadDto>>(expenses));
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseCreateDto expenseCreateDto)
        {
            if (ModelState.IsValid == true)
            {
                var expense = _mapper.Map<Expense>(expenseCreateDto);
                _repository.Add(expense);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(expenseCreateDto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var expense = _repository.GetById(id);
            return expense == null ? NotFound() : View(_mapper.Map<ExpenseReadDto>(expense));
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
            return expense == null ? NotFound() : View(_mapper.Map<ExpenseReadDto>(expense));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseReadDto expenseReadDto)
        {
            var expenseToUpdate = _repository.GetById(expenseReadDto.ExpenseId);
            if (expenseToUpdate == null) return NotFound();

            if (ModelState.IsValid == true)
            {
                expenseToUpdate.ExpenseName = expenseReadDto.ExpenseName;
                expenseToUpdate.Amount = expenseReadDto.Amount;
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(_mapper.Map<ExpenseReadDto>(expenseToUpdate));
        }
    }
}
