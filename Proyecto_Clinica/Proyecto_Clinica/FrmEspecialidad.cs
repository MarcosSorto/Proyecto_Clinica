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
    public partial class FrmEspecialidad : Form
    {
        public String actualizar;
        public FrmEspecialidad()
        {
            InitializeComponent();
        }
        private void limpiar()
        {
            txtEspecialidad.Text = "";
            txtCambio.Text = "";
            LbCambio.Visible = false;
            txtCambio.Visible = false;
            btnactualizar.Text = "Actualizar";
            txtEspecialidad.Focus();

        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtEspecialidad.Text == "")
            {
                MessageBox.Show("Debe de ingresar la Especialidad", "Control de Especialidades", MessageBoxButtons.OK);

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
                    //msj.ms_ok(ComDepartamento.SelectedValue.ToString());
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AgregarEspecialidad");
                    Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", txtEspecialidad.Text));

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
                Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", txtEspecialidad.Text));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                limpiar();
                btnguardar.Visible = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            MessageBox.Show(m);
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (btnactualizar.Text == "Actualizar")
            {
                btnactualizar.Text = "Guardar";
                LbCambio.Visible = true;
                txtCambio.Visible = true;
            }
            else //si es igual a guardar
            {
                if (btnactualizar.Text == "Guardar")
                {
                    if (txtCambio.Text == "")
                    {
                        MessageBox.Show("Revise, hay datos importantes sin llenar", "Control de especialidades", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DialogResult s;
                        s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de especialidades", MessageBoxButtons.YesNo);
                        if (s == DialogResult.Yes)
                        {
                            Cargar_Datos("sp_EditarEspecialidad");

                        }
                        else
                        {
                            limpiar();
                        }
                    }
                }
            }
        }

        //solo para actualizar
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
                Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", txtEspecialidad.Text));
                Comando.Parameters.AddWithValue("Cambio", String.Format("{0}", txtCambio.Text));
                Comando.Parameters.AddWithValue("Codigo", String.Format("{0}", actualizar));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                limpiar();
                btnguardar.Visible = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            MessageBox.Show(m);

        }


        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar Especialidad?", "Control de Especialidades", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos("sp_InhabilitarEspecialidad");

            }
            else
            {
                limpiar();
            }

        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtEspecialidad_TextChange(object sender, EventArgs e)
        {

        }

        private void txtEspecialidad_Leave(object sender, EventArgs e)
        {
        }

        private void FrmEspecialidad_Load(object sender, EventArgs e)
        {

        }
    }
}
