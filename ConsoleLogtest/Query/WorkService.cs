using System;
using System.Collections.Generic;

namespace ConsoleLogtest.Query
{
    public class WorkService
    {
        private readonly IQueryDemoHandler _handler;
        public WorkService(IQueryDemoHandler handler)
        {
            _handler = handler;
        }

        public List<SearchParameter> Work()
        {
            return _handler.Handle(new SearchParameter { Id = 1, DateOf = new DateTime(1901, 1, 1, 1, 1, 1, 1), value = "junk" }).Result;

        }
    }
}
