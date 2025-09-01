using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Representa un paso (step) dentro de un SQL Job.
    /// </summary>
    public class SQLJobStep
    {
        /// <summary>
        /// Identificador del paso.
        /// </summary>
        public int StepId { get; set; }

        /// <summary>
        /// Nombre descriptivo del paso.
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// Subsystem asociado al paso (por ejemplo, Transact-SQL, CmdExec, etc.).
        /// </summary>
        public string Subsystem { get; set; }

        /// <summary>
        /// Comando o script que se ejecuta en este paso.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Nombre de la base de datos en la que se ejecuta el paso.
        /// </summary>
        public string DatabaseName { get; set; }
    }

}