using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private readonly UsuariosN _cnUsuario = new UsuariosN();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmarPassword = txtConfirmPassword.Text.Trim();

            bool resultado = _cnUsuario.Registrar(nombre, password, confirmarPassword, correo, out string mensajeError);

            if (resultado)
            {
                MessageBox.Show("¡Usuario registrado exitosamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 login = new Form1();
                this.Hide();
                login.Show();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
