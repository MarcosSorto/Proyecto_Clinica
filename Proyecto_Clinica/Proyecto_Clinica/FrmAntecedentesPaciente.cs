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
    public partial class FrmAntecedentesPaciente : Form
    {
        public FrmAntecedentesPaciente()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            txtidentidad.Text = "";
            txtalimentos.Text = "";
            txtmedicamentos.Text = "";
            txtotros.Text = "";
            txtcronicos.Text = "";
            txtcirugias.Text = "";
            txtnombre.Text = "";
            txtidentidad.Focus();
        }

        private void txtguardar_Click(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "")
            {
                MessageBox.Show("Hay espacios en blanco en el formulario", "Control de Pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AgregarAntecedenteP");
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", txtidentidad.Text));
                    Comando.Parameters.AddWithValue("AlergiaA", String.Format("{0}", txtalimentos.Text));
                    Comando.Parameters.AddWithValue("AlergiaM", String.Format("{0}", txtmedicamentos.Text));
                    Comando.Parameters.AddWithValue("OAlergia", String.Format("{0}", txtotros.Text));
                    Comando.Parameters.AddWithValue("EnfermedadC", String.Format("{0}", txtcronicos.Text));
                    Comando.Parameters.AddWithValue("TratamientoM", String.Format("{0}", txtcirugias.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    limpiar();
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
            }




        }

        private void txtactualizar_Click(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "")
            {
                MessageBox.Show("Debe de ingresar la identidad del paciente", "Control de Pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;

                try
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_EditarAntecedenteP");
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", txtidentidad.Text));
                    Comando.Parameters.AddWithValue("AlergiaA", String.Format("{0}", txtalimentos.Text));
                    Comando.Parameters.AddWithValue("AlergiaM", String.Format("{0}", txtmedicamentos.Text));
                    Comando.Parameters.AddWithValue("OAlergia", String.Format("{0}", txtotros.Text));
                    Comando.Parameters.AddWithValue("EnfermedadC", String.Format("{0}", txtcronicos.Text));
                    Comando.Parameters.AddWithValue("TratamientoM", String.Format("{0}", txtcirugias.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    limpiar();
                }
                catch (MySqlException ex)
                {

                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
            }
        }

        private void txtidentidad_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarAntecendente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", txtidentidad.Text));


                Comando.Parameters.Add("AlergiaA", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("AlergiaM", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("OAlergia", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("EnfermedadC", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("TratamientoM", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                txtalimentos.Text = Comando.Parameters["AlergiaA"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                txtmedicamentos.Text = Comando.Parameters["AlergiaM"].Value.ToString();
                txtotros.Text = Comando.Parameters["OAlergia"].Value.ToString();
                txtcronicos.Text = Comando.Parameters["EnfermedadC"].Value.ToString();
                txtcirugias.Text = Comando.Parameters["TratamientoM"].Value.ToString();
                Comando.Dispose();

                if (m == null || m == "")
                {

                    txtguardar.Enabled = true;
                    txtactualizar.Enabled = true;
                }
                else
                {
                    if (m != "El paciente no se encuetra registrado")
                    {
                        MessageBox.Show(m);
                        limpiar();
                    }
                    else
                    {
                        txtguardar.Enabled = true;
                        txtactualizar.Enabled = false;
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

        private void txtsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAntecedentesPaciente_Load(object sender, EventArgs e)
        {
            txtidentidad.Text = FrmPacientes.identidad;
            txtnombre.Text = FrmPacientes.nombre;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtidentidad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
