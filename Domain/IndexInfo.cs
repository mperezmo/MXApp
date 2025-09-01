using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;

namespace Domain
{
    public class IndexInfo
    {
        /// <summary>
        /// Nombre del índice.
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// Descripción del índice (por ejemplo, si es único, clusterizado, etc.).
        /// </summary>
        public string IndexDescription { get; set; }

        /// <summary>
        /// Columnas que forman parte del índice.
        /// </summary>
        public string Keys { get; set; }
    }
}
