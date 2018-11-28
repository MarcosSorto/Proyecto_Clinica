using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {

            InitializeComponent();
            timer1.Interval = 3000;
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            if (con.Estado_Conexion == 0)
            {
                MessageBox.Show("No se ha establecido la conexión con el servidor", "Conexión con el servidor", MessageBoxButtons.OK);
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Conexión con el servidor establecida satifactoriamente", "Conexión con el servidor", MessageBoxButtons.OK);
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.DialogResult = DialogResult.OK;
            this.Hide();
            FrmLogin contrasenia = new FrmLogin();
            contrasenia.Visible = true;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
