using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GFood_CaseStudy.TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductPriceService _productPriceService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductsController(IProductService productService, IProductPriceService productPriceService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productPriceService = productPriceService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddPrice([FromBody] ProductPrice productPrice)
        {
            var result = _productPriceService.Add(productPrice);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("productId")]
        public IActionResult GetPrice(int productId)
        {
            var result = _productPriceService.GetActiveByProductId(productId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] ProductCategory productCategory)
        {
            var result = _productCategoryService.Add(productCategory);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
