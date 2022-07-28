using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace GFood_CaseStudy.TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public IActionResult GetWithConditions(int id)
        {
            var result = _campaignService.GetWithConditions(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Campaign campaign)
        {
            var result = _campaignService.Add(campaign);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _campaignService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddCondition([FromBody] CampaignCondition campaignCondition)
        {
            var result = _campaignService.AddCondition(campaignCondition);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddProductToCondition([FromBody] CampaignConditionProduct campaignConditionProduct)
        {
            var result = _campaignService.AddProductToCondition(campaignConditionProduct);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddGoal([FromBody] CampaignGoal campaignGoal)
        {
            var result = _campaignService.AddGoal(campaignGoal);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddProductToGoal([FromBody] CampaignGoalProduct campaignGoalProduct)
        {
            var result = _campaignService.AddProductToGoal(campaignGoalProduct);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetSuitableCampaigns(int basketId)
        {
            var result = _campaignService.GetSuitableCampaigns(basketId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult UseCampaign([FromBody] BasketCampaign basketCampaign)
        {
            var result = _campaignService.UseCampaign(basketCampaign);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
