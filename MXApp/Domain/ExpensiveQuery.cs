using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExpensiveQuery
    {
        public string QueryText { get; set; }
        public decimal CPUTime { get; set; }
        public decimal LogicalReads { get; set; }
        public decimal ExecutionCount { get; set; }
        public string AffectedTables { get; set; }
        public string ExecutionPlan { get; set; }
    }
}
