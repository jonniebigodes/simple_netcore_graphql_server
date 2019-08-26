using GraphQL;
using GraphQL.Types;
using test_graphql_api_v2.GraphQL.GraphQLQueries;
namespace test_graphql_api_v2.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}