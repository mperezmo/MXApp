using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade.Extensions
{
    public class BackUpService
    {
        public static void RealizarBackupDeTodoElSistema()
        {
            BackUpLogic backUp = new BackUpLogic();
            backUp.RealizarBackupDeTodasLasBases();





        }
    }
}
