using Microsoft.EntityFrameworkCore;
using System;

namespace GALTest.Models
{
    public static class DbInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.Migrate();

            if (!context.Suppliers.Any())
            {
                var suppliers = new[]
                {
                new Supplier { Name = "ТрансТехСервис", CreatedAt = DateTime.Now.AddDays(-10) },
                new Supplier { Name = "КАН Авто", CreatedAt = DateTime.Now.AddDays(-8) },
                new Supplier { Name = "КИА Сервис", CreatedAt = DateTime.Now.AddDays(-6) },
                new Supplier { Name = "Ключавто", CreatedAt = DateTime.Now.AddDays(-4) },
                new Supplier { Name = "Тайота Сервис", CreatedAt = DateTime.Now.AddDays(-2) },
            };

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();
            }

            if (!context.Offers.Any())
            {
                var offers = new List<Offer>
                {
                    new() { Brand = "Ford", Model = "Focus", SupplierId = 1, RegisteredAt = DateTime.Now.AddDays(-7) },
                    new() { Brand = "Ford", Model = "Mondeo", SupplierId = 1, RegisteredAt = DateTime.Now.AddDays(-8) },
                    new() { Brand = "BMW", Model = "X5", SupplierId = 2, RegisteredAt = DateTime.Now.AddDays(-3) },
                    new() { Brand = "BMW", Model = "X3", SupplierId = 2, RegisteredAt = DateTime.Now.AddDays(-4) },
                    new() { Brand = "BMW", Model = "5", SupplierId = 2, RegisteredAt = DateTime.Now.AddDays(-4) },
                    new() { Brand = "Audi", Model = "A4", SupplierId = 2, RegisteredAt = DateTime.Now.AddDays(-5) },
                    new() { Brand = "Kia", Model = "Rio", SupplierId = 3, RegisteredAt = DateTime.Now.AddDays(-9) },
                    new() { Brand = "Kia", Model = "Sportage", SupplierId = 3, RegisteredAt = DateTime.Now.AddDays(-10) },
                    new() { Brand = "Kia", Model = "K5", SupplierId =3, RegisteredAt = DateTime.Now.AddDays(-10) },
                    new() { Brand = "Hyundai", Model = "Elantra", SupplierId = 4, RegisteredAt = DateTime.Now.AddDays(-11) },
                    new() { Brand = "Hyundai", Model = "Sonata", SupplierId = 4, RegisteredAt = DateTime.Now.AddDays(-12) },
                    new() { Brand = "Toyota", Model = "Camry", SupplierId = 5, RegisteredAt = DateTime.Now.AddDays(-1) },
                    new() { Brand = "Toyota", Model = "Corolla", SupplierId = 5, RegisteredAt = DateTime.Now.AddDays(-2) },
                    new() { Brand = "Toyota", Model = "Rav 4", SupplierId = 5, RegisteredAt = DateTime.Now.AddDays(-2) },
                    new() { Brand = "Toyota", Model = "Venza", SupplierId = 5, RegisteredAt = DateTime.Now.AddDays(-2) },
                };

                context.Offers.AddRange(offers);
                context.SaveChanges();
            }
        }
    }

}
