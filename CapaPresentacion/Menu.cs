using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearRequisision crearRequisision = new CrearRequisision();
            this.Hide();
            crearRequisision.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditarRequisision editarRequisision = new EditarRequisision();
            this.Hide();
            editarRequisision.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportesG reportesG = new ReportesG();
            this.Hide();
            reportesG.Show();
        }
    }
}
