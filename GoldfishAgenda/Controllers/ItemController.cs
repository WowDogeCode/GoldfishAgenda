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
    public class ItemController : Controller
    {
        private readonly IRepository<Item> _repository;
        private readonly IMapper _mapper;
        public ItemController(IRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var items = _repository.GetAll();
            return View(_mapper.Map<IEnumerable<ItemReadDto>>(items));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemCreateDto itemCreateDto)
        {
            if (ModelState.IsValid == true)
            {
                var item = _mapper.Map<Item>(itemCreateDto);
                _repository.Add(item);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(itemCreateDto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _repository.GetById(id);
            return item == null ? NotFound() : View(_mapper.Map<ItemReadDto>(item));
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
            return item == null ? NotFound() : View(_mapper.Map<ItemReadDto>(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ItemReadDto itemReadDto)
        {
            var itemToUpdate = _repository.GetById(itemReadDto.ItemId);
            if (itemToUpdate == null) return NotFound();

            if (ModelState.IsValid == true)
            {
                itemToUpdate.ItemName = itemReadDto.ItemName;
                itemToUpdate.Borrower = itemReadDto.Borrower;
                itemToUpdate.Lender = itemReadDto.Lender;
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(_mapper.Map<ItemReadDto>(itemToUpdate));
        }
    }
}
