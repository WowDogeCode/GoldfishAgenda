using AutoMapper;
using DataAccess.Entities;
using GoldfishAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldfishAgenda.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpenseReadDto>();
            CreateMap<ExpenseCreateDto, Expense>();
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
        }
    }
}
