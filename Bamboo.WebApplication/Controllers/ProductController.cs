using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Models;
using Bamboo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;

        public ProductController(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        [Route("category/create")]
        [HttpPost]
        public async Task<IActionResult> CreateProductCategory([FromBody] CreateProductCategoryModel model)
        {
            var result = await _productCategoryService.Create(model).ConfigureAwait(true);
            return Ok(result);
        }

        [Route("category/gets")]
        [HttpGet]
        public async Task<IActionResult> GetProductCategory()
        {
            return Ok(await _productCategoryService.GetAll().ConfigureAwait(true));
        }

        [Route("category/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProdductCategory(int id)
        {
            await _productCategoryService.DeleteAsync(id).ConfigureAwait(true);
            return NoContent();
        }

        [Route("category/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductCategory([FromBody] ProductCategoryModel model)
        {
            await _productCategoryService.UpdateAsync(model);
            return NoContent();
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductModel model)
        {
            var result = await _productService.CreateAsync(model).ConfigureAwait(true);
            return Ok(result);
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllAsync().ConfigureAwait(true));
        }

        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productService.GetById(id).ConfigureAwait(true);
            return Ok(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id).ConfigureAwait(true);
            return NoContent();
        }

        [Route("edit")]
        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] EditProductModel model)
        {
            await _productService.UpdateAsync(model).ConfigureAwait(true);
            return NoContent();
        }
    }
}