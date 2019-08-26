using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace test_graphql_api_v2.Database
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tmpListBooks = new List<Book>();
            tmpListBooks.Add(new Book
            {
                Id= Guid.NewGuid().ToString(),
                Name = "First Book",
                Published = true,
                AuthorId = 1,
                Genre = "Mystery"
            });
            tmpListBooks.Add(new Book
            {
                Id= Guid.NewGuid().ToString(),
                Name = "Second Book",
                Published = true,
                AuthorId = 1,
                Genre = "Crime"
            });
            modelBuilder.Entity<Author>().HasData(
               new Author
               {
                   Name = "First Author",
                   Id = 1
               }
            );
            modelBuilder.Entity<Book>().HasData(tmpListBooks);
        } */

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}