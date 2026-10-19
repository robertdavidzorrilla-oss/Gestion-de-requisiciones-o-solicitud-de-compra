namespace CapaPresentacion
{
    partial class CrearRequisision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            txtPrecio = new TextBox();
            label8 = new Label();
            btnGuardar = new Button();
            btnItem = new Button();
            label7 = new Label();
            numCantidad = new NumericUpDown();
            lblTotal = new Label();
            lblImpuesto = new Label();
            lblSubtotal = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtProducto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cmbImpuesto = new ComboBox();
            txtCodigo = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtPrecio);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnItem);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(numCantidad);
            panel1.Controls.Add(lblTotal);
            panel1.Controls.Add(lblImpuesto);
            panel1.Controls.Add(lblSubtotal);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtProducto);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbImpuesto);
            panel1.Controls.Add(txtCodigo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(21, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 532);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(686, 3);
            button1.Name = "button1";
            button1.Size = new Size(68, 35);
            button1.TabIndex = 19;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(217, 245);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(129, 27);
            txtPrecio.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(217, 222);
            label8.Name = "label8";
            label8.Size = new Size(55, 21);
            label8.TabIndex = 17;
            label8.Text = "Precio";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.InactiveCaption;
            btnGuardar.Location = new Point(634, 318);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 44);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnItem
            // 
            btnItem.BackColor = SystemColors.InactiveCaption;
            btnItem.Location = new Point(26, 318);
            btnItem.Name = "btnItem";
            btnItem.Size = new Size(123, 36);
            btnItem.TabIndex = 15;
            btnItem.Text = "Agregar Item";
            btnItem.UseVisualStyleBackColor = false;
            btnItem.Click += btnItem_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(26, 222);
            label7.Name = "label7";
            label7.Size = new Size(75, 21);
            label7.TabIndex = 14;
            label7.Text = "Cantidad";
            // 
            // numCantidad
            // 
            numCantidad.AllowDrop = true;
            numCantidad.Location = new Point(26, 246);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(150, 27);
            numCantidad.TabIndex = 13;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(582, 129);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(64, 20);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "RD$0.00";
            // 
            // lblImpuesto
            // 
            lblImpuesto.AutoSize = true;
            lblImpuesto.Location = new Point(582, 89);
            lblImpuesto.Name = "lblImpuesto";
            lblImpuesto.Size = new Size(64, 20);
            lblImpuesto.TabIndex = 11;
            lblImpuesto.Text = "RD$0.00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(582, 40);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(64, 20);
            lblSubtotal.TabIndex = 10;
            lblSubtotal.Text = "RD$0.00";
            lblSubtotal.UseMnemonic = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(481, 128);
            label6.Name = "label6";
            label6.Size = new Size(54, 21);
            label6.TabIndex = 9;
            label6.Text = "Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(476, 89);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 8;
            label5.Text = "Impuesto:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(476, 40);
            label4.Name = "label4";
            label4.Size = new Size(81, 21);
            label4.TabIndex = 7;
            label4.Text = "SubTotal:";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(26, 178);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(264, 27);
            txtProducto.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 154);
            label3.Name = "label3";
            label3.Size = new Size(267, 21);
            label3.TabIndex = 5;
            label3.Text = "Agregue el nombre de un producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 89);
            label2.Name = "label2";
            label2.Size = new Size(264, 21);
            label2.TabIndex = 4;
            label2.Text = "Seleccione estrategia de impuesto";
            label2.Click += label2_Click;
            // 
            // cmbImpuesto
            // 
            cmbImpuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImpuesto.FormattingEnabled = true;
            cmbImpuesto.Location = new Point(26, 112);
            cmbImpuesto.Name = "cmbImpuesto";
            cmbImpuesto.Size = new Size(128, 28);
            cmbImpuesto.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(26, 40);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(128, 27);
            txtCodigo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 17);
            label1.Name = "label1";
            label1.Size = new Size(280, 21);
            label1.TabIndex = 1;
            label1.Text = "Escriba un codigo para la requisision";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 368);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(717, 143);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // CrearRequisision
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(803, 581);
            Controls.Add(panel1);
            Name = "CrearRequisision";
            Text = "CrearRequisision";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox txtCodigo;
        private Label label2;
        private ComboBox cmbImpuesto;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtProducto;
        private Button btnItem;
        private Label label7;
        private NumericUpDown numCantidad;
        private Label lblTotal;
        private Label lblImpuesto;
        private Label lblSubtotal;
        private Button btnGuardar;
        private TextBox txtPrecio;
        private Label label8;
        private Button button1;
    }
}