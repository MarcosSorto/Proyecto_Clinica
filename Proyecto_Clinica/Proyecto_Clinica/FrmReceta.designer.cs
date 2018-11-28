namespace Proyecto_Clinica
{
    partial class FrmReceta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcodigoreceta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.txtprescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericcabtidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnbuscarmedicamento = new System.Windows.Forms.Button();
            this.txtcodigomedicamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indicaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdReceta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMedicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnactualizarreceta = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btninhabilitarreceta = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericcabtidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtcodigoreceta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btneliminar);
            this.groupBox1.Controls.Add(this.btnagregar);
            this.groupBox1.Controls.Add(this.txtprescripcion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericcabtidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnbuscarmedicamento);
            this.groupBox1.Controls.Add(this.txtcodigomedicamento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(32, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 205);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Receta";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // txtcodigoreceta
            // 
            this.txtcodigoreceta.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtcodigoreceta.Location = new System.Drawing.Point(147, 142);
            this.txtcodigoreceta.Name = "txtcodigoreceta";
            this.txtcodigoreceta.Size = new System.Drawing.Size(152, 27);
            this.txtcodigoreceta.TabIndex = 4;
            this.txtcodigoreceta.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(313, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 22);
            this.label7.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 81;
            this.label2.Text = "CodigoReceta";
            this.label2.Visible = false;
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.Black;
            this.btneliminar.Location = new System.Drawing.Point(489, 140);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(95, 30);
            this.btneliminar.TabIndex = 6;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.Btneliminar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.Black;
            this.btnagregar.Location = new System.Drawing.Point(385, 141);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(98, 30);
            this.btnagregar.TabIndex = 5;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.Btnagregar_Click);
            // 
            // txtprescripcion
            // 
            this.txtprescripcion.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtprescripcion.Location = new System.Drawing.Point(147, 88);
            this.txtprescripcion.Multiline = true;
            this.txtprescripcion.Name = "txtprescripcion";
            this.txtprescripcion.Size = new System.Drawing.Size(437, 47);
            this.txtprescripcion.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "Prescripción";
            // 
            // numericcabtidad
            // 
            this.numericcabtidad.Location = new System.Drawing.Point(147, 59);
            this.numericcabtidad.Name = "numericcabtidad";
            this.numericcabtidad.Size = new System.Drawing.Size(68, 27);
            this.numericcabtidad.TabIndex = 2;
            this.numericcabtidad.ValueChanged += new System.EventHandler(this.Numericcabtidad_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Cantidad:";
            // 
            // btnbuscarmedicamento
            // 
            this.btnbuscarmedicamento.BackColor = System.Drawing.Color.Black;
            this.btnbuscarmedicamento.Location = new System.Drawing.Point(489, 21);
            this.btnbuscarmedicamento.Name = "btnbuscarmedicamento";
            this.btnbuscarmedicamento.Size = new System.Drawing.Size(95, 28);
            this.btnbuscarmedicamento.TabIndex = 1;
            this.btnbuscarmedicamento.Text = "Buscar";
            this.btnbuscarmedicamento.UseVisualStyleBackColor = false;
            this.btnbuscarmedicamento.Click += new System.EventHandler(this.Btnbuscarmedicamento_Click);
            // 
            // txtcodigomedicamento
            // 
            this.txtcodigomedicamento.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtcodigomedicamento.Location = new System.Drawing.Point(147, 26);
            this.txtcodigomedicamento.Name = "txtcodigomedicamento";
            this.txtcodigomedicamento.Size = new System.Drawing.Size(138, 27);
            this.txtcodigomedicamento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Medicamento:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cantidad,
            this.Indicaciones,
            this.Expediente,
            this.IdReceta,
            this.IdMedicina});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(12, 369);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(633, 148);
            this.dataGridView1.TabIndex = 64;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.DataGridView1_DoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Indicaciones
            // 
            this.Indicaciones.HeaderText = "Indicaciones";
            this.Indicaciones.Name = "Indicaciones";
            // 
            // Expediente
            // 
            this.Expediente.HeaderText = "Expediente";
            this.Expediente.Name = "Expediente";
            // 
            // IdReceta
            // 
            this.IdReceta.HeaderText = "IdReceta";
            this.IdReceta.Name = "IdReceta";
            // 
            // IdMedicina
            // 
            this.IdMedicina.HeaderText = "IdMedicina";
            this.IdMedicina.Name = "IdMedicina";
            // 
            // btnactualizarreceta
            // 
            this.btnactualizarreceta.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnactualizarreceta.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnactualizarreceta.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnactualizarreceta.Location = new System.Drawing.Point(179, 535);
            this.btnactualizarreceta.Name = "btnactualizarreceta";
            this.btnactualizarreceta.Size = new System.Drawing.Size(130, 44);
            this.btnactualizarreceta.TabIndex = 3;
            this.btnactualizarreceta.Text = "Actualizar";
            this.btnactualizarreceta.UseVisualStyleBackColor = false;
            this.btnactualizarreceta.Click += new System.EventHandler(this.Btnactualizarreceta_Click);
            // 
            // btnregresar
            // 
            this.btnregresar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnregresar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnregresar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnregresar.Location = new System.Drawing.Point(515, 535);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(130, 44);
            this.btnregresar.TabIndex = 5;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = false;
            this.btnregresar.Click += new System.EventHandler(this.Btnregresar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnguardar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnguardar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnguardar.Location = new System.Drawing.Point(12, 535);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(133, 44);
            this.btnguardar.TabIndex = 2;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.Btnguardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Rockwell Condensed", 27.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(223, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 44);
            this.label5.TabIndex = 77;
            this.label5.Text = "Control de Recetas";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(121, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 27);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(117, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 78;
            this.label6.Text = "Expediente:";
            // 
            // btninhabilitarreceta
            // 
            this.btninhabilitarreceta.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btninhabilitarreceta.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btninhabilitarreceta.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btninhabilitarreceta.Location = new System.Drawing.Point(349, 535);
            this.btninhabilitarreceta.Name = "btninhabilitarreceta";
            this.btninhabilitarreceta.Size = new System.Drawing.Size(130, 44);
            this.btninhabilitarreceta.TabIndex = 4;
            this.btninhabilitarreceta.Text = "Inhabilitar";
            this.btninhabilitarreceta.UseVisualStyleBackColor = false;
            this.btninhabilitarreceta.Click += new System.EventHandler(this.Btninhabilitarreceta_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(363, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 81;
            this.label8.Text = "Medico:\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(370, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 82;
            this.label9.Text = "         ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;

            this.pictureBox1.Location = new System.Drawing.Point(108, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // FrmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Clinica.Properties.Resources.af778ff1_007d_48c9_bb30_bafa73b5d392;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(666, 591);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btninhabilitarreceta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnactualizarreceta);
            this.Controls.Add(this.btnregresar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Recetas";
            this.Load += new System.EventHandler(this.FrmReceta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericcabtidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.TextBox txtprescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericcabtidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnbuscarmedicamento;
        private System.Windows.Forms.TextBox txtcodigomedicamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnactualizarreceta;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btninhabilitarreceta;
        private System.Windows.Forms.TextBox txtcodigoreceta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indicaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReceta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMedicina;
    }
}