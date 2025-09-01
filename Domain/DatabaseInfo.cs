using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DatabaseInfo
    {
        public string DatabaseName { get; set; }
        public string DatabaseStatus { get; set; }
        public decimal SizeMB { get; set; } // Unifica 'DBSizeMB' y 'SizeMB'
        public string RecoveryModel { get; set; } // Unifica 'DBRecoveryModel' y 'RecoveryModel'
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string LastFullBackup { get; set; }
        public string LastLogBackup { get; set; }


    }

}
