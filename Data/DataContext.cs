
using Microsoft.EntityFrameworkCore;
using  ebooksItm.Models;

namespace ebooksItm.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options)
        {
            
        }
        public DbSet<Ebook> Ebooks{get; set;}
        public DbSet<User> Users{get; set;}
        public DbSet<Review> Reviews{get; set;}
    }
}