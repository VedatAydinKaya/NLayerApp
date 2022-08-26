using AutoMapper;
using Core.Dtos;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public ProductsController(IService<Product> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet] // GET api/products
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(CustomResponseDto<List<ProductDto>>.Success(productsDto, 200));

            return CreateActionResult<List<ProductDto>>(CustomResponseDto<List<ProductDto>>.Success(productsDto, 200));
        }
        [HttpGet("{id]")] //GET api/products/5
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(productDto, 200));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto) 
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productDtos=_mapper.Map<ProductDto>(product);

            return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Success(productDtos, 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdate productDto) 
        {
             await _service.UpdateAsync(_mapper.Map<Product>(productDto));         

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete]  // DELETE api/products/5
        public async Task<IActionResult> Remove(int id) 
        {
            var product = await _service.GetByIdAsync(id);

            if (product==null)
            {
                return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Fail(404, "Product not found"));

            }
            await _service.RemoveAsync(product);

            return CreateActionResult<NoContentDto>(CustomResponseDto<NoContentDto>.Success(204));
        }
    
   }
}
