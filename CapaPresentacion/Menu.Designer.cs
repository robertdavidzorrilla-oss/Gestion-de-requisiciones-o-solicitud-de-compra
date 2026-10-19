namespace CapaPresentacion
{
    partial class Menu
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
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            button3 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(88, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 396);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.BackColor = Color.LightSeaGreen;
            button4.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(195, 297);
            button4.Name = "button4";
            button4.Size = new Size(194, 61);
            button4.TabIndex = 3;
            button4.Text = "Reportes";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightSeaGreen;
            button2.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(195, 199);
            button2.Name = "button2";
            button2.Size = new Size(194, 70);
            button2.TabIndex = 2;
            button2.Text = "Editar Requisicion";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSeaGreen;
            button1.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(195, 99);
            button1.Name = "button1";
            button1.Size = new Size(194, 66);
            button1.TabIndex = 1;
            button1.Text = "Nueva requisicion";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(95, 28);
            label1.Name = "label1";
            label1.Size = new Size(414, 36);
            label1.TabIndex = 0;
            label1.Text = "GESTION DE REQUISICIONES";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.Location = new Point(739, 508);
            button3.Name = "button3";
            button3.Size = new Size(59, 32);
            button3.TabIndex = 1;
            button3.Text = "Salir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(800, 542);
            Controls.Add(button3);
            Controls.Add(panel1);
            Name = "Menu";
            Text = "Menu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label label1;
        private Button button3;
        private Button button4;
    }
}