using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class InfoManager : IInfoService

    {
        private readonly IInfoDal _infoDal;

        public InfoManager(IInfoDal infoDal)
        {
            _infoDal = infoDal;
        }

        public void TDelete(Info t)
        {
           _infoDal.Delete(t);
        }

        public Info TGetByID(int id)
        {
            return _infoDal.GetByID(id);
        }

        public List<Info> TGetList()
        {
            return _infoDal.GetList();
        }

        public void TInsert(Info t)
        {
            _infoDal.Insert(t);
        }

        public void TUpdate(Info t)
        {
           _infoDal.Update(t);
        }
    }
}
