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
    public class GeneralInfoManager : IGeneralInfoService
    {
        private readonly IGeneralInfoDal _generalInfoDal;
        public GeneralInfoManager(IGeneralInfoDal generalInfoDal)
        {
            _generalInfoDal = generalInfoDal;
        }

        public void TAdd(GeneralInfo entity)
        {
            _generalInfoDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _generalInfoDal.Delete(id);
        }

        public List<GeneralInfo> TGetAll()
        {
            return _generalInfoDal.GetAll();
        }

        public GeneralInfo TGetById(int id)
        {
            return _generalInfoDal.GetById(id);
        }

        public GeneralInfo TGetLastOne()
        {
            return _generalInfoDal.GetLastOne();
        }

        public void TUpdate(GeneralInfo entity)
        {
            _generalInfoDal.Update(entity);
        }
    }
}
