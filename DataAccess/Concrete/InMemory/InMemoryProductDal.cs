using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
      
        public InMemoryProductDal()
        {

            //Oracle, Sql Server, Postgres, MongoDb
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Tabak", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Bilgisayar", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Fare", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Klavye", UnitPrice=85, UnitsInStock=11}
            };

            FindTest(_products);
        }

        private void FindTest(List<Product> products)
        {
            var result = _products.Find(p => p.ProductId == 2);
            Console.WriteLine(result.ProductName);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*LİSTEDEN ÜRÜN SİLMEK--TÜM LİSTEYİ DOLAŞMAK(LİNQ BİLMEDEN)
            foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/

            //LİNQ KULLANARAK YAZIM
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {

            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //WHERE İÇİNDEKİ ŞARTI SAĞLAYAN BÜTÜN VERİLERİ YENİ BİR LİSTE HALİNE GETİRİR VE DÖNDÜRÜR
            return _products.Where(p => p.CategoryId == categoryId ).ToList();
        }

        public void Update(Product product)
        {
            //GÖNDERDİĞİM ÜRÜN ID SİNE SAHİP OLAN ÜRÜNÜ LİSTEDEN BUL
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
} 