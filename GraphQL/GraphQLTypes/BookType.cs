using test_graphql_api_v2.Database;
using GraphQL.Types;

namespace test_graphql_api_v2.GraphQL.GraphQLTypes
{
    public class BookType:ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";
            Field(x => x.Id,
                  type: typeof(IdGraphType)).Description("The ID of the Book.");
            Field(x => x.Name).Description("The name of the Book");
            Field(x => x.Genre).Description("Book genre");
            Field(x => x.Published).Description("If the book is published or not");
        }
    }
}