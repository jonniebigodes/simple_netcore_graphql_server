using GraphQL;
using GraphQL.Types;
using System;
using System.Linq;
using test_graphql_api_v2.Database;
using test_graphql_api_v2.GraphQL.GraphQLTypes;

namespace test_graphql_api_v2.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(ApplicationDbContext db)
        {
            #region createMutations
            Field<AuthorType>(
               "createAuthor",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
               resolve: context =>
               {
                   var authordata = context.GetArgument<Author>("author");
                   db.Authors.Add(authordata);
                   db.SaveChanges();
                   return authordata;
               }
           );
            Field<BookType>(
                "createBook",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookInputType>> { Name = "book" }),
                resolve: context =>
                 {
                     var bookdata = context.GetArgument<Book>("book");
                     db.Books.Add(bookdata);
                     db.SaveChanges();
                     return bookdata;
                 }
            );
            #endregion

            #region deleteMutations
            Field<StringGraphType>(
                "deleteAuthor",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "authorId" }),
                resolve: context =>
                 {
                     var id = context.GetArgument<int>("authorId");
                     var author = db.Authors.FirstOrDefault(i => i.Id == id);
                     if (author == null)
                     {
                         context.Errors.Add(new ExecutionError("Couldn't find author in db."));
                         return null;
                     }
                     db.Authors.Remove(author);
                     db.SaveChanges();
                     return $"The author with the id: {id} has been successfully deleted from db.";

                 }
            );
            Field<StringGraphType>(
                "deleteBook",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "bookId" }),
                resolve:context=>
                {
                    var bookid = context.GetArgument<Guid>("bookId"); 
                    var book= db.Books.FirstOrDefault(x=>x.Id==bookid.ToString());
                    if (book==null){
                        context.Errors.Add(new ExecutionError("Couldn't find book in db."));
                        return null;
                    }
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return $"The book with the id: {bookid} has been successfully deleted from db.";
                }
            );
            #endregion

            #region UpdateMutations
            Field<AuthorType>(
                "updateAuthor",
                arguments:new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>>{Name="author"},
                    new QueryArgument<NonNullGraphType<IdGraphType>>{Name="authorId"}
                ),
                resolve:context=>
                {
                    var tmpAuthorData= context.GetArgument<Author>("author");
                    var idauthor = context.GetArgument<int>("authorId");
                    var author = db.Authors.FirstOrDefault(i => i.Id == idauthor);
                    if (author==null){
                        context.Errors.Add(new ExecutionError("Couldn't find author in db."));
                        return null;
                    }
                    author.Name=tmpAuthorData.Name;
                    db.Authors.Update(author);
                    db.SaveChanges();
                    return author;
                }
            );
            Field<BookType>(
                "updateBook",
                arguments:new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookInputType>>{ Name = "book"},
                    new QueryArgument<NonNullGraphType<IdGraphType>>{Name="bookId"}
                ),
                resolve:context=>
                {
                    var tmpBookdata= context.GetArgument<Book>("book");
                    var bookid = context.GetArgument<Guid>("bookId"); 
                    var tmpBook= db.Books.FirstOrDefault(i=>i.Id==bookid.ToString());
                    if (tmpBook==null){
                        context.Errors.Add(new ExecutionError("Couldn't find book in db."));
                        return null;
                    }
                    tmpBook.Published= tmpBookdata.Published;
                    tmpBook.Name= tmpBookdata.Name;
                    tmpBook.Genre= tmpBookdata.Genre;
                    tmpBook.AuthorId= tmpBookdata.AuthorId;
                    db.Books.Update(tmpBook);
                    db.SaveChanges();
                    return tmpBook;

                }
            );
            #endregion
        }
    }
}