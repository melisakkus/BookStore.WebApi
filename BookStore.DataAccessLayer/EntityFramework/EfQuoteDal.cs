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
    public class EfQuoteDal : GenericRepository<Quote>, IQuoteDal
    {
        public EfQuoteDal(BookStoreContext context) : base(context)
        {
        }

        //BookStoreContext context = new BookStoreContext();
        public Quote TakeLastQuote()
        {
            var quote = _context.Quotes.OrderByDescending(x => x.QuoteId).FirstOrDefault();
            return quote;
        }
    }
}
