using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.ProductDtos;

namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ResultProductDto>? Products { get; set; }

    }
}

//apiden gelen veriyi ui tarafındaki model ile eşleştirmek için 