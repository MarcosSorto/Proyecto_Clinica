using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Proyecto_Clinica
{
    public partial class FrmEnfermedades : Form
    {
        public FrmEnfermedades()
        {
            InitializeComponent();
        }

        private void FrmEnfermedades_Load(object sender, EventArgs e)
        {
            LimpiarDatos();

        }


        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(txtNombreEnfermedad.Text==""|| txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe de ingresar el nombre y la descripcion de la enfermedad", "Error en ingreso", MessageBoxButtons.OK);

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
                    Comando.CommandText = String.Format("sp_AgregarEnfermedad");
                    Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", txtNombreEnfermedad.Text));
                    Comando.Parameters.AddWithValue("Descripcion", String.Format("{0}", txtDescripcion.Text));
                    Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["Msj"].Value.ToString();
                    Comando.Dispose();

                    LimpiarDatos();
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

        private void TxtNombreEnfermedad_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se encaga de limpiar los datos ingresados
        /// </summary>
        public void LimpiarDatos()
        {
            txtDescripcion.Text = "";
            txtNombreEnfermedad.Text = "";
            txtNombreEnfermedad.Focus();
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnInhabilitar.Enabled = false;
            txtnuevoNombre.Text = "";
            txtnuevoNombre.Visible = false;
            lblnuevoNombre.Visible = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            // Verificamos si hay datos ingresados para guardar.
            if(txtDescripcion.Text=="" || txtNombreEnfermedad.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre y una descripción", "Error en ingreso", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_EditarEnfermedad");
                    Comando.Parameters.AddWithValue("nombre", String.Format("{0}", txtNombreEnfermedad.Text));
                    Comando.Parameters.AddWithValue("descripcion", String.Format("{0}", txtDescripcion.Text));
                    Comando.Parameters.AddWithValue("nuevoNombre", String.Format("{0}", txtnuevoNombre.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();

                    LimpiarDatos();
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

        private void BtnInhabilitar_Click(object sender, EventArgs e)
        {
            if (txtNombreEnfermedad.Text == "" || txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe seleccionar una enfermedad para inhabilitarla", "Error en ingreso", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_EditarEnfermedad");
                    Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", txtNombreEnfermedad.Text));
                    Comando.Parameters.AddWithValue("Descripcion", String.Format("{0}", txtDescripcion.Text));
                    Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["Msj"].Value.ToString();
                    Comando.Dispose();

                    LimpiarDatos();
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

        private void TxtNombreEnfermedad_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarEnfermedad");
                Comando.Parameters.AddWithValue("nombre", String.Format("{0}", txtNombreEnfermedad.Text));
                Comando.Parameters.Add("descripcion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                txtDescripcion.Text = Comando.Parameters["descripcion"].Value.ToString();
                Comando.Dispose();

                if (txtDescripcion.Text!="")
                {
                    txtnuevoNombre.Visible = true;
                    lblnuevoNombre.Visible = true;
                    btnAgregar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnInhabilitar.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Error al momento de cargar enfermedad");
            }
        }
    }
}
