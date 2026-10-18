using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly UsuariosN _cnUsuario = new UsuariosN();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (_cnUsuario.IniciarSesion(correo, password, out string mensajeError))
            {
                MessageBox.Show($"Bienvenido/a {SesionUsuario.Instancia.Nombre}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Menu menu = new Menu();
                this.Hide();
                menu.Show();

            }
            else
            {
                MessageBox.Show(mensajeError, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrarse registro = new Registrarse();
            this.Hide();
            registro.Show();
        }
    }
}
