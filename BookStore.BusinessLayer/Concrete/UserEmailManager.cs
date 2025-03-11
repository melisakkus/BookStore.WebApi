using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class UserEmailManager : IUserEmailService
    {
        private readonly IUserEmailDal _userEmailDal;

        public UserEmailManager(IUserEmailDal userEmailDal)
        {
            _userEmailDal = userEmailDal;
        }

        public void TAdd(UserEmail entity)
        {
            _userEmailDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _userEmailDal.Delete(id);
        }

        public List<UserEmail> TGetAll()
        {
            return _userEmailDal.GetAll();
        }

        public UserEmail TGetById(int id)
        {
            return _userEmailDal.GetById(id);
        }

        public void TUpdate(UserEmail entity)
        {
           _userEmailDal.Update(entity);
        }
    }
}
