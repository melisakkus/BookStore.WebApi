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
    public class EfGeneralInfoDal : GenericRepository<GeneralInfo>, IGeneralInfoDal
    {
        public EfGeneralInfoDal(BookStoreContext context) : base(context)
        {
        }

        public GeneralInfo GetLastOne()
        {
            BookStoreContext context = new BookStoreContext();
            return context.GeneralInfos.OrderByDescending(x => x.GeneralInfoId).FirstOrDefault();
        }
    }
}
