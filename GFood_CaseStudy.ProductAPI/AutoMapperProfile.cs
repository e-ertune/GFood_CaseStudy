using AutoMapper;
using GFood_CaseStudy.Entities.DTOs;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.ProductAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductPrice, ProductPriceDto>();
        }
    }
}
