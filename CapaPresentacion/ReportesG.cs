using CapaNegocio;
using CapaNegocio.Patrones.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ReportesG : Form
    {

        private readonly RequisicionesN _requisicionesN = new RequisicionesN();
        private List<ReporteRequisicionDTO> _listaReportes = new List<ReporteRequisicionDTO>();
        private int _indiceActual = 0;
        private readonly CultureInfo _culturaDO = new CultureInfo("es-DO");
        public ReportesG()
        {
            InitializeComponent();
            CargarReportes();
        }

        //Mostrar el reporte actual en el richTextBox
        private void MostrarReporteActual()
        {
            if (_listaReportes.Count == 0 || _indiceActual < 0 || _indiceActual >= _listaReportes.Count)
                return;

            ReporteRequisicionDTO rep = _listaReportes[_indiceActual];
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("==========================================================================================");
            sb.AppendLine($"                     REPORTE OFICIAL DE REQUISICIÓN APROBADA  ({_indiceActual + 1} / {_listaReportes.Count})");
            sb.AppendLine("==========================================================================================");
            sb.AppendLine($" Código Requisición : {rep.CodigoRequisicion}");
            sb.AppendLine($" Fecha de Creación  : {rep.FechaCreacion:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($" Estado Actual      : {rep.Estado}");
            sb.AppendLine($" Política Impuesto  : {rep.PoliticaImpuesto}");
            sb.AppendLine("------------------------------------------------------------------------------------------");
            sb.AppendLine(string.Format("{0,-35} | {1,-10} | {2,-15} | {3,-15}", "PRODUCTO", "CANTIDAD", "PRECIO UNIT.", "SUBTOTAL LÍNEA"));
            sb.AppendLine("------------------------------------------------------------------------------------------");

            foreach (var item in rep.Detalle)
            {
                sb.AppendLine(string.Format("{0,-35} | {1,-10} | {2,-15} | {3,-15}",
                    item.NombreProducto,
                    item.Cantidad,
                    item.PrecioUnitario.ToString("C2", _culturaDO),
                    item.SubtotalLinea.ToString("C2", _culturaDO)));
            }

            sb.AppendLine("------------------------------------------------------------------------------------------");
            sb.AppendLine($" Subtotal General   : {rep.SubtotalGeneral.ToString("C2", _culturaDO)}");
            sb.AppendLine($" Impuesto Total     : {rep.ImpuestoTotal.ToString("C2", _culturaDO)}");
            sb.AppendLine($" TOTAL GENERAL      : {rep.TotalGeneral.ToString("C2", _culturaDO)}");
            sb.AppendLine("==========================================================================================");

            richTextBox1.Text = sb.ToString();

            
            btnAnterior.Enabled = (_indiceActual > 0);
            btnSiguiente.Enabled = (_indiceActual < _listaReportes.Count - 1);
        }

        //Cargar reportes aprobados al iniciar el formulario
        private void CargarReportes()
        {
            _listaReportes = _requisicionesN.ObtenerReporteAprobadas();
            _indiceActual = 0;

            if (_listaReportes.Count > 0)
            {
                MostrarReporteActual();
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.Text = "\n\n\n\t\t======================================================\n" +
                                    "\t\t  NO HAY REQUISICIONES APROBADAS PARA MOSTRAR REPORTE\n" +
                                    "\t\t======================================================";
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_indiceActual < _listaReportes.Count - 1)
            {
                _indiceActual++;
                MostrarReporteActual();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_indiceActual > 0)
            {
                _indiceActual--;
                MostrarReporteActual();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }
    }
}
