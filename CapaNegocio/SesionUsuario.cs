using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SesionUsuario
    {
        //Singleton para la sesión del usuario
        private static SesionUsuario _instancia = null;

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }

        private SesionUsuario() { }

        public static SesionUsuario Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new SesionUsuario();
                }
                return _instancia;
            }
        }

        public void CerrarSesion()
        {
            _instancia = null;
        }

    }
}
