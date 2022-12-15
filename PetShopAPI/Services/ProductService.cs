using PetShopAPI.DataDB;
using PetShopAPI.Services.Interfaces;
using System.Runtime.CompilerServices;
using PetShopAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopAPI.PetShop.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace PetShopAPI.Services


    //                                          CRUD with Interfaces
{
    public class ProductService : IProductService


    {


        public async Task<Product> PostAsync(ProductModel model) {

            var newproduct = new Product
            {
                Category = model.Category,
                Name = model.Name,
                Price = model.Price
            };
            using (var context = DbContextforServices.CreateContext())
            {
                context.Products.Add(newproduct);
                await context.SaveChangesAsync();
            }

           
            return newproduct; //return wert ist liste

            //Testkommentar für Github update
            
        }
        public async Task<Product> ReadProduct(int id) {  //model klasse für user input
            var context = DbContextforServices.CreateContext();

            var productToDisplay = await context.Products.FirstOrDefaultAsync(p => p.ID == id);

            if (productToDisplay == null) { 
            
                return null;
            
            }

            return productToDisplay;
       
            
           // return <productToDisplay>; //nur ein Objekt, sollte list sein <>
        
        }
        public async Task<Product> UpdateProduct(int id, ProductModel model) {

            var context = DbContextforServices.CreateContext();
            var currentProduct = await context.Products.FindAsync(id);

            //if (currentProduct == null) {

            //    return null;
            
            //}

            currentProduct.Name = model.Name;
            currentProduct.Price = model.Price;
            currentProduct.Category = model.Category;

            await context.SaveChangesAsync();


          
           return currentProduct;




        } 
        public async Task<Product> DeleteProduct(int id) {

            var context = DbContextforServices.CreateContext();

            var product = await context.Products.FindAsync(id);

            if (product == null) {

                return null;
            
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            //return product;
            //return wert ist eigentlich mapper??
            return product;
        }
        
    }
}

