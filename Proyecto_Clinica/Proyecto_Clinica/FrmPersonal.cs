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
    public partial class FrmPersonal : Form
    {
        public static string identidad;
        public static int valor = 2;
        public FrmPersonal()
        {
            InitializeComponent();
        }

        private void Btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPersonal_Load(object sender, EventArgs e)
        {
           
        }

        private void Limpiar()
        {
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Focus();
            btnactualizar.Enabled = false;
            btnInhabilitar.Enabled = false;
            
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text=="" || textBox2.Text=="" || comboBox1.SelectedIndex ==-1)
            {
                MessageBox.Show("Debe de ingresar la identidad y los demas datos del personal", "Control de personal", MessageBoxButtons.OK);

            }
            else
            {
                identidad = maskedTextBox1.Text;
                Cargar_Datos("sp_AgregarEnfermera");

                DialogResult res = MessageBox.Show("¿Desea registar teléfono(s) para el médico?", "Control de Médicos", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    FrmTelefono nuevo = new FrmTelefono();
                   
                    nuevo.ShowDialog();
                    valor = 0;
                    Limpiar();
                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void Cargar_Datos(string s)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format(s);
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBox1.Text));
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", textBox2.Text));
                Comando.Parameters.AddWithValue("Apellido", String.Format("{0}", textBox3.Text));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", textBox4.Text));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", textBox5.Text));
                Comando.Parameters.AddWithValue("Cargo", String.Format("{0}", comboBox1.SelectedItem.ToString()));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                Limpiar();
                btnguardar.Enabled = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            MessageBox.Show(m);
        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MaskedTextBox1_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_ListarEnfermera");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBox1.Text));


                Comando.Parameters.Add("Nombre", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Apellido", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Direccion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Correo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Cargo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                textBox2.Text = Comando.Parameters["Nombre"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                textBox3.Text = Comando.Parameters["Apellido"].Value.ToString();
                textBox4.Text = Comando.Parameters["Direccion"].Value.ToString();
                comboBox1.SelectedItem = Comando.Parameters["Cargo"].Value.ToString();
                textBox5.Text = Comando.Parameters["Correo"].Value.ToString();
                Comando.Dispose();
                // Evaluamos si el personal existe
                // m == null -- si existe
                // m != null ---no existe
                if (m == null || m == "")
                {

                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    btnInhabilitar.Enabled = true;
                }
                else
                {
                    if (m != "Enfermera no se encuetra registrado")
                    {
                        MessageBox.Show(m);
                        Limpiar();
                    }
                    else
                    {
                        btnguardar.Enabled = true;
                        btnactualizar.Enabled = false;
                        btnInhabilitar.Enabled = false;
                    }


                }

            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de personal", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Cargar_Datos("sp_EditarEnfermera");

            }
            else
            {
                Limpiar();
            }
        }

        private void BtnInhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar el registro?", "Control de personal", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Cargar_Datos("sp_InhabilitarEnfermera");

            }
            else
            {
                Limpiar();
            }
            
        }

        private void MaskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
