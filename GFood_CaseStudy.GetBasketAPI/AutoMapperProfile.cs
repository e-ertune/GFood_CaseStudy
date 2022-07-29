using AutoMapper;
using GFood_CaseStudy.Entities.DTOs;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.GetBasketAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketProduct, BasketProductDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductPrice, ProductPriceDto>();
            CreateMap<BasketCampaign, BasketCampaignDto>();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CampaignCondition, CampaignConditionDto>();
            CreateMap<CampaignConditionProduct, CampaignConditionProductDto>();
            CreateMap<CampaignGoal, CampaignGoalDto>();
            CreateMap<CampaignGoalProduct, CampaignGoalProductDto>();
        }
    }
}
