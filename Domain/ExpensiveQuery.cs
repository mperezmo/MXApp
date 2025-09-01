using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Archivo: Domain/ExpensiveQuery.cs
namespace Domain
{
    public class ExpensiveQuery
    {
        public decimal CPUTime { get; set; }
        public decimal LogicalReads { get; set; }
        public decimal ExecutionCount { get; set; }
        public string QueryText { get; set; }
        public string TableUsed { get; set; }
        public string DatabaseName { get; set; } // Nueva propiedad
    }
}

