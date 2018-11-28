namespace Proyecto_Clinica
{
    partial class FrmPresentacion
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
            this.TextCod = new System.Windows.Forms.Label();
            this.FrmPesentación = new System.Windows.Forms.Label();
            this.btninhabilitar = new System.Windows.Forms.Button();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelCod = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextCod
            // 
            this.TextCod.AutoSize = true;
            this.TextCod.BackColor = System.Drawing.Color.Transparent;
            this.TextCod.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TextCod.ForeColor = System.Drawing.Color.White;
            this.TextCod.Location = new System.Drawing.Point(126, 109);
            this.TextCod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextCod.Name = "TextCod";
            this.TextCod.Size = new System.Drawing.Size(79, 20);
            this.TextCod.TabIndex = 34;
            this.TextCod.Text = "Código:";
            // 
            // FrmPesentación
            // 
            this.FrmPesentación.AutoSize = true;
            this.FrmPesentación.BackColor = System.Drawing.Color.Transparent;
            this.FrmPesentación.Font = new System.Drawing.Font("Rockwell Condensed", 27.75F, System.Drawing.FontStyle.Bold);
            this.FrmPesentación.ForeColor = System.Drawing.Color.White;
            this.FrmPesentación.Location = new System.Drawing.Point(100, 37);
            this.FrmPesentación.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FrmPesentación.Name = "FrmPesentación";
            this.FrmPesentación.Size = new System.Drawing.Size(485, 44);
            this.FrmPesentación.TabIndex = 33;
            this.FrmPesentación.Text = "Presentación de Medicamentos";
            // 
            // btninhabilitar
            // 
            this.btninhabilitar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btninhabilitar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btninhabilitar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btninhabilitar.Location = new System.Drawing.Point(319, 270);
            this.btninhabilitar.Name = "btninhabilitar";
            this.btninhabilitar.Size = new System.Drawing.Size(130, 46);
            this.btninhabilitar.TabIndex = 105;
            this.btninhabilitar.Text = "Inhabilitar";
            this.btninhabilitar.UseVisualStyleBackColor = false;
            this.btninhabilitar.Click += new System.EventHandler(this.btninhabilitar_Click);
            // 
            // btnactualizar
            // 
            this.btnactualizar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnactualizar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnactualizar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnactualizar.Location = new System.Drawing.Point(179, 270);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(126, 46);
            this.btnactualizar.TabIndex = 104;
            this.btnactualizar.Text = "Actualizar";
            this.btnactualizar.UseVisualStyleBackColor = false;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
            // 
            // btnregresar
            // 
            this.btnregresar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnregresar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnregresar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnregresar.Location = new System.Drawing.Point(465, 270);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(130, 46);
            this.btnregresar.TabIndex = 103;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = false;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnguardar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnguardar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnguardar.Location = new System.Drawing.Point(37, 270);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(126, 46);
            this.btnguardar.TabIndex = 102;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxDesc.Location = new System.Drawing.Point(251, 150);
            this.textBoxDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(184, 31);
            this.textBoxDesc.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(126, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Descripción:";
            // 
            // LabelCod
            // 
            this.LabelCod.AutoSize = true;
            this.LabelCod.BackColor = System.Drawing.Color.Transparent;
            this.LabelCod.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCod.ForeColor = System.Drawing.Color.Blue;
            this.LabelCod.Location = new System.Drawing.Point(246, 101);
            this.LabelCod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelCod.Name = "LabelCod";
            this.LabelCod.Size = new System.Drawing.Size(102, 29);
            this.LabelCod.TabIndex = 120;
            this.LabelCod.Text = "Código";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(251, 200);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(184, 27);
            this.btnEditar.TabIndex = 124;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(450, 150);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 31);
            this.btnBuscar.TabIndex = 123;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;

            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 125;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Clinica.Properties.Resources.af778ff1_007d_48c9_bb30_bafa73b5d392;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(628, 328);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.LabelCod);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btninhabilitar);
            this.Controls.Add(this.btnactualizar);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.TextCod);
            this.Controls.Add(this.FrmPesentación);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPresentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presentación de Medicamentos";
            this.Load += new System.EventHandler(this.FrmPresentacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TextCod;
        private System.Windows.Forms.Label FrmPesentación;
        private System.Windows.Forms.Button btninhabilitar;
        private System.Windows.Forms.Button btnactualizar;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelCod;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}