using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Implementations.SQLServer.AppConfiguration
{
    public class AppConfigDAL
    {
        /// <summary>
        /// Despliega la configuración completa de la aplicación:
        /// 1. Crea la base de datos MonitorXpressApp si no existe.
        /// 2. Crea las tablas necesarias.
        /// 3. Inserta los datos iniciales, incluyendo el INSERT en la tabla Usuarios,
        ///    usando el nombre y contraseña proporcionados para el usuario Admin.
        /// Además, actualiza las cadenas de conexión "MainConString" y "SecondConString"
        /// en el App.config usando el servidor especificado.
        /// </summary>
        /// <param name="adminUsername">Nombre del usuario Admin.</param>
        /// <param name="adminPassword">Contraseña para el usuario Admin.</param>
        /// <param name="instanceName">Nombre del servidor de SQL declarado en el txtInstanceName.</param>
        public static void DeployConfiguration(string instanceName)
        {
            // Construir la nueva cadena de conexión basada en el servidor ingresado.
            // Se asume que se utilizará la base de datos "master" para ejecutar el script de configuración.
            string newMainConnectionString = $"Server={instanceName};Database=MonitorXpressApp;Integrated Security=True;";
            string newSecondConnectionString = $"Server={instanceName};Database=master;Integrated Security=True;";

            // Actualizar las cadenas de conexión en el App.config
            UpdateConnectionString("MainConString", newMainConnectionString);
            UpdateConnectionString("SecondConString", newSecondConnectionString);

            // Construir el script T-SQL para desplegar la configuración
            string script = $@"
-- 1. Validar y crear la base de datos MonitorXpressApp
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'MonitorXpressApp')
BEGIN
    CREATE DATABASE [MonitorXpressApp];
END;
GO

USE [MonitorXpressApp];
GO

-- 2. Crear las tablas necesarias

CREATE TABLE Usuario (
    IdUsuario UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    UserName NVARCHAR(100) NOT NULL,
    Password NVARCHAR(256) NOT NULL,
    Estado INT NOT NULL,
    PhoneNumber NVARCHAR(50) NULL,
    OTP NVARCHAR(10) NULL,
    OTPExpiry DATETIME NULL
);
GO

CREATE TABLE Patente (
    IdPatente UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    Nombre NVARCHAR(100) NOT NULL,
    DataKey NVARCHAR(100) NOT NULL,
    TipoAcceso INT NOT NULL
);
GO

CREATE TABLE Familia (
    IdFamilia UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL
);
GO

CREATE TABLE Usuario_Familia (
    IdUsuario UNIQUEIDENTIFIER NOT NULL,
    IdFamilia UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (IdUsuario, IdFamilia),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdFamilia) REFERENCES Familia(IdFamilia)
);
GO

CREATE TABLE Familia_Patente (
    IdFamilia UNIQUEIDENTIFIER NOT NULL,
    IdPatente UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (IdFamilia, IdPatente),
    FOREIGN KEY (IdFamilia) REFERENCES Familia(IdFamilia),
    FOREIGN KEY (IdPatente) REFERENCES Patente(IdPatente)
);
GO

-- 3. Insertar datos iniciales

INSERT INTO Familia (Nombre, Descripcion)
VALUES ('Admin', 'Acceso completo a la aplicación'),
       ('ReadOnly', 'Solo permite consultar información');
GO

INSERT INTO Patente (Nombre, DataKey, TipoAcceso)
VALUES ('CrearUsuario', 'CrearUsuario', 1),
       ('ModificarUsuario', 'ModificarUsuario', 1),
       ('EliminarUsuario', 'EliminarUsuario', 1),
       ('ConsultarDatos', 'ConsultarDatos', 2);
GO

-- 4. Insertar el usuario Admin usando parámetros

-- 5. Asignar el rol Admin al usuario creado

DECLARE @AdminFamiliaId UNIQUEIDENTIFIER;
SELECT @AdminFamiliaId = IdFamilia FROM Familia WHERE Nombre = 'Admin';


-- 6. Asignar patentes al rol Admin
DECLARE @CrearUsuarioId UNIQUEIDENTIFIER;
DECLARE @ModificarUsuarioId UNIQUEIDENTIFIER;
DECLARE @EliminarUsuarioId UNIQUEIDENTIFIER;
DECLARE @ConsultarDatosId UNIQUEIDENTIFIER;

SELECT @CrearUsuarioId = IdPatente FROM Patente WHERE Nombre = 'CrearUsuario';
SELECT @ModificarUsuarioId = IdPatente FROM Patente WHERE Nombre = 'ModificarUsuario';
SELECT @EliminarUsuarioId = IdPatente FROM Patente WHERE Nombre = 'EliminarUsuario';
SELECT @ConsultarDatosId = IdPatente FROM Patente WHERE Nombre = 'ConsultarDatos';

IF @AdminFamiliaId IS NOT NULL
BEGIN
    INSERT INTO Familia_Patente (IdFamilia, IdPatente)
    VALUES (@AdminFamiliaId, @CrearUsuarioId),
           (@AdminFamiliaId, @ModificarUsuarioId),
           (@AdminFamiliaId, @EliminarUsuarioId),
           (@AdminFamiliaId, @ConsultarDatosId);
END;
GO
";

            // Dividir el script en comandos usando "GO" como separador
            string[] commands = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

            // Ejecutar cada comando usando la nueva cadena de conexión
            using (SqlConnection conn = new SqlConnection(newSecondConnectionString))
            {
                conn.Open();
                foreach (string commandText in commands)
                {
                    string trimmedCommand = commandText.Trim();
                    if (!string.IsNullOrWhiteSpace(trimmedCommand))
                    {
                        using (SqlCommand cmd = new SqlCommand(trimmedCommand, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Actualiza o agrega una cadena de conexión en el App.config para la llave especificada.
        /// </summary>
        /// <param name="name">El nombre de la cadena de conexión (por ejemplo, "MainConString").</param>
        /// <param name="newConnectionString">La nueva cadena de conexión a establecer.</param>
        public static void UpdateConnectionString(string name, string newConnectionString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.ConnectionStrings.ConnectionStrings[name] != null)
            {
                config.ConnectionStrings.ConnectionStrings[name].ConnectionString = newConnectionString;
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, newConnectionString));
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
