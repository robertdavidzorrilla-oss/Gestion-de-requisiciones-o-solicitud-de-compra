using CapaNegocio;
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
    public partial class EditarRequisision : Form
    {

        private readonly RequisicionesN _requisicionesN = new RequisicionesN();
        private int _idRequisicionSeleccionada = 0;
        private int _idEstadoActual = 0;

        public EditarRequisision()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-DO");
            dgvRequisiciones.SelectionChanged += dgvRequisiciones_SelectionChanged;
            CargarRequisiciones();

            btnEnviarRevision.Click += btnEnviarRevision_Click;
            btnAprobar.Click += btnAprobar_Click;
            btnRechazar.Click += btnRechazar_Click;
            btnCancelar.Click += btnCancelar_Click;

        }

       

        private void DeshabilitarBotonesAccion()
        {
            btnEnviarRevision.Enabled = false;
            btnAprobar.Enabled = false;
            btnRechazar.Enabled = false;
            btnCancelar.Enabled = false;
            lblCodigoSeleccionado.Text = "Requisición: (Seleccione una)";
            lblEstadoActual.Text = "Estado Actual: -";
        }
        private void CargarRequisiciones()
        {
            DataTable dt = _requisicionesN.ObtenerRequisiciones();
            dgvRequisiciones.DataSource = dt;


            if (dgvRequisiciones.Columns["total"] != null)
                dgvRequisiciones.Columns["total"].DefaultCellStyle.Format = "C2";

            DeshabilitarBotonesAccion();
        }

        private void ActualizarBotonesSegunEstado(int idEstado)
        {
            // Habilitar/Deshabilitar botones respetando las reglas de transición del patrón State
            btnEnviarRevision.Enabled = (idEstado == 1);
            btnAprobar.Enabled = (idEstado == 2);
            btnRechazar.Enabled = (idEstado == 2);
            btnCancelar.Enabled = (idEstado == 1 || idEstado == 2);
        }

        private void EjecutarCambioEstado(string accion)
        {
            if (_idRequisicionSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione una requisición de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (accion.Equals("CANCELAR", StringComparison.OrdinalIgnoreCase))
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea cancelar esta requisición?",
                    "Confirmación de Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.No)
                    return;
            }
            else if (accion.Equals("RECHAZAR", StringComparison.OrdinalIgnoreCase))
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro de que desea rechazar esta requisición?",
                    "Confirmación de Rechazo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.No)
                    return;
            }


            if (_requisicionesN.TransicionarEstado(_idRequisicionSeleccionada, _idEstadoActual, accion, out string mensajeError))
            {
                MessageBox.Show("¡Estado actualizado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRequisiciones();
            }
            else
            {
                MessageBox.Show(mensajeError, "Transición no permitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarRevision_Click(object sender, EventArgs e) => EjecutarCambioEstado("REVISION");
        private void btnAprobar_Click(object sender, EventArgs e) => EjecutarCambioEstado("APROBAR");
        private void btnRechazar_Click(object sender, EventArgs e) => EjecutarCambioEstado("RECHAZAR");
        private void btnCancelar_Click(object sender, EventArgs e) => EjecutarCambioEstado("CANCELAR");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRequisiciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequisiciones.CurrentRow != null && dgvRequisiciones.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgvRequisiciones.CurrentRow;

                // Validar que las celdas no sean nulas antes de convertir
                if (fila.Cells["idRequisicion"].Value != DBNull.Value && fila.Cells["idRequisicion"].Value != null)
                {
                    _idRequisicionSeleccionada = Convert.ToInt32(fila.Cells["idRequisicion"].Value);
                    _idEstadoActual = Convert.ToInt32(fila.Cells["idEstado"].Value);
                    

                    string codigo = fila.Cells["codigoRequisicion"].Value.ToString();
                    string estadoNombre = fila.Cells["Estado"].Value.ToString();

                    // Actualizar etiquetas
                    lblCodigoSeleccionado.Text = $"Requisición: {codigo}";
                    lblEstadoActual.Text = $"Estado Actual: {estadoNombre}";

                    // Habilitar/Deshabilitar botones según el estado
                    ActualizarBotonesSegunEstado(_idEstadoActual);
                }
            }
        }
    }
}
