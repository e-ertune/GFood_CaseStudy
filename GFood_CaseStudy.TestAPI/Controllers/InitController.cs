using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Core.Utilities.Results;
using GFood_CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace GFood_CaseStudy.TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IBasketService _basketService;
        private readonly IProductPriceService _productPriceService;

        public InitController(IProductService productService, ICampaignService campaignService, IBasketService basketService, IProductPriceService productPriceService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _basketService = basketService;
            _productPriceService = productPriceService;
        }

        [HttpGet]
        public IActionResult InitProducts()
        {
            var result = _productService.Add(new Product
            {
                Code = "LP_500",
                CreatedAt = DateTime.Now,
                Description = "Lor Peyniri 500 gr",
                IsActive = true,
                IsDeleted = false,
                Name = "Lor Peyniri 500 gr"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 20,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "CMS_2",
                CreatedAt = DateTime.Now,
                Description = "Çiğ Manda Sütü 2lt",
                IsActive = true,
                IsDeleted = false,
                Name = "Çiğ Manda Sütü 2lt"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 50,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "T_500",
                CreatedAt = DateTime.Now,
                Description = "Tereyağ 500gr",
                IsActive = true,
                IsDeleted = false,
                Name = "Tereyağ 500gr"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 60,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "KK_1k",
                CreatedAt = DateTime.Now,
                Description = "Kasap Köfte 1kg",
                IsActive = true,
                IsDeleted = false,
                Name = "Kasap Köfte 1kg"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 135,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "KK_1kg",
                CreatedAt = DateTime.Now,
                Description = "Kaşarlı Köfte 1kg",
                IsActive = true,
                IsDeleted = false,
                Name = "Kaşarlı Köfte 1kg"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 145,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "STL",
                CreatedAt = DateTime.Now,
                Description = "Sütlaç",
                IsActive = true,
                IsDeleted = false,
                Name = "Sütlaç"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 35,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "CIS_2l",
                CreatedAt = DateTime.Now,
                Description = "Çiğ İnek Sütü 2 lt",
                IsActive = true,
                IsDeleted = false,
                Name = "Çiğ İnek Sütü 2 lt"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 55,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "PBYK_1l",
                CreatedAt = DateTime.Now,
                Description = "Probiyotik - Kefir 1 lt",
                IsActive = true,
                IsDeleted = false,
                Name = "Probiyotik - Kefir 1 lt"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 32,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "PSTIS_1l",
                CreatedAt = DateTime.Now,
                Description = "Pastörize İnek Sütü 1 lt",
                IsActive = true,
                IsDeleted = false,
                Name = "Pastörize İnek Sütü 1 lt"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 21,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "PKBP_900",
                CreatedAt = DateTime.Now,
                Description = "Peynirli Kol Böreği - Pişmemiş 900 gr",
                IsActive = true,
                IsDeleted = false,
                Name = "Peynirli Kol Böreği - Pişmemiş 900 gr"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 37,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "KZND",
                CreatedAt = DateTime.Now,
                Description = "Kazandibi",
                IsActive = true,
                IsDeleted = false,
                Name = "Kazandibi"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 37,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "KRSK",
                CreatedAt = DateTime.Now,
                Description = "Krem Şokola",
                IsActive = true,
                IsDeleted = false,
                Name = "Krem Şokola"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 17,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "TVKG",
                CreatedAt = DateTime.Now,
                Description = "Tavukgöğsü",
                IsActive = true,
                IsDeleted = false,
                Name = "Tavukgöğsü"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 23,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "TVKG",
                CreatedAt = DateTime.Now,
                Description = "Keşkül",
                IsActive = true,
                IsDeleted = false,
                Name = "Keşkül"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 23,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "YSLC_50g",
                CreatedAt = DateTime.Now,
                Description = "Yeşil Çay 50 gr",
                IsActive = true,
                IsDeleted = false,
                Name = "Yeşil Çay 50 gr"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 27,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "CZBK_1k",
                CreatedAt = DateTime.Now,
                Description = "Cızbız Köfte 1 kg",
                IsActive = true,
                IsDeleted = false,
                Name = "Cızbız Köfte 1 kg"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 140,
                ProductId = result.Data.Id
            });

            result = _productService.Add(new Product
            {
                Code = "CZBK_1k",
                CreatedAt = DateTime.Now,
                Description = "Cızbız Köfte 1 kg",
                IsActive = true,
                IsDeleted = false,
                Name = "Cızbız Köfte 1 kg"
            });
            _productPriceService.Add(new ProductPrice
            {
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Price = 140,
                ProductId = result.Data.Id
            });

            return Ok();
        }

        [HttpGet]
        public IActionResult InitCampaigns()
        {
            IDataResult<Campaign> campaign;
            IDataResult<CampaignCondition> condition;
            IDataResult<CampaignConditionProduct> conditionProduct;
            IDataResult<CampaignGoal> goal;
            IDataResult<CampaignGoalProduct> goalProduct;

            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "250 TL üzeri alışverişlerde “Lor Peyniri 500 gr” bedava",
                Name = "250 TL üzeri alışverişlerde “Lor Peyniri 500 gr” bedava",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 250,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("LP_500").Data.Id,
                Quantity = 1
            });



            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Çiğ Manda Sütü 2lt” alana “Tereyağ 500gr” %50 indirimli",
                Name = "“Çiğ Manda Sütü 2lt” alana “Tereyağ 500gr” %50 indirimli",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CMS_2").Data.Id,
                Quantity = 1
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 50,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("T_500").Data.Id,
                Quantity = 1
            });


            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Kasap Köfte 1kg” ve “Kaşarlı Köfte 1kg” alana Sütlaç bedava",
                Name = "“Kasap Köfte 1kg” ve “Kaşarlı Köfte 1kg” alana Sütlaç bedava",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("KK_1k").Data.Id,
                Quantity = 1
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("KK_1kg").Data.Id,
                Quantity = 1
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("STL").Data.Id,
                Quantity = 1
            });



            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Çiğ İnek Sütü 2 lt”, “Çiğ Manda Sütü 2 lt” ve “Pastörize İnek Sütü 1 lt” birlikte alana %10 indirim",
                Name = "“Çiğ İnek Sütü 2 lt”, “Çiğ Manda Sütü 2 lt” ve “Pastörize İnek Sütü 1 lt” birlikte alana %10 indirim",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CIS_2l").Data.Id,
                Quantity = 1
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CMS_2").Data.Id,
                Quantity = 1
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("PSTIS_1l").Data.Id,
                Quantity = 1
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 10,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });

            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Çiğ İnek Sütü 2 lt” den 2 adet alana “Probiyotik - Kefir 1 lt” %10 indirimli",
                Name = "“Çiğ İnek Sütü 2 lt” den 2 adet alana “Probiyotik - Kefir 1 lt” %10 indirimli",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CIS_2l").Data.Id,
                Quantity = 2
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 10,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("PBYK_1l").Data.Id,
                Quantity = 1
            });


            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Çiğ İnek Sütü 2 lt” ve “Çiğ Manda Sütü 2 lt” den 2 şer adet alana 2 adet “Pastörize İnek Sütü 1 lt” %10 indirimli",
                Name = "“Çiğ İnek Sütü 2 lt” ve “Çiğ Manda Sütü 2 lt” den 2 şer adet alana 2 adet “Pastörize İnek Sütü 1 lt” %10 indirimli",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CIS_2l").Data.Id,
                Quantity = 2
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("CMS_2").Data.Id,
                Quantity = 2
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 10,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("PSTIS_1l").Data.Id,
                Quantity = 2
            });


            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "“Peynirli Kol Böreği - Pişmemiş 900 gr” dan 3 adet alana “Sütlaç” ve “Kazandibi” bedava",
                Name = "“Peynirli Kol Böreği - Pişmemiş 900 gr” dan 3 adet alana “Sütlaç” ve “Kazandibi” bedava",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("PKBP_900").Data.Id,
                Quantity = 3
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("STL").Data.Id,
                Quantity = 1
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("KZND").Data.Id,
                Quantity = 1
            });



            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "2 adet “Krem Şokola” veya “Tavukgöğsü” alana “Keşkül” bedava",
                Name = "2 adet “Krem Şokola” veya “Tavukgöğsü” alana “Keşkül” bedava",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("KRSK").Data.Id,
                Quantity = 2
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("TVKG").Data.Id,
                Quantity = 2
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("KSKL").Data.Id,
                Quantity = 1
            });



            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "3 adet “Yeşil Çay 50 gr” alana 1 adet “Yeşil Çay 50 gr” bedava",
                Name = "3 adet “Yeşil Çay 50 gr” alana 1 adet “Yeşil Çay 50 gr” bedava",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 0,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            conditionProduct = _campaignService.AddProductToCondition(new CampaignConditionProduct
            {
                CampaignConditionId = condition.Data.Id,
                ProductId = _productService.GetByCode("YSLC_50g").Data.Id,
                Quantity = 3
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("YSLC_50g").Data.Id,
                Quantity = 1
            });


            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "1.000 TL üzeri alışverişlerde “Cızbız Köfte 1 kg”, “Kasap Köfte 1 kg” ve “Kaşarlı Köfte 1 kg” bedava.",
                Name = "1.000 TL üzeri alışverişlerde “Cızbız Köfte 1 kg”, “Kasap Köfte 1 kg” ve “Kaşarlı Köfte 1 kg” bedava.",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 1000,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 100,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("CZBK_1k").Data.Id,
                Quantity = 1
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("KK_1k").Data.Id,
                Quantity = 1
            });
            goalProduct = _campaignService.AddProductToGoal(new CampaignGoalProduct
            {
                CampaignGoalId = goal.Data.Id,
                ProductId = _productService.GetByCode("KK_1kg").Data.Id,
                Quantity = 1
            });



            campaign = _campaignService.Add(new Campaign
            {
                CreatedAt = DateTime.Now,
                Description = "300 TL alışverişlerde %20 indirim",
                Name = "300 TL alışverişlerde %20 indirim",
                IsDeleted = false,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            });
            condition = _campaignService.AddCondition(new CampaignCondition
            {
                Amount = 300,
                CampaignId = campaign.Data.Id,
                CreatedAt = DateTime.Now
            });
            goal = _campaignService.AddGoal(new CampaignGoal
            {
                Amount = 20,
                CampaignId = campaign.Data.Id,
                IsPercentage = true,
                CreatedAt = DateTime.Now
            });


            return Ok();
        }
    }
}
