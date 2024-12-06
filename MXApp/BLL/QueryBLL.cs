using DAL;
using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QueryBLL
    {
        private readonly PerformanceRepository _performanceRepository;

        public QueryBLL(IDatabaseConnectionStrategy connectionString)
        {
            _performanceRepository = new PerformanceRepository(connectionString);

        }

        public List<ExpensiveQuery> GetTopExpensiveQueries(string instanceName)
        {
            return _performanceRepository.GetTopExpensiveQueries(instanceName);
        }
    }
}
