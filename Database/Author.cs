using System.Collections.Generic;

namespace test_graphql_api_v2.Database
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}