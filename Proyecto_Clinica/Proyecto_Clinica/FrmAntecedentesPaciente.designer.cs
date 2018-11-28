namespace Proyecto_Clinica
{
    partial class FrmAntecedentesPaciente
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
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtotros = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmedicamentos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtalimentos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcronicos = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtcirugias = new System.Windows.Forms.TextBox();
            this.txtsalir = new System.Windows.Forms.Button();
            this.txtactualizar = new System.Windows.Forms.Button();
            this.txtguardar = new System.Windows.Forms.Button();
            this.txtidentidad = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtnombre
            // 
            this.txtnombre.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtnombre.Location = new System.Drawing.Point(387, 98);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(339, 27);
            this.txtnombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Identidad Paciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell Condensed", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(276, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 44);
            this.label1.TabIndex = 51;
            this.label1.Text = "Antecentes Clínicos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(287, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtotros);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtmedicamentos);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtalimentos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alergias";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtotros
            // 
            this.txtotros.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtotros.Location = new System.Drawing.Point(151, 93);
            this.txtotros.Multiline = true;
            this.txtotros.Name = "txtotros";
            this.txtotros.Size = new System.Drawing.Size(533, 24);
            this.txtotros.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(11, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Otros";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtmedicamentos
            // 
            this.txtmedicamentos.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtmedicamentos.Location = new System.Drawing.Point(151, 63);
            this.txtmedicamentos.Multiline = true;
            this.txtmedicamentos.Name = "txtmedicamentos";
            this.txtmedicamentos.Size = new System.Drawing.Size(533, 24);
            this.txtmedicamentos.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Medicamentos";
            // 
            // txtalimentos
            // 
            this.txtalimentos.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtalimentos.Location = new System.Drawing.Point(151, 33);
            this.txtalimentos.Multiline = true;
            this.txtalimentos.Name = "txtalimentos";
            this.txtalimentos.Size = new System.Drawing.Size(533, 24);
            this.txtalimentos.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(11, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Alimentos";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtcronicos);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(16, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enfermedades Crónicas";
            // 
            // txtcronicos
            // 
            this.txtcronicos.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtcronicos.Location = new System.Drawing.Point(15, 25);
            this.txtcronicos.Multiline = true;
            this.txtcronicos.Name = "txtcronicos";
            this.txtcronicos.Size = new System.Drawing.Size(669, 56);
            this.txtcronicos.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtcirugias);
            this.groupBox3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(16, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(710, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cirujías o Tratamientos Médicos";
            // 
            // txtcirugias
            // 
            this.txtcirugias.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtcirugias.Location = new System.Drawing.Point(15, 25);
            this.txtcirugias.Multiline = true;
            this.txtcirugias.Name = "txtcirugias";
            this.txtcirugias.Size = new System.Drawing.Size(669, 56);
            this.txtcirugias.TabIndex = 0;
            // 
            // txtsalir
            // 
            this.txtsalir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtsalir.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtsalir.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtsalir.Location = new System.Drawing.Point(653, 522);
            this.txtsalir.Name = "txtsalir";
            this.txtsalir.Size = new System.Drawing.Size(73, 44);
            this.txtsalir.TabIndex = 6;
            this.txtsalir.Text = "Salir";
            this.txtsalir.UseVisualStyleBackColor = false;
            this.txtsalir.Click += new System.EventHandler(this.txtsalir_Click);
            // 
            // txtactualizar
            // 
            this.txtactualizar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtactualizar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtactualizar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtactualizar.Location = new System.Drawing.Point(176, 522);
            this.txtactualizar.Name = "txtactualizar";
            this.txtactualizar.Size = new System.Drawing.Size(131, 44);
            this.txtactualizar.TabIndex = 5;
            this.txtactualizar.Text = "Actualizar";
            this.txtactualizar.UseVisualStyleBackColor = false;
            this.txtactualizar.Click += new System.EventHandler(this.txtactualizar_Click);
            // 
            // txtguardar
            // 
            this.txtguardar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtguardar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtguardar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtguardar.Location = new System.Drawing.Point(16, 522);
            this.txtguardar.Name = "txtguardar";
            this.txtguardar.Size = new System.Drawing.Size(136, 44);
            this.txtguardar.TabIndex = 4;
            this.txtguardar.Text = "Guardar";
            this.txtguardar.UseVisualStyleBackColor = false;
            this.txtguardar.Click += new System.EventHandler(this.txtguardar_Click);
            // 
            // txtidentidad
            // 
            this.txtidentidad.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtidentidad.Location = new System.Drawing.Point(207, 98);
            this.txtidentidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtidentidad.Mask = "0000-0000-00000";
            this.txtidentidad.Name = "txtidentidad";
            this.txtidentidad.Size = new System.Drawing.Size(175, 27);
            this.txtidentidad.TabIndex = 0;
            this.txtidentidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtidentidad.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtidentidad_MaskInputRejected);
            this.txtidentidad.Leave += new System.EventHandler(this.txtidentidad_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Proyecto_Clinica.Properties.Resources.a9c4a4bb_6a71_4e3d_a195_24d3f987e8ab;
            this.pictureBox1.Location = new System.Drawing.Point(151, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAntecedentesPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Clinica.Properties.Resources.af778ff1_007d_48c9_bb30_bafa73b5d392;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(754, 593);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtidentidad);
            this.Controls.Add(this.txtactualizar);
            this.Controls.Add(this.txtguardar);
            this.Controls.Add(this.txtsalir);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAntecedentesPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Antecedentes Clínicos";
            this.Load += new System.EventHandler(this.FrmAntecedentesPaciente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtotros;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtmedicamentos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtalimentos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtcronicos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtcirugias;
        private System.Windows.Forms.Button txtsalir;
        private System.Windows.Forms.Button txtactualizar;
        private System.Windows.Forms.Button txtguardar;
        private System.Windows.Forms.MaskedTextBox txtidentidad;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}