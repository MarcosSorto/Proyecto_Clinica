using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_Clinica
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void FrmLogin_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
           int m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_VerificaUsuario");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBox1.Text));
                Comando.Parameters.AddWithValue("Contrasenia", String.Format("{0}", textBox1.Text));

                Comando.Parameters.Add("Existe", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();



                m = Convert.ToInt16( Comando.Parameters["Existe"].Value.ToString());

                Comando.Dispose();
                // Evaluamos si el paciente existe
                // m == null -- si existe
                // m != null ---no existe
                if (m >= 1)
                {
                    MessageBox.Show("Acceso Permitido, Bienvenido", "Control de Acceso", MessageBoxButtons.OK);
                    FrmMenuPrincipal nuevo = new FrmMenuPrincipal();
                    this.Hide();
                    nuevo.Visible = true;
                }
                else
                {

                    MessageBox.Show("Acceso Denegado, Revise los datos", "Control de Acceso", MessageBoxButtons.OK);
                    maskedTextBox1.Text = "";
                    textBox1.Text = "";
                    maskedTextBox1.Focus();

                }

                

            }
            catch (Exception)
            {
                MessageBox.Show("Error Encontrado al realizar conexión");
            }
           
            
        }
    }
}
