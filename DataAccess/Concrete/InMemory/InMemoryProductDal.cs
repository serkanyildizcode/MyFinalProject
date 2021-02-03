using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> products;
        public InMemoryProductDal()
        {
            products = new List<Product> { 
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitInStock=15,UnitPrice=15},
                new Product{CategoryId=1,ProductId=1,ProductName="Kamera",UnitInStock=500,UnitPrice=3},
                new Product{CategoryId=2,ProductId=3,ProductName="Telefon",UnitInStock=1500,UnitPrice=2},
                new Product{CategoryId=2,ProductId=4,ProductName="Klavye",UnitInStock=150,UnitPrice=65},
                new Product{CategoryId=2,ProductId=5,ProductName="Fare",UnitInStock=85,UnitPrice=1}
                
            };
        }


        public void Add(Product product)
        {
            products.Add(product);
           
        }

        public void Delete(Product product)
        {
            /*Product productToDelete = null;

            foreach (var p in products)
            {
                if (product.ProductId==p.ProductId)
                {
                    productToDelete = p;
                }
               
            }*/
            //LINQ - LANGUAGE INTEGRATED QUERY

            Product productToDelete = products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            products.Remove(productToDelete);
           




        }

        public List<Product> GetAll()
        {
            return products;


        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim Ürün id'sine sahip listedeki ürünü bul.
            Product productToUpdate = products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
       
        }
    }
}
