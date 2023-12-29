using Microsoft.EntityFrameworkCore;
using SparrowAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Infrastructure.Initializers
{
    internal static class CategoriesInitializer
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Політика" },
                new Category { Id = 2, Name = "Технології" },
                new Category { Id = 3, Name = "Наука" }
            );
        }
    }
}
