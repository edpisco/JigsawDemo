using System.Collections.Generic;
using Jigsaw.MiniProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Jigsaw.MiniProject.Data
{
    public class DbConfiguration
    {
        public static void ConfigureEntities(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<TreeItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TreeItem>().HasMany(x => x.Children).WithOne(x => x.Parent);

            modelBuilder.Entity<TreeItem>().HasData(new TreeItem
            {
                Id = 1,
                ParentId = null,
                Parent = null,
                Name = "A"
            });


            modelBuilder.Entity<TreeItem>().HasData(new TreeItem
            {
                Id = 2,
                ParentId = 1,
                Name = "B",
            });


            modelBuilder.Entity<TreeItem>().HasData(new TreeItem
            {
                Id = 3,
                ParentId = 2,
                Name = "C",
            });

            modelBuilder.Entity<TreeItem>().HasData(new TreeItem
            {
                Id = 4,
                ParentId = 1,
                Name = "d",
            });
        }
    }
}