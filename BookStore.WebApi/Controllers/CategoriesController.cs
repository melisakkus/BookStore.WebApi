using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {            
            var values = _categoryService.TGetAll();
            var dtos = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(category);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {            
            _categoryService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            var dto = _mapper.Map<GetByIdCategoryDto>(category);
            return Ok(dto);
        }
    }
}
