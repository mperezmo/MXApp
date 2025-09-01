using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Domain
{
    public class SQLJobSchedule
    {
        /// <summary>
        /// Nombre del schedule del job.
        /// </summary>
        public string ScheduleName { get; set; }

        /// <summary>
        /// Estado del schedule (por ejemplo, "Habilitado" o "Deshabilitado").
        /// </summary>
        public string EstadoSchedule { get; set; }

        /// <summary>
        /// Tipo de frecuencia del schedule (por ejemplo, "Diario", "Semanal", etc.).
        /// </summary>
        public string Frecuencia { get; set; }

        /// <summary>
        /// Descripción del intervalo de frecuencia (por ejemplo, "Cada 2 día(s)" o "Martes Miércoles").
        /// </summary>
        public string IntervaloFrecuencia { get; set; }

        /// <summary>
        /// Tipo de subdía, que indica la unidad para la repetición dentro del día (por ejemplo, "Horas").
        /// </summary>
        public string TipoSubdia { get; set; }

        /// <summary>
        /// Intervalo en la unidad especificada por TipoSubdia (por ejemplo, cada N horas).
        /// </summary>
        public int IntervaloSubdia { get; set; }

        /// <summary>
        /// Hora de inicio del schedule en formato hh:mm:ss.
        /// </summary>
        public string HoraInicio { get; set; }

        /// <summary>
        /// Hora de fin del schedule en formato hh:mm:ss.
        /// </summary>
        public string HoraFin { get; set; }
    }
}
