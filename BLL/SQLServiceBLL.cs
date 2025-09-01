// Archivo: BLL/SQLServiceBLL.cs
using System;
using System.Collections.Generic;
using Domain;
using DAL.Implementations.Windows;

namespace BLL
{
    public class SQLServiceBLL
    {
        /// <summary>
        /// Retorna la lista de servicios de SQL Server usando la DAL.
        /// </summary>
        /// <returns>Lista de objetos SQLServiceInfo.</returns>
        public List<SQLServiceInfo> GetSQLServices()
        {
            try
            {
                return SQLServiceDAL.GetSQLServices();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los servicios de SQL Server: " + ex.Message, ex);
            }
        }

        public void SaveSQLServiceInfo()
        {
            try
            {
                // Primero, obtiene la lista de discos
                List<SQLServiceInfo> sqlService = SQLServiceDAL.GetSQLServices();
                // Luego, guarda esa información en la base de datos
                SQLServiceDAL.SaveSQLServiceInfo(sqlService);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la información de los discos: " + ex.Message, ex);
            }
        }
    }
}
