using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public static class PerformanceService
    {
        public static List<ExpensiveQuery> GetTopExpensiveQueries(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            var queryBLL = new QueryBLL(connectionStrategy);
            return queryBLL.GetTopExpensiveQueries(instanceName);
        }
    }
}
