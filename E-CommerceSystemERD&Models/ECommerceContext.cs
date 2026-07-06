using E_CommerceSystemERD_Models.modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace E_CommerceSystemERD_Models
{
    public class    ECommerceContext : DbContext

    {

        public DbSet<User> users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category>  categories{  get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }







    }
}
