using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ConsoleLogtest.Query
{
    public class QueryDemo
    {

        private const string PrimaryQueryString = "select * from [udf_DemotableSearch](@Id, @DateOf, @value)" +
                         "OPTION (RECOMPILE)";

        private readonly IDbConnection _connection;
        private readonly SearchParameter _parameters;

        public QueryDemo(IDbConnection connection, SearchParameter parameters)
        {
            _connection = connection;
            _parameters = parameters;
        }

        public async Task<List<SearchParameter>> Search()
        {
            var result = (await _connection.QueryAsync<SearchParameter>(PrimaryQueryString, _parameters)).AsList();
 
            return result;
        }
    }
}
