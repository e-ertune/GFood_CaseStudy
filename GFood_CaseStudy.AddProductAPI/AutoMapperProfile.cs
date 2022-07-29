using AutoMapper;
using GFood_CaseStudy.Entities.DTOs;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.AddProductAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BasketProductDto, BasketProduct>();
        }
    }
}
