using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuariosD
    {

        //Validar login y actualizar el ultimo acceso del usuario
        public DataTable ValidarLogin(string correo, string password)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }

        public void ActualizarUltimoAcceso(int idUsuario)
        {
            using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarUltimoAcceso", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Registrar un nuevo usuario en la base de datos
        public bool RegistrarUsuario(string nombre, string password, string correoElectronico, out string mensajeError)
        {
            mensajeError = string.Empty;
            try
            {
                using (SqlConnection conexion = Conexion.Instancia.CrearConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@correoElectronico", correoElectronico);
                       

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }


    }
}
