using GraphQL.Types;

namespace test_graphql_api_v2.GraphQL.GraphQLTypes
{
    public class AuthorInputType:InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name="authorInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
        }
    }
}