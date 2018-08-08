using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleLogtest.Query
{
    public class QueryDemoHandler : IQueryDemoHandler
    {
        private readonly IDbConnection _connection;

        public QueryDemoHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<SearchParameter>> Handle(SearchParameter parameters)
        {
            return await new QueryDemo(_connection, parameters).Search();

        }
    }
}

