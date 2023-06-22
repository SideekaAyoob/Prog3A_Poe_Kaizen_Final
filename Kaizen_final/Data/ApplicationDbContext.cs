using Kaizen_final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaizen_final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Tea> Teas { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //base.OnModelCreating(modelbuilder);
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Farmer>().HasData(new Farmer { farmerId = 1, farmerName = "Jhon", farmerEmail = "jhon@gmail.com", farmerPhoneNumber = "1234567890" });
            modelbuilder.Entity<Farmer>().HasData(new Farmer { farmerId = 2, farmerName = "tyreece", farmerEmail = "Tyreece@gmail.com", farmerPhoneNumber = "1234567899" });
            modelbuilder.Entity<Farmer>().HasData(new Farmer { farmerId = 3, farmerName = "Hella", farmerEmail = "Hella@gmail.com", farmerPhoneNumber = "1234567888" });

            modelbuilder.Entity<Tea>().HasData(
                new Tea
                {
                    TeaId = 1,
                    TeaName = "Sencha",
                    TeaDescription = "Simple Green tea",
                    Price = 50.99M,
                    Tea_Stock = 15,
                    picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup01.png",
                    farmerid = 1

                });
            modelbuilder.Entity<Tea>().HasData(
                new Tea
                {
                    TeaId = 2,
                    TeaName = "Fukamushi Sencha",
                    TeaDescription = " steamed approximately twice as long as regular Sencha",
                    Price = 55.99M,
                    Tea_Stock = 10,
                    picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup02.png",
                    farmerid = 3
                });
            modelbuilder.Entity<Tea>().HasData(
                new Tea
                {
                    TeaId = 3,
                    TeaName = "Gyokuro",
                    TeaDescription = "covered culture for approximately 20 days prior to picking.",
                    Price = 60.99M,

                    Tea_Stock = 10,
                    picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup03.png",
                    farmerid = 1
                });
            modelbuilder.Entity<Tea>().HasData(
               new Tea
               {
                   TeaId = 4,
                   TeaName = "Kabusecha",
                   TeaDescription = "reed screen or cloth placed over them to block out most sunlight.",
                   Price = 60.99M,

                   Tea_Stock = 20,
                   picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup04.png",

                   farmerid = 2
               });
            modelbuilder.Entity<Tea>().HasData(
              new Tea
              {
                  //    TeaId = 5,
                  //    TeaName = "Matcha",
                  //    TeaDescription = "Tencha that is stoneground immediately before shipping",
                  //    Price = 70.99M,
                  //    Tea_Stock = 20,
                  //    picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup05.png",
                  //    farmerid = 3
                  TeaId = 5,
                  TeaName = "Matcha",
                  TeaDescription = "Tencha that is stoneground immediately before shipping",
                  Price = 70.99M,
                  Tea_Stock = 20,
                  picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup05.png",
                  farmerid = 3
              });

            modelbuilder.Entity<Tea>().HasData(
             new Tea
             {
                 TeaId = 6,
                 TeaName = "Tencha",
                 TeaDescription = "Screen Culture but after steaming, the leaves are dried without being rolled",
                 Price = 70.99M,

                 Tea_Stock = 20,
                 picURL = "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup06.png",

                 farmerid = 2
             });

        }//end method

    }
}
