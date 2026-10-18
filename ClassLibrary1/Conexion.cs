using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{

    //Singleton para la conexión a la base de datos
    internal class Conexion
    {
        private static Conexion _instancia = null;
        private readonly string _cadenaConexion;

        private Conexion()
        {
            
            _cadenaConexion = "Server=LENOVORD25\\ROBERT;Database=Requisisiones;Integrated Security=True; TrustServerCertificate=True;";
        }

        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Conexion();
                }
                return _instancia;
            }
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }

    }
}
