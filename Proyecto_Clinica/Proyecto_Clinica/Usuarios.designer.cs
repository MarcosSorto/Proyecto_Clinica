namespace Proyecto_Clinica
{
    partial class FrmUsuarios
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
            this.label3 = new System.Windows.Forms.Label();
            this.btninhabilitar = new System.Windows.Forms.Button();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNivelAcceso = new System.Windows.Forms.ComboBox();
            this.MtxtIdentidad = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Rockwell Condensed", 27.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(201, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 44);
            this.label3.TabIndex = 113;
            this.label3.Text = "Control de Usuarios";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btninhabilitar
            // 
            this.btninhabilitar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btninhabilitar.Location = new System.Drawing.Point(326, 272);
            this.btninhabilitar.Name = "btninhabilitar";
            this.btninhabilitar.Size = new System.Drawing.Size(125, 44);
            this.btninhabilitar.TabIndex = 112;
            this.btninhabilitar.Text = "Inhabilitar";
            this.btninhabilitar.UseVisualStyleBackColor = true;
            this.btninhabilitar.Click += new System.EventHandler(this.btninhabilitar_Click);
            // 
            // btnactualizar
            // 
            this.btnactualizar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnactualizar.Location = new System.Drawing.Point(179, 272);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(134, 44);
            this.btnactualizar.TabIndex = 111;
            this.btnactualizar.Text = "Actualizar";
            this.btnactualizar.UseVisualStyleBackColor = true;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
            // 
            // btnregresar
            // 
            this.btnregresar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnregresar.Location = new System.Drawing.Point(464, 272);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(119, 44);
            this.btnregresar.TabIndex = 110;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = true;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnguardar.Location = new System.Drawing.Point(35, 272);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(125, 44);
            this.btnguardar.TabIndex = 109;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(127, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 107;
            this.label2.Text = "Usuario";
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtClave.Location = new System.Drawing.Point(291, 165);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(205, 27);
            this.txtClave.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(127, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 114;
            this.label1.Text = "Clave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(127, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 116;
            this.label4.Text = "Nivel de acceso";
            // 
            // cmbNivelAcceso
            // 
            this.cmbNivelAcceso.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cmbNivelAcceso.FormattingEnabled = true;
            this.cmbNivelAcceso.Items.AddRange(new object[] {
            "Administrador",
            "Enfermeria",
            "Otros"});
            this.cmbNivelAcceso.Location = new System.Drawing.Point(292, 198);
            this.cmbNivelAcceso.Name = "cmbNivelAcceso";
            this.cmbNivelAcceso.Size = new System.Drawing.Size(204, 28);
            this.cmbNivelAcceso.TabIndex = 117;
            // 
            // MtxtIdentidad
            // 
            this.MtxtIdentidad.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.MtxtIdentidad.Location = new System.Drawing.Point(292, 128);
            this.MtxtIdentidad.Mask = "0000-0000-00000";
            this.MtxtIdentidad.Name = "MtxtIdentidad";
            this.MtxtIdentidad.Size = new System.Drawing.Size(205, 27);
            this.MtxtIdentidad.TabIndex = 118;
            this.MtxtIdentidad.Leave += new System.EventHandler(this.MtxtIdentidad_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;

            this.pictureBox1.Location = new System.Drawing.Point(105, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 128;
            this.pictureBox1.TabStop = false;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Clinica.Properties.Resources.af778ff1_007d_48c9_bb30_bafa73b5d392;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(628, 328);
            this.Controls.Add(this.MtxtIdentidad);
            this.Controls.Add(this.cmbNivelAcceso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btninhabilitar);
            this.Controls.Add(this.btnactualizar);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btninhabilitar;
        private System.Windows.Forms.Button btnactualizar;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNivelAcceso;
        private System.Windows.Forms.MaskedTextBox MtxtIdentidad;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}