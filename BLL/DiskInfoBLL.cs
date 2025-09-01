using System;
using System.Collections.Generic;
using Domain;
using DAL.Implementations.Windows;

namespace BLL
{
    public class DiskInfoBLL
    {
        /// <summary>
        /// Obtiene la lista de discos disponibles en el sistema.
        /// </summary>
        /// <param name="serverName">Nombre del servidor a asociar.</param>
        /// <returns>Lista de objetos DiskInfo.</returns>
        public List<DiskInfo> GetDiskInfos(string serverName)
        {
            try
            {
                var diskInfos = DiskInfoDAL.GetDiskInfos();
                // Setear ServerName en cada disco
                foreach (var d in diskInfos)
                    d.ServerName = serverName;
                return diskInfos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la información de los discos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Guarda la información de los discos en la base de datos.
        /// </summary>
        /// <param name="serverName">Nombre del servidor a asociar.</param>
        public void SaveDiskInfos(string serverName)
        {
            try
            {
                // Obtiene la lista de discos y asocia el ServerName
                List<DiskInfo> diskInfos = GetDiskInfos(serverName);
                // Guarda esa información en la base de datos
                DiskInfoDAL.SaveDiskInfos(diskInfos);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la información de los discos: " + ex.Message, ex);
            }
        }
    }
}
