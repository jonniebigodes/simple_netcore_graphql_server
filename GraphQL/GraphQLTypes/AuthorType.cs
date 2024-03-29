using test_graphql_api_v2.Database;
using GraphQL.Types;

namespace test_graphql_api_v2.GraphQL.GraphQLTypes
{
    public class AuthorType:ObjectGraphType<Author>{
        public AuthorType()
        {
            Name="Author";
            Field(x => x.Id,
                  type: typeof(IdGraphType)).Description("Author's ID.");
            Field(x => x.Name).Description("The name of the Author");
            Field(x => x.Books,
                  type: typeof(ListGraphType<BookType>)).Description("Author's books");
        }
    }
}