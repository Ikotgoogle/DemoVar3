using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoVar3.Model {
    public class MyContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FavouriteList> Favorites { get; set; }
        public DbSet<BooksInOrder> BooksInOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DemoVar3DB1;TrustServerCertificate=True;Trusted_Connection=True;");
        }
    }
}
