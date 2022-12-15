using Microsoft.EntityFrameworkCore;
using PetShopAPI.DataDB;
using PetShopAPI.PetShop.API.Models;
using PetShopAPI.Services;
using System.Linq;
using System;
using Microsoft.VisualBasic;

namespace PetShopAPI.Tests
{
     
    public class ProductTests : DbContextFixturePetShop
    {
      

        [Fact]
        public async void TestCreateProduct()
        {
            var product = new ProductModel
            {
                Category = "assdf87testcategoryCREATE",
                Name = "3asdf87testnameCREATE",
                Price = 8787,
            };


            var service = new ProductService();
            var result = await service.PostAsync(product);
            var rm = Assert.IsType<Product>(result);
            Assert.Equal(product.Category, rm.Category);
            Assert.Equal(product.Name, rm.Name);
            Assert.Equal(product.Price, rm.Price);


        }

        [Fact]
        public async void TestUpdateProduct() 
        {
            
            var product = new Product
            {
                Category = "abcasdfasdfd",
                Name = "fdasdfasdfsa",
                Price = 12222,
            };

            await using (var context = TestUtilsPetShop.CreateContext())
            {

                {
                   context.Products.Add(product);
                   context.SaveChanges();
                };

                var updatedproduct = new ProductModel
                {
                    Category = "2updatedcategory",
                    Name = "2updatedname",
                    Price = 87,
                };

                var service = new ProductService();
                var result = await service.UpdateProduct(product.ID, updatedproduct);
                var rm = Assert.IsType<Product>(result);
                Assert.Equal(updatedproduct.Category, rm.Category);
                Assert.Equal(updatedproduct.Name, rm.Name);
                Assert.Equal(updatedproduct.Price, rm.Price);

            }
        }


        [Fact]
        public async void TestGetByIdProduct()
        {
            var display = new Product
            {
                Category = "testdisplaycategory",
                Name = "testdisplayname",
                Price = 99,
            };

            await using var context = TestUtilsPetShop.CreateContext();

            context.Products.Add(display);
            context.SaveChanges();

            var service = new ProductService();
            var byIdResult = await service.ReadProduct(display.ID);
            Assert.NotNull(byIdResult);
            Assert.Equal(display.ID, byIdResult.ID);

        }

        [Fact]

        public async void TestDeleteProduct() // nicht fertig daher test nicht erfolgreich, probe möglich?
        {

            var ToDelete = new Product
            {
                Category = "testDELETEcategory",
                Name = "testDELETEname",
                Price = 1010,
            };

            await using (var context = TestUtilsPetShop.CreateContext())
            {
                context.Products.Add(ToDelete);
                context.SaveChanges();
            }

            var service = new ProductService();
            var result = await service.DeleteProduct(ToDelete.ID);
            Assert.IsType<Product>(result);
            // Assert.Null(result.Name);


            await using (var context = TestUtilsPetShop.CreateContext())
            {


                var fromDB = context.Products.FirstOrDefaultAsync(p => p.ID == ToDelete.ID);

                var categoryfromdb = await context.Products.FirstOrDefaultAsync(x => x.ID == ToDelete.ID);
                //categoryfromdb.ID.Equals(null);
                categoryfromdb.Name.Equals(null);
                Assert.Null(ToDelete.ID);
                Assert.Null(ToDelete.Name);
                Assert.Null(ToDelete.Price);
                Assert.Null(ToDelete.Category);



            }
        }
    }
}    
    