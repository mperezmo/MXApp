using System;
using System.ComponentModel;

namespace Domain
{
    public class DiskInfo
    {
        /// <summary>
        /// Nombre del servidor (por ejemplo, "LOCALHOST").
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Nombre de la unidad (por ejemplo, "C:\").
        /// </summary>
        public string DriveName { get; set; }

        /// <summary>
        /// Espacio total de la unidad en bytes.
        /// </summary>
        [Browsable(false)]
        public long TotalSize { get; set; }

        /// <summary>
        /// Espacio libre en la unidad en bytes.
        /// </summary>
        [Browsable(false)]
        public long FreeSpace { get; set; }

        /// <summary>
        /// Espacio total en gigabytes (calculado a partir de TotalSize).
        /// </summary>
        public double TotalSizeInGB
        {
            get { return Math.Round((double)TotalSize / (1024 * 1024 * 1024), 2); }
        }

        /// <summary>
        /// Espacio libre en gigabytes (calculado a partir de FreeSpace).
        /// </summary>
        public double FreeSpaceInGB
        {
            get { return Math.Round((double)FreeSpace / (1024 * 1024 * 1024), 2); }
        }

        /// <summary>
        /// Porcentaje de espacio libre en la unidad.
        /// </summary>
        public double FreeSpacePercentage
        {
            get { return TotalSize > 0 ? Math.Round((double)FreeSpace / TotalSize * 100, 2) : 0; }
        }
    }
}
