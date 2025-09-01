using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Representa un SQL Job (trabajo) en el sistema.
    /// </summary>
    public class SQLJob
    {
        /// <summary>
        /// Identificador único del job.
        /// </summary>
        public Guid JobId { get; set; }

        /// <summary>
        /// Nombre del job.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indica si el job está habilitado.
        /// </summary>
        public bool Enabled { get; set; }
    }
}