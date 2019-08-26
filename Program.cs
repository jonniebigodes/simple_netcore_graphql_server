using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using test_graphql_api_v2.Database;
namespace test_graphql_api_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            IWebHost host = CreateWebHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var authorDbEntry = context.Authors.Add(new Author
                    {
                        Name = "First Author",
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        Name = "First Book",
                        Published = true,
                        AuthorId = authorDbEntry.Entity.Id,
                        Genre = "Mystery"
                    },
                    new Book
                    {
                        Name = "Second Book",
                        Published = true,
                        AuthorId = authorDbEntry.Entity.Id,
                        Genre = "Crime"
                    }
                );
                context.SaveChanges();
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
