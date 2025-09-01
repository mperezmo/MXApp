using System;
using System.Collections.Generic;
using Domain;
using DAL.Implementations.SQLServer;
using DAL.Implementations;
using Services.DAL.Contracts;
using DAL.Contracts;  // Asegúrate de que este using existe si usas IDatabaseConnectionStrategy

namespace BLL
{
    public class InstanceBLL
    {
        /// <summary>
        /// Obtiene la información detallada de una instancia, utilizando un estrategia de conexión definida.
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia.</param>
        /// <param name="connectionStrategy">Estrategia de conexión para acceder a la instancia.</param>
        /// <returns>Objeto InstanceInfo con la información obtenida.</returns>
        public InstanceInfo GetInstanceInfo(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            // Validación de parámetros
            if (string.IsNullOrWhiteSpace(instanceName))
                throw new ArgumentException("El nombre de la instancia no puede estar vacío.", nameof(instanceName));
            if (connectionStrategy == null)
                throw new ArgumentNullException(nameof(connectionStrategy), "La estrategia de conexión no puede ser nula.");

            // Aquí podrías agregar lógica adicional de negocio si fuera necesario

            // Invocar a la capa DAL para obtener la información de la instancia.
            return InstanceDAL.GetInstanceInfo(instanceName, connectionStrategy);
        }

        /// <summary>
        /// Agrega una nueva instancia en la base de datos central.
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia a agregar.</param>
        /// <returns>Objeto Instance con los datos insertados.</returns>
        public Instance AddInstance(string instanceName)
        {
            // Validación de parámetros
            if (string.IsNullOrWhiteSpace(instanceName))
                throw new ArgumentException("El nombre de la instancia no puede estar vacío.", nameof(instanceName));

            // Aquí podrías agregar lógica adicional, como validar si la instancia ya existe,
            // aplicar reglas de negocio, o transformar datos antes de insertarlos.

            // Llamar al método de la capa DAL que inserta la instancia en la base de datos.
            return InstanceDAL.AddInstance(instanceName);
        }

        /// <summary>
        /// Recupera la lista de instancias registradas en la base de datos central.
        /// </summary>
        /// <returns>Lista de objetos Instance.</returns>
        public List<Instance> GetInstances()
        {
            // Se puede agregar lógica adicional de negocio, por ejemplo, filtrar o transformar datos.
            return InstanceDAL.GetInstances();
        }
    }
}
