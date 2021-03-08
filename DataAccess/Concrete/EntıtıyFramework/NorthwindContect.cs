using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntıtıyFramework
{ //context Db tabloları ıle proje class larını bağlama
    public class NorthwindContect:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {// Ters slaç strıng ıcınde bıle farklı algılandığı ıcın önüne @ konur
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            //worthoul method, bu method hangı verı tabanıyla ılışkılı onu belırtıcez
            //sql keys unsensensıtıve
            //postgıre key sensıtıve
            //RDBMS den RDBMS e göre değışır
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
