using CapaNegocio;
using CapaNegocio.Patrones.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace CapaPresentacion
{
    public partial class CrearRequisision : Form
    {

        private RequisicionBuilder _builder;
        private readonly RequisicionesN _requisicionesN = new RequisicionesN();

        public CrearRequisision()
        {
            InitializeComponent();
            CargarEstrategiasImpuesto();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-DO");

            _builder = new RequisicionBuilder();
        }



        private void CargarEstrategiasImpuesto()
        {
            cmbImpuesto.Items.Clear();
            cmbImpuesto.Items.Add(new TasaEstandarStrategy());
            cmbImpuesto.Items.Add(new TasaExtentaStrategy());
            cmbImpuesto.Items.Add(new TasaaraeducidaStrategy());

            cmbImpuesto.DisplayMember = "nombreEstrategia";
            cmbImpuesto.SelectedIndex = 0;
        }

        private void CalcularYMostrarTotales()
        {
            try
            {
                var estrategia = (TasaStrategy)cmbImpuesto.SelectedItem;
                if (estrategia != null && !string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    _builder.EstablecerEncabezado(txtCodigo.Text.Trim(), estrategia);
                }

                var reqTemporal = _builder.Build();


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = reqTemporal.Detalles;


                lblSubtotal.Text = reqTemporal.Subtotal.ToString("C2");
                lblImpuesto.Text = reqTemporal.Impuesto.ToString("C2");
                lblTotal.Text = reqTemporal.Total.ToString("C2");
            }
            catch
            {

                lblSubtotal.Text = "$0.00";
                lblImpuesto.Text = "$0.00";
                lblTotal.Text = "$0.00";
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            try
            {
                string producto = txtProducto.Text.Trim();
                int cantidad = (int)numCantidad.Value;
                decimal precio = Convert.ToDecimal(txtPrecio.Text);

                // Agregar ítem usando el Builder (aplica validaciones requeridas)
                _builder.AgregarItem(producto, cantidad, precio);

                // Recalcular y autocompletar automáticamente
                CalcularYMostrarTotales();

                // Limpiar campos de entrada
                txtProducto.Clear();
                txtPrecio.Clear();
                numCantidad.Value = 1;
                txtProducto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación de Ítem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recalcular totales cuando cambia la política de impuestos (Strategy)
            CalcularYMostrarTotales();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var estrategia = (TasaStrategy)cmbImpuesto.SelectedItem;
                _builder.EstablecerEncabezado(txtCodigo.Text.Trim(), estrategia);

                // Construir Requisicion final (Valida la regla de contener al menos 1 ítem)
                Requisicion reqFinal = _builder.Build();

                if (_requisicionesN.GuardarRequisicion(reqFinal, out string mensajeError))
                {
                    MessageBox.Show($"Requisición '{reqFinal.Codigo}' registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(mensajeError, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }
    }
}
