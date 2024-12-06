using Services.DAL.Contracts;
using Services.DAL.FactoryServices;
using Services.Domain;
using Services.DTO;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    /// <summary>
    /// Lógica para la gestión de usuarios, incluyendo autenticación, recuperación de contraseña, y manejo de accesos.
    /// </summary>
    public class UserLogic
    {
        private readonly IUsuarioDAL _usuarioRepository;
        /// <summary>
        /// Constructor que inicializa el repositorio de usuarios.
        /// </summary>
        public UserLogic()
        {
            _usuarioRepository = FactoryDAL.UsuarioRepository;
        }
        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>True si las credenciales son válidas; de lo contrario, false.</returns>
        public bool ValidateUser(string username, string password)
        {
            // Obtener el usuario por su nombre de usuario
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                // Verificar si el usuario está deshabilitado
                if (usuario.Estado == "0")
                {
                    // Usuario está deshabilitado
                    return false;
                }

                // Verificar la contraseña
                string hashedPassword = CryptographyService.HashMd5(password);
                return usuario.Password == hashedPassword;
            }
            return false;
        }

        /// <summary>
        /// Crea un nuevo usuario con la contraseña encriptada.
        /// </summary>
        /// <param name="usuario">Objeto de usuario a crear.</param>
        /// <param name="plainPassword">Contraseña en texto plano.</param>
        public void CreateUser(Usuario usuario, string plainPassword)
        {

            // Verificar si el nombre de usuario ya existe
            var existingUser = _usuarioRepository.GetUsuarioByUsername(usuario.UserName);
            if (existingUser != null)
            {
                throw new Exception($"El nombre de usuario '{usuario.UserName}' ya está en uso.");


            }

            usuario.Password = CryptographyService.HashMd5(plainPassword);
            _usuarioRepository.CreateUsuario(usuario);
        }
        /// <summary>
        /// Deshabilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a deshabilitar.</param>
        public void DisableUser(Guid idUsuario)
        {
            _usuarioRepository.DisableUsuario(idUsuario);
        }
        /// <summary>
        /// Habilita un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a habilitar.</param>
        public void EnabledUsuario(Guid idUsuario)
        {
            _usuarioRepository.EnabledUsuario(idUsuario);
        }
        /// <summary>
        /// Actualiza los accesos de un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <param name="accesos">Lista de accesos a asignar.</param>
        public void UpdateUserAccesos(Guid idUsuario, List<Acceso> accesos)
        {
            _usuarioRepository.UpdateAccesos(idUsuario, accesos);
        }
        /// <summary>
        /// Obtiene todos los usuarios registrados.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Usuario> GetAllUsuarios()
        {
            return _usuarioRepository.GetAll();
        }
        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <returns>Usuario encontrado o null si no existe.</returns>
        public Usuario GetUsuarioByUsername(string username)
        {
            return _usuarioRepository.GetUsuarioByUsername(username);
        }
        /// <summary>
        /// Obtiene una lista de usuarios junto con sus familias (roles).
        /// </summary>
        /// <returns>Lista de objetos <see cref="UsuarioFamiliaDTO"/>.</returns>
        public List<UsuarioFamiliaDTO> GetUsuariosConFamilias()
        {
            return _usuarioRepository.GetUsuariosConFamilias();
        }
        /// <summary>
        /// Crea una nueva patente.
        /// </summary>
        /// <param name="patente">Objeto de patente a crear.</param>
        public void CreatePatente(Patente patente)
        {
            _usuarioRepository.CreatePatente(patente);
        }
        /// <summary>
        /// Genera un código OTP de 6 dígitos.
        /// </summary>
        /// <returns>Código OTP como string.</returns>
        public string GenerateOTP()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Genera un número de 6 dígitos
        }
        /// <summary>
        /// Envía un código OTP por SMS utilizando Twilio.
        /// </summary>
        /// <param name="toPhoneNumber">Número de teléfono del destinatario.</param>
        /// <param name="otp">Código OTP a enviar.</param>
       /* public void SendOTP(string toPhoneNumber, string otp)
        {
            // Inicializar TwilioClient antes de enviar mensajes
            const string accountSid = "AC7ef731291387bfa2fb17b4c5ee40865d";  // Reemplazar con tu Account SID
            const string authToken = "52ce8773238e0dbcb3a2ae97192a9dd6";     // Reemplazar con tu Auth Token
            TwilioClient.Init(accountSid, authToken);

            try
            {
                // formato E.164
                string formattedPhoneNumber = $"+54{toPhoneNumber}";  // Agrega el código de país si es Argentina

                var message = MessageResource.Create(
                    body: $"Tu código de verificación es: {otp}, recorda que tenes 20 minutos para ingresarlo en la aplicacion",
                    from: new PhoneNumber("+12676680054"), // Número de Twilio
                    to: new PhoneNumber(formattedPhoneNumber)
                );

                Console.WriteLine($"Mensaje enviado con SID: {message.Sid}");
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
                throw;
            }
        }*/
        /// <summary>
        /// Inicia el proceso de recuperación de contraseña enviando un OTP al usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        public void StartPasswordRecovery(string username)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                string otp = GenerateOTP();
                DateTime expiry = DateTime.Now.AddMinutes(20);

                // Guardar OTP y fecha de expiración en la base de datos
                //_usuarioRepository.SetOTP(usuario.IdUsuario, otp, expiry);

                // Enviar OTP por SMS
                //SendOTP(usuario.PhoneNumber, otp);
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }
        /// <summary>
        /// Valida un código OTP ingresado por el usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="otp">Código OTP ingresado.</param>
        /// <returns>True si el OTP es válido; de lo contrario, false.</returns>
       /* public bool ValidateOTP(string username, string otp)
        {
            //var usuario = _usuarioRepository.GetUsuarioByUsernameWithOTP(username);
            if (usuario != null && usuario.OTP == otp && usuario.OTPExpiry > DateTime.Now)
            {
                return true; // OTP válido
            }
            return false; // OTP inválido o expirado
        }*/
        /// <summary>
        /// Cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="newPassword">Nueva contraseña en texto plano.</param>
        public void ChangePassword(string username, string newPassword)
        {
            var usuario = _usuarioRepository.GetUsuarioByUsername(username);
            if (usuario != null)
            {
                string hashedPassword = CryptographyService.HashMd5(newPassword);
                _usuarioRepository.UpdatePassword(usuario.IdUsuario, hashedPassword);
            }
        }

    }
}
