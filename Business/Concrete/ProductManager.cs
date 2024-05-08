using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //DataAccess -> Concrete içerisindeki veriler kullanılacak fakat onların isimleri olmadan interfaceleri kullanılacak.

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)  //Bu kısım inmemoryde olur,entitiyde olur herşey olabilir o sebeple interface olarak kullanıldı.
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codess

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Ürün ismi en az  2 karakter olmalıdır.");
            }
            _productDal.Add(product);

            return new SuccessResult("Ürün eklendi.");
        }

        public List<Product> GetAll()
        {
            //İş kodları - Kural -> Bir iş sınıfı başka sınıfları new'lemez. İnjection yapılır. 
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
