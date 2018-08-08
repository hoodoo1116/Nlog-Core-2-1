using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleLogtest.Query
{
    public interface IQueryDemoHandler
    {
        Task<List<SearchParameter>> Handle(SearchParameter parameters);
    }
}
