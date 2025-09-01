using Services.DAL.FactoryServices;
using Services.Domain;
using Services.DTO;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public static class UserService
    {
        private static UserLogic _userLogic = new UserLogic();

        public static bool Login(string username, string password)
        {
            return _userLogic.ValidateUser(username, password);
        }

        public static void Register(string username, string password)
        {
            var usuario = new Usuario
            {
                UserName = username,
            };
            _userLogic.CreateUser(usuario, password);
        }
        public static void CreatePatente(Patente patente)
        {
            _userLogic.CreatePatente(patente);
        }

        public static void DisableUser(Guid idUsuario)
        {
            _userLogic.DisableUser(idUsuario);
        }

        public static void EnabledUsuario(Guid idUsuario)
        {
            _userLogic.EnabledUsuario(idUsuario);
        }

        public static void UpdateUserAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            _userLogic.UpdateUserAccesos(idUsuario, accesos);
        }

        public static List<Usuario> GetAllUsuarios()
        {
            return _userLogic.GetAllUsuarios();
        }

        public static Usuario GetUsuarioByUsername(string username)
        {
            return _userLogic.GetUsuarioByUsername(username);
        }

        public static List<UsuarioFamiliaDTO> GetUsuariosConFamilias()
        {
            return _userLogic.GetUsuariosConFamilias();
        }

        public static void StartPasswordRecovery(string username)
        {
            _userLogic.StartPasswordRecovery(username);
        }

        /*public static bool ValidateOTP(string username, string otp)
        {
            return _userLogic.ValidateOTP(username, otp);
        }
        */
        public static void RemoveUser(Guid userId)
        {
            var repository = FactoryDAL.UsuarioRepository;
            repository.RemoveUsuario(userId); // Ajustar para llamar al nuevo nombre
        }

        public static void ChangePassword(string username, string newPassword)
        {
            _userLogic.ChangePassword(username, newPassword);
        }
    }
}
