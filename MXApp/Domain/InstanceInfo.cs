using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InstanceInfo
    {
        public DateTime LastStartTime { get; set; }
        public int SQLServerMemoryMB { get; set; }
        public string DataPath { get; set; }
        public string LogPath { get; set; }
        public string BackupPath { get; set; }
        public string SQLEdition { get; set; }
        public string SQLBuild { get; set; }

        public List<BackupInfo> BackupHistory { get; set; }
    }

    public class BackupInfo
    {
        public string DatabaseName { get; set; }
        public DateTime BackupStartDate { get; set; }
        public DateTime BackupFinishDate { get; set; }
        public string BackupType { get; set; }
        public decimal BackupSizeMB { get; set; }
        public string BackupFileLocation { get; set; }
    }
}
