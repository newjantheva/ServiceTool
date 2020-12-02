using ServiceTool.Data;
using ServiceTool.Models;
using System;
using System.Linq;

namespace ServiceTool
{
    class Program
    {
        static void Main(string[] args)
        {
            using DatabaseContext context = new DatabaseContext();

            var squeakyBone = context.Products
                                      .Where(p => p.Name == "Squeaky Dog Bone")
                                      .FirstOrDefault();

            if (squeakyBone is Product)
            {
                squeakyBone.Price = 7.99m;

                //Delete
                //context.Remove(squeakyBone);
            }
            context.SaveChanges();

            Get(context);
        }

        private static void Get(DatabaseContext context)
        {
            //FluentApi 
            //var products = context.Products
            //    .Where(p => p.Price >= 5.00m)
            //    .OrderBy(p => p.Name);

            //LINQ
            var products = from product in context.Products
                           where product.Price > 5.00m
                           orderby product.Name
                           select product;

            foreach (Product product in products)
            {
                Console.WriteLine($"Id: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine(new string('-', 20));
            }
        }

        private static void Save(DatabaseContext context)
        {
            Product squeakyBone = new Product()
            {
                Name = "Squeaky Dog Bone",
                Price = 4.99M
            };

            context.Products.Add(squeakyBone);

            Product tennisBalls = new Product()
            {
                Name = "Tennis Ball 3-Pack",
                Price = 9.99M
            };

            context.Add(tennisBalls);

            context.SaveChanges();
        }
    }
}
