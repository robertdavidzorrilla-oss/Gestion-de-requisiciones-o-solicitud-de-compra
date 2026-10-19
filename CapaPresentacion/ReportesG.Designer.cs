namespace CapaPresentacion
{
    partial class ReportesG
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
            label1 = new Label();
            panel1 = new Panel();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(185, 15);
            label1.Name = "label1";
            label1.Size = new Size(455, 28);
            label1.TabIndex = 0;
            label1.Text = "REPORTE DE REQUISICIONES APROBADAS";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(btnSiguiente);
            panel1.Controls.Add(btnAnterior);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(862, 560);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackColor = SystemColors.GradientActiveCaption;
            btnSiguiente.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSiguiente.Location = new Point(693, 505);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(128, 40);
            btnSiguiente.TabIndex = 4;
            btnSiguiente.Text = "Siguiente ▶️";
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.BackColor = SystemColors.GradientActiveCaption;
            btnAnterior.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnterior.Location = new Point(47, 505);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(128, 40);
            btnAnterior.TabIndex = 3;
            btnAnterior.Text = "◀️ Anterior";
            btnAnterior.UseVisualStyleBackColor = false;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(741, 7);
            button1.Name = "button1";
            button1.Size = new Size(118, 36);
            button1.TabIndex = 2;
            button1.Text = "Volver al menu";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(58, 97);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(746, 349);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // ReportesG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(899, 596);
            Controls.Add(panel1);
            Name = "ReportesG";
            Text = "ReportesG";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button button1;
        private RichTextBox richTextBox1;
        private Button btnSiguiente;
        private Button btnAnterior;
    }
}