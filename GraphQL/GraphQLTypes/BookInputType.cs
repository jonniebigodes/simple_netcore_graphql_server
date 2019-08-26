using GraphQL.Types;

namespace test_graphql_api_v2.GraphQL.GraphQLTypes
{
    public class BookInputType:InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "bookInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<BooleanGraphType>>("Published");
            Field<NonNullGraphType<StringGraphType>>("Genre");
            Field<NonNullGraphType<IntGraphType>>("AuthorID");

        }
    }
}