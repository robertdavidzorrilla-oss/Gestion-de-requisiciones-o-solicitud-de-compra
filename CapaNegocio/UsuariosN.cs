using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuariosN
    {
        private readonly UsuariosD _cdUsuario = new UsuariosD();

        public bool IniciarSesion(string correo, string password, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                mensajeError = "Debe ingresar el correo y la contraseña.";
                return false;
            }

            DataTable dt = _cdUsuario.ValidarLogin(correo, password);

            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];

                // Cargar datos en la sesión global (Singleton)
                SesionUsuario.Instancia.IdUsuario = Convert.ToInt32(fila["idUsuario"]);
                SesionUsuario.Instancia.Nombre = fila["nombre"].ToString();
                SesionUsuario.Instancia.CorreoElectronico = fila["correoElectronico"].ToString();

                _cdUsuario.ActualizarUltimoAcceso(SesionUsuario.Instancia.IdUsuario);

                return true;
            }
            else
            {
                mensajeError = "Credenciales incorrectas. Verifique correo y contraseña.";
                return false;
            }
        }

        //Registrar un nuevo usuario con validación de campos

        public bool Registrar(string nombre, string password, string confirmarPassword, string correoElectronico, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmarPassword) || string.IsNullOrWhiteSpace(correoElectronico))
            {
                mensajeError = "Todos los campos son obligatorios.";
                return false;
            }

            if (password != confirmarPassword)
            {
                mensajeError = "Las contraseñas no coinciden.";
                return false;
            }

            if (!correoElectronico.Contains("@") || !correoElectronico.Contains("."))
            {
                mensajeError = "El correo electrónico no es válido.";
                return false;
            }


            return _cdUsuario.RegistrarUsuario(nombre, password, correoElectronico, out mensajeError);
        }

    }
}
