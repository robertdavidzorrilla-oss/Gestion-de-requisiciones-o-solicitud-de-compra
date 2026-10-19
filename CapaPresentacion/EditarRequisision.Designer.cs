namespace CapaPresentacion
{
    partial class EditarRequisision
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
            lblCodigoSeleccionado = new Label();
            lblEstadoActual = new Label();
            panel1 = new Panel();
            label3 = new Label();
            btnAprobar = new Button();
            btnVolver = new Button();
            btnCancelar = new Button();
            btnRechazar = new Button();
            btnEnviarRevision = new Button();
            dgvRequisiciones = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisiciones).BeginInit();
            SuspendLayout();
            // 
            // lblCodigoSeleccionado
            // 
            lblCodigoSeleccionado.AutoSize = true;
            lblCodigoSeleccionado.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigoSeleccionado.Location = new Point(20, 67);
            lblCodigoSeleccionado.Name = "lblCodigoSeleccionado";
            lblCodigoSeleccionado.Size = new Size(166, 21);
            lblCodigoSeleccionado.TabIndex = 1;
            lblCodigoSeleccionado.Text = "Codigo seleccionado:";
            lblCodigoSeleccionado.Click += label1_Click;
            // 
            // lblEstadoActual
            // 
            lblEstadoActual.AutoSize = true;
            lblEstadoActual.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstadoActual.Location = new Point(20, 111);
            lblEstadoActual.Name = "lblEstadoActual";
            lblEstadoActual.Size = new Size(117, 21);
            lblEstadoActual.TabIndex = 2;
            lblEstadoActual.Text = "Estado actual:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientInactiveCaption;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnAprobar);
            panel1.Controls.Add(btnVolver);
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnRechazar);
            panel1.Controls.Add(btnEnviarRevision);
            panel1.Controls.Add(dgvRequisiciones);
            panel1.Controls.Add(lblEstadoActual);
            panel1.Controls.Add(lblCodigoSeleccionado);
            panel1.Location = new Point(18, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(759, 491);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 211);
            label3.Name = "label3";
            label3.Size = new Size(256, 21);
            label3.TabIndex = 9;
            label3.Text = "Seleccione estado de requisicion:";
            // 
            // btnAprobar
            // 
            btnAprobar.Location = new Point(156, 266);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(99, 36);
            btnAprobar.TabIndex = 8;
            btnAprobar.Text = "Aprobar";
            btnAprobar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = SystemColors.GradientActiveCaption;
            btnVolver.ForeColor = SystemColors.ActiveCaptionText;
            btnVolver.Location = new Point(623, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(133, 46);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver al Menú";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(451, 267);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 35);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button3_Click;
            // 
            // btnRechazar
            // 
            btnRechazar.Location = new Point(302, 266);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(92, 36);
            btnRechazar.TabIndex = 5;
            btnRechazar.Text = "Rechazar";
            btnRechazar.UseVisualStyleBackColor = true;
            // 
            // btnEnviarRevision
            // 
            btnEnviarRevision.Location = new Point(20, 267);
            btnEnviarRevision.Name = "btnEnviarRevision";
            btnEnviarRevision.Size = new Size(102, 36);
            btnEnviarRevision.TabIndex = 4;
            btnEnviarRevision.Text = "En revision";
            btnEnviarRevision.UseVisualStyleBackColor = true;
            // 
            // dgvRequisiciones
            // 
            dgvRequisiciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequisiciones.Location = new Point(20, 309);
            dgvRequisiciones.Name = "dgvRequisiciones";
            dgvRequisiciones.RowHeadersWidth = 51;
            dgvRequisiciones.Size = new Size(718, 170);
            dgvRequisiciones.TabIndex = 3;
            dgvRequisiciones.CellClick += dgvRequisiciones_SelectionChanged;
            // 
            // EditarRequisision
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(800, 527);
            Controls.Add(panel1);
            Name = "EditarRequisision";
            Text = "EditarRequisision";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequisiciones).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblCodigoSeleccionado;
        private Label lblEstadoActual;
        private Panel panel1;
        private Button btnAprobar;
        private Button btnVolver;
        private Button btnCancelar;
        private Button btnRechazar;
        private Button btnEnviarRevision;
        private DataGridView dgvRequisiciones;
        private Label label3;
    }
}