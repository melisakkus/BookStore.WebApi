using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ProductDtos;

namespace BookStore.WebApi.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
