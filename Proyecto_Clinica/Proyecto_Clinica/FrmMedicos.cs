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
    public partial class FrmMedicos : Form
    {

        public string CodigoE;
        public static string identidad;
        public static int valor = 1;
        private DataTable especialidadMedico= new DataTable();
        public FrmMedicos()
        {
            InitializeComponent();
            Actulizar_P();
        }

        private void Btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            MtxtIdentidad.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            CmbEspecialidad.Text = "";


        }
        private void Btnguardar_Click(object sender, EventArgs e)
        {

            MessageBox.Show(CmbEspecialidad.SelectedValue.ToString());
            if (MtxtIdentidad.Text == "" || txtNombres.Text == "" || txtApellidos.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || CmbEspecialidad.Text == "")

            {
                MessageBox.Show("Se requiere que complete la informacion", "Control de Medicos", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_AgregarMedico");
                    Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));
                    Comando.Parameters.AddWithValue("Nombres", String.Format("{0}", txtNombres.Text));
                    Comando.Parameters.AddWithValue("Apellidos", String.Format("{0}", txtApellidos.Text));
                    Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", txtDireccion.Text));
                    Comando.Parameters.AddWithValue("Correo", String.Format("{0}", txtCorreo.Text));
                    Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", CmbEspecialidad.SelectedValue.ToString()));

                    //Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", textBox7.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    Limpiar();
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

        public void Cargar_datos(string s)
        {
            
            MessageBox.Show(CodigoE.ToString());
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format(s);
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));
                Comando.Parameters.AddWithValue("Nombres", String.Format("{0}", txtNombres.Text));
                Comando.Parameters.AddWithValue("Apellidos", String.Format("{0}", txtApellidos.Text));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", txtDireccion.Text));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", txtCorreo.Text));
                MessageBox.Show(CodigoE);
                Comando.Parameters.AddWithValue("Especialidad", String.Format("{0}", CmbEspecialidad.SelectedValue.ToString()));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
               
                btnguardar.Enabled = true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            MessageBox.Show(m);

            DialogResult  res =MessageBox.Show("¿Desea registar teléfono(s) para el médico?", "Control de Médicos", MessageBoxButtons.YesNo);
            if ( res == DialogResult.Yes)
            {
                FrmTelefono nuevo = new FrmTelefono();
                identidad = MtxtIdentidad.Text;
                nuevo.ShowDialog();
                valor = 0;
                Limpiar();
            }
            else
            {
                Limpiar();
            }
            
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea guardar los datos?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Cargar_datos("sp_EditarMedico");

            }
            else
            {
                Limpiar();
            }
        }

        private void Btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar Especialidad?", "Control de Especialidades", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Cargar_datos("sp_InhabilitarMedico");

            }
            else
            {
                Limpiar();
            }
        }

        private void MtxtIdentidad_Leave(object sender, EventArgs e)
        {
            if(MtxtIdentidad.Text != "0000-0000-00000") { 
             
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                CodigoE = "";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_ListarMedico");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", MtxtIdentidad.Text));


                Comando.Parameters.Add("Nombres", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Apellidos", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Direccion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Correo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Especialidad", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("NEspecialidad", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                
                m = Comando.Parameters["msj"].Value.ToString();
                txtNombres.Text = Comando.Parameters["Nombres"].Value.ToString();
                txtApellidos.Text = Comando.Parameters["Apellidos"].Value.ToString();
                txtDireccion.Text = Comando.Parameters["Direccion"].Value.ToString();
                txtCorreo.Text = Comando.Parameters["Correo"].Value.ToString();
                CmbEspecialidad.Text = Comando.Parameters["NEspecialidad"].Value.ToString();
                CodigoE = Comando.Parameters["Especialidad"].Value.ToString();

                Comando.Dispose();
                // Evaluamos si el paciente existe
                // m == null -- si existe
                // m != null ---no existe
                if (m == null || m == "")
                {

                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    btninhabilitar.Enabled = true;
                }
                else
                {
                    if (m != "El medico no se encuetra registrado" && m!= "La persona ingresada no es Médico")
                    {
                        MessageBox.Show(m);
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
       }

        private void Actulizar_P()
        {
            Clase_Conexion con = new Clase_Conexion();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            MySqlTransaction Transacsion;
            Transacsion = con.Conexion.BeginTransaction();
            Comando.Connection = con.Conexion;
            Comando.Transaction = Transacsion;
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            try
            {
                especialidadMedico.Reset();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarEspecialidadTodo");
                Comando.ExecuteNonQuery();
                adaptador.SelectCommand = Comando;

                adaptador.Fill(especialidadMedico);
                Transacsion.Commit();
            }
            catch (Exception)
            {
                Transacsion.Rollback();

            }
            CmbEspecialidad.DataSource = null;
            CmbEspecialidad.Items.Clear();
            CmbEspecialidad.ValueMember = especialidadMedico.Columns["Codigo"].ColumnName;
            CmbEspecialidad.DisplayMember = especialidadMedico.Columns["Nombre"].ColumnName;
            CmbEspecialidad.DataSource = especialidadMedico.DefaultView;
            CmbEspecialidad.SelectedIndex = -1;
            CmbEspecialidad.Text = "Seleccione una opción";
        }

        private void FrmMedicos_Load(object sender, EventArgs e)
        {
           
        }

        private void MtxtIdentidad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            FrmBuscarMedico nuevo = new FrmBuscarMedico();
            nuevo.ShowDialog();
            MtxtIdentidad.Text = FrmBuscarMedico.IdentidadMedico;
            txtNombres.Text = FrmBuscarMedico.NombreMedico;
            MtxtIdentidad.Focus();
        }
    }
}
