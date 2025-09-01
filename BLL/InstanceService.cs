using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;

namespace BLL
{
    public static class InstanceService
    {
        public static InstanceInfo TestInstance(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            if (string.IsNullOrEmpty(instanceName))
                throw new ArgumentException("El nombre de la instancia no puede estar vacío.");

            // Llamar a la capa DAL con la estrategia seleccionada
            return InstanceDAL.GetInstanceInfo(instanceName, connectionStrategy);
        }
    }
}
