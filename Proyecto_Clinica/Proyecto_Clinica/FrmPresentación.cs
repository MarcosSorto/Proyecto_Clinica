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
    public partial class FrmPresentacion : Form
    {
        public FrmPresentacion()
        {
            InitializeComponent();
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            TextCod.Visible = false;
            LabelCod.Visible = false;
            btnEditar.Visible = false;
            btnactualizar.Enabled = false;
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar()
        {
            textBoxDesc.Text = "";
            LabelCod.Text = "codigo";
            textBoxDesc.Focus();

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (textBoxDesc.Text == "")
            {
                MessageBox.Show("Debe de ingresar el nombre de la presentación", "Control de presentación", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_AgregarPresentacion");
                    Comando.Parameters.AddWithValue("nombre", String.Format("{0}", textBoxDesc.Text));
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

        private void cargar_datos(string s)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            MySqlTransaction Transacsion;
            Transacsion = con.Conexion.BeginTransaction();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format(s);
                Comando.Parameters.AddWithValue("nombre", String.Format("{0}", textBoxDesc.Text));
                Comando.Parameters.AddWithValue("Cod", String.Format("{0}", LabelCod.Text.ToString()));


                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                limpiar();
                btnguardar.Enabled = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
                Transacsion.Rollback();
            }
            MessageBox.Show(m);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*TextCod.Visible = true;
            LabelCod.Visible = true;*/
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarPresentacion");
                Comando.Parameters.AddWithValue("nombre", String.Format("{0}", textBoxDesc.Text));

                Comando.Parameters.Add("Cod", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();

                LabelCod.Text = Comando.Parameters["Cod"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                // m == null -- si existe
                // m != null ---no existe
                if (m == null || m == "")
                {
                    textBoxDesc.Enabled = false;
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    btninhabilitar.Enabled = true;
                    btnEditar.Visible = true;
                    TextCod.Visible = true;
                    LabelCod.Visible = true;
                    btninhabilitar.Enabled = true;
                }
                else
                {
                    btnguardar.Enabled = true;
                    btnactualizar.Enabled = false;
                    TextCod.Visible = false;
                    LabelCod.Visible = false;
                    btnEditar.Visible = false;
                    btninhabilitar.Enabled = false;
                    if (m != "No se encuetra registro")
                    {
                        MessageBox.Show(m);
                        //limpiar();
                    }
                    else
                    {
                        btnguardar.Enabled = true;
                        btnactualizar.Enabled = false;
                        btninhabilitar.Enabled = false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            textBoxDesc.Enabled = true;
            btnactualizar.Enabled = true;
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_EditarPresentacion");
            }
            else
            {
                limpiar();
            }
            btnEditar.Visible = false;
            LabelCod.Visible = false;
            TextCod.Visible = false;
        }

        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_InhabilitarPresentacion");
            }
            else
            {
                limpiar();
            }
            textBoxDesc.Enabled = true;
        }
    }
}
