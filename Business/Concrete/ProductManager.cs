using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İŞ KODLARI
            //Listelemeye yetkisi var mı?(Burada if ile vs kurallarımızı yazıyoruz)
            return _productDal.GetAll();
        }
    }
}