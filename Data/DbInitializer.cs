using ECommercePlatform.Models.Entities;

namespace ECommercePlatform.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ECommerceDbContext context)
        {
            // ایجاد دیتابیس اگر وجود نداشته باشد
            context.Database.EnsureCreated();

            // بررسی وجود داده‌های اولیه
            if (context.Categories.Any() || context.Products.Any() || context.Customers.Any())
            {
                return; // دیتابیس قبلاً seed شده است
            }

            // ایجاد دسته‌بندی‌ها
            var categories = new Category[]
            {
                new Category { Id = Guid.NewGuid(), Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = Guid.NewGuid(), Name = "Clothing", Description = "Fashion and apparel" },
                new Category { Id = Guid.NewGuid(), Name = "Books", Description = "Books and literature" },
                new Category { Id = Guid.NewGuid(), Name = "Home & Kitchen", Description = "Home appliances and kitchenware" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // ایجاد محصولات
            var products = new Product[]
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop Pro 15\"",
                    Description = "High-performance laptop with SSD",
                    Price = 1299.99m,
                    StockQuantity = 15,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone X",
                    Description = "Latest smartphone with 5G",
                    Price = 899.99m,
                    StockQuantity = 30,
                    CategoryId = categories.First(c => c.Name == "Electronics").Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cotton T-Shirt",
                    Description = "Comfortable cotton t-shirt",
                    Price = 19.99m,
                    StockQuantity = 50,
                    CategoryId = categories.First(c => c.Name == "Clothing").Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jeans",
                    Description = "Classic blue jeans",
                    Price = 49.99m,
                    StockQuantity = 25,
                    CategoryId = categories.First(c => c.Name == "Clothing").Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "C# Programming Guide",
                    Description = "Complete guide to C# programming",
                    Price = 39.99m,
                    StockQuantity = 20,
                    CategoryId = categories.First(c => c.Name == "Books").Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Coffee Maker",
                    Description = "Automatic coffee maker",
                    Price = 79.99m,
                    StockQuantity = 10,
                    CategoryId = categories.First(c => c.Name == "Home & Kitchen").Id
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            // ایجاد مشتریان
            var customers = new Customer[]
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890",
                    Address = "123 Main St, City"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Phone = "987-654-3210",
                    Address = "456 Oak Ave, Town"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    Phone = "555-123-4567",
                    Address = "789 Pine Rd, Village"
                }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            // ایجاد تصاویر برای محصولات (نمونه)
            var productImages = new ProductImage[]
            {
                new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ImagePath = "Products/laptop.jpg",
                    ProductId = products.First(p => p.Name == "Laptop Pro 15\"").Id
                },
                new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ImagePath = "Products/smartphone.jpg",
                    ProductId = products.First(p => p.Name == "Smartphone X").Id
                },
                new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ImagePath = "Products/tshirt.jpg",
                    ProductId = products.First(p => p.Name == "Cotton T-Shirt").Id
                }
            };
            context.ProductImages.AddRange(productImages);
            context.SaveChanges();
        }
    }
}