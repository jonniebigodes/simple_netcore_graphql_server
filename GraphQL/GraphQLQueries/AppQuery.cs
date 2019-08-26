using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using test_graphql_api_v2.Database;
using test_graphql_api_v2.GraphQL.GraphQLTypes;

namespace test_graphql_api_v2.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(ApplicationDbContext db)
        {
            Field<AuthorType>(
                "Author",
                arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The ID of the Author." }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var author = db.Authors.Include(a => a.Books)
                                           .FirstOrDefault(i => i.Id == id);
                    return author;
                }
            );

            Field<ListGraphType<AuthorType>>(
              "Authors",
              resolve: context =>
              {
                  /* var authors = db.Authors.Include(a => a.Books);
                  return authors; */
                  return db.Authors.Include(a => a.Books);
              });

            Field<BookType>(
              "Book",
              arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "The Book id" }),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");
                  var Book = db.Books.FirstOrDefault(i => i.Id == id);
                  return Book;
              }
          );
            Field<ListGraphType<BookType>>(
                "Books",
                resolve: context =>
                 {
                     return db.Books.ToList();
                 }
            );
        }
    }
}