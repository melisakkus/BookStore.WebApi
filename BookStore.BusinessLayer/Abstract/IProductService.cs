﻿using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        int TGetProductCount();
		List<Product> TGetLastFourBooks();
		Product TGetBestSellingBook();


	}
}
