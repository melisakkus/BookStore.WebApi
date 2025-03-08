using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productService.TGetAll();
            var dtos = _mapper.Map<List<ResultProductDto>>(products);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(product);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.TGetById(id);
            var dto = _mapper.Map<GetByIdProductDto>(product);
            return Ok(dto);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

        [HttpGet("LastFourBooks")]
		public IActionResult LastFourBooks()
		{   
            var products = _productService.TGetLastFourBooks();
            var dtos = _mapper.Map<List<ResultProductDto>>(products);
            return Ok(dtos);
		}

        [HttpGet("BestSellingBook")]
		public IActionResult BestSellingBook()
        {
            var product = _productService.TGetBestSellingBook();
            var dto = _mapper.Map<ResultProductDto>(product);
            return Ok(dto);
		}
	}
}
