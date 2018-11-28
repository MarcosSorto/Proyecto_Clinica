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
    public partial class FrmTelefono : Form
    {
        public FrmTelefono()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            maskedTextBoxID.Text = "";
            LabCOD.Text = "Código";
            textMascTel.Text = "";
            maskedTextBoxID.Focus();
            textMascTel.Focus();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxID.Text == "" && textMascTel.Text == "")
            {
                MessageBox.Show("Debe de ingresar La identidad y el teléfono de la persona", "Control de Teléfonos", MessageBoxButtons.OK);
            }
            else
            {
                cargar_datos("sp_AgregarTelefono");
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos2("sp_EditarTelefono");
            }
            else
            {
                limpiar();
            }
            btnBuscar.Visible = true;
            btnEditar.Visible = false;
            LabCOD.Visible = false;
            LBCoD.Visible = false;
        }

        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar el Teléfono?", "Control de Telefónos", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                cargar_datos2("sp_InhabilitarTelefono");

            }
            else
            {
                limpiar();
            }
            textMascTel.Enabled = true;
        }

        private void FrmTelefono_Load(object sender, EventArgs e)
        {
            limpiar();
            textMascTel.Focus();
            btnBuscar.Visible = true;
            btnEditar.Visible = false;
            LabCOD.Visible = false;
            LBCoD.Visible = false;
            int val = FrmMedicos.valor;
            if (val == 1)
            {
                maskedTextBoxID.Text = FrmMedicos.identidad;
            }
            else
            {
                maskedTextBoxID.Text = FrmPersonal.identidad;
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
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBoxID.Text));
                Comando.Parameters.AddWithValue("Telefono", String.Format("{0}", textMascTel.Text));

                //Comando.Parameters.Add("Cod", MySqlDbType.String).Direction = ParameterDirection.Output;

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                //Codigo = Comando.Parameters["Cod"].Value.ToString();
                Comando.Dispose();
                limpiar();
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



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarTelefono");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBoxID.Text));
                Comando.Parameters.AddWithValue("Telefono", String.Format("{0}", textMascTel.Text));

                Comando.Parameters.Add("Cod", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();

                LabCOD.Text = Comando.Parameters["Cod"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                // m == null -- si existe
                // m != null ---no existe
                if (m == null || m == "")
                {
                    textMascTel.Enabled = false;
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    btninhabilitar.Enabled = true;
                    btnEditar.Visible = true;
                    LabCOD.Visible = true;
                    LBCoD.Visible = true;
                    btninhabilitar.Enabled = true;
                }
                else
                {
                    btnguardar.Enabled = true;
                    btnactualizar.Enabled = false;
                    LabCOD.Visible = false;
                    LBCoD.Visible = false;
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
            textMascTel.Enabled = true;
        }

        private void cargar_datos2(string s)
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
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", maskedTextBoxID.Text));
                Comando.Parameters.AddWithValue("Telefono", String.Format("{0}", textMascTel.Text));
                Comando.Parameters.AddWithValue("Cod", String.Format("{0}", LabCOD.Text.ToString()));


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

    }
}
