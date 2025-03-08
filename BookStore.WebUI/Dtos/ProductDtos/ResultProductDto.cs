using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.CategoryDtos;

namespace BookStore.WebUI.Dtos.ProductDtos
{
    public class ResultProductDto
    {
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public string AuthorName { get; set; }

		public int? CategoryId { get; set; }
		public ResultCategoryDto? Category { get; set; }
	}
}
