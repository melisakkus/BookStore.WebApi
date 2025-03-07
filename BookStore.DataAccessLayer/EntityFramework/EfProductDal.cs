using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(BookStoreContext context) : base(context)
        {
        }

		BookStoreContext context = new BookStoreContext();

		public int GetProductCount()
        {
            int value = context.Products.Count();
            return value;
        }

		public List<Product> GetLastFourBooks()
        {
            var products = context.Products.OrderByDescending(x=>x.ProductId).Take(4).ToList();
			return products;
		}

		public Product GetBestSellingBook()
		{
			Random random = new Random();
			int countOfProducts = context.Products.Count();
			int randomIndex = random.Next(1,(countOfProducts+1));
			var product = context.Products.Skip(randomIndex-1).FirstOrDefault();
			return product;
		}
	}
}
