using AutoMapper;
using GFood_CaseStudy.Entities.DTOs;
using GFood_CaseStudy.Entities.Models;

namespace GFood_CaseStudy.CampaignAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BasketCampaign, BasketCampaignDto>();
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CampaignCondition, CampaignConditionDto>();
            CreateMap<CampaignConditionProduct, CampaignConditionProductDto>();
            CreateMap<CampaignGoal, CampaignGoalDto>();
            CreateMap<CampaignGoalProduct, CampaignGoalProductDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductPrice, ProductPriceDto>();
        }
    }
}
