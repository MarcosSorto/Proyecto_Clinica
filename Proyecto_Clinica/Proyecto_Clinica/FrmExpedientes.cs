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
    public partial class FrmExpedientes : Form
    {

      

        string codigo;
        public static string cod;
        public static string Medico;
        public static int guardado = 0;
        public static string NombrePaciente;

        
        public FrmExpedientes()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (tcodigo.Text=="")
            {
                MessageBox.Show("Debe guardar el registro primero,¡Revise!", "Error en ingreso", MessageBoxButtons.OK);
            }
            else
            {
                cod = txtreceta.Text;
                Medico = txtnomM.Text;
                FrmReceta nuevo = new FrmReceta();
                
                nuevo.ShowDialog();

            }
        }

        public  void Cargar_Datos(string s)
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
                if (s == "sp_EditarExpediente")
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format(s);
                    Comando.Parameters.AddWithValue("Fecha", String.Format("{0}", dateTimePicker1.Value.Date.ToString()));
                    Comando.Parameters.AddWithValue("Paciente", String.Format("{0}", maskedTextBox1.Text));
                    Comando.Parameters.AddWithValue("Medico", String.Format("{0}", maskedTextBox2.Text));
                    Comando.Parameters.AddWithValue("Encargado", String.Format("{0}", maskedTextBox3.Text));
                    Comando.Parameters.AddWithValue("Peso", String.Format("{0}", txtpeso.Text));
                    Comando.Parameters.AddWithValue("Estatura", String.Format("{0}", txtestatura.Text));
                    Comando.Parameters.AddWithValue("Presion", String.Format("{0}", txtpresion.Text));
                    Comando.Parameters.AddWithValue("Temperatura", String.Format("{0}", txttemperatura.Text));
                    Comando.Parameters.AddWithValue("Observacion", String.Format("{0}", txtobservacion.Text));
                    Comando.Parameters.AddWithValue("Codigo", String.Format("{0}", tcodigo.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    cod = Comando.Parameters["Codigo"].Value.ToString();
                    NombrePaciente = txtnombreP.Text;
                    Transacsion.Commit();
                    MessageBox.Show(m);
                }
                else
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format(s);
                    Comando.Parameters.AddWithValue("Fecha", String.Format("{0}", dateTimePicker1.Value.Date.ToString()));
                    Comando.Parameters.AddWithValue("Paciente", String.Format("{0}", maskedTextBox1.Text));
                    Comando.Parameters.AddWithValue("Medico", String.Format("{0}", maskedTextBox2.Text));
                    Comando.Parameters.AddWithValue("Encargado", String.Format("{0}", maskedTextBox3.Text));
                    Comando.Parameters.AddWithValue("Peso", String.Format("{0}", txtpeso.Text));
                    Comando.Parameters.AddWithValue("Estatura", String.Format("{0}", txtestatura.Text));
                    Comando.Parameters.AddWithValue("Presion", String.Format("{0}", txtpresion.Text));
                    Comando.Parameters.AddWithValue("Temperatura", String.Format("{0}", txttemperatura.Text));
                    Comando.Parameters.AddWithValue("Observaciones", String.Format("{0}", txtobservacion.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.Parameters.Add("Codigo", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    codigo = Comando.Parameters["Codigo"].Value.ToString();
                    cod = codigo;
                    tcodigo.Text = codigo;
                    Medico = txtnomM.Text;
                    NombrePaciente = txtnombreP.Text;
                    txtreceta.Text = codigo;
                    Comando.Dispose();
                    Transacsion.Commit();
                    MessageBox.Show(m);

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Hay problemas en los datos ingresados");
                Transacsion.Rollback();
            }

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btnguardar_Click(object sender, EventArgs e)

        {
            if ( tcodigo.Text=="")
            {
                Cargar_Datos("sp_AgregarExpediente");
                Limpiar();
            }
            else
            {
                Cargar_Datos("sp_EditarExpediente");
                Limpiar();

            }
            

        }

        private void Btnbuscarmedicamento_Click(object sender, EventArgs e)
        {
            FrmBuscarPaciente nuevo = new FrmBuscarPaciente();
            nuevo.ShowDialog();
            txtnombreP.Text = FrmBuscarPaciente.NombrePaciente;
            maskedTextBox1.Text = FrmBuscarPaciente.IdentidadPaciente;
            
        }

        private void FrmExpedientes_Load(object sender, EventArgs e)
        {
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FrmBuscarMedico nuevo = new FrmBuscarMedico();
            nuevo.ShowDialog();
            txtnomM.Text = FrmBuscarMedico.NombreMedico;
            maskedTextBox2.Text = FrmBuscarMedico.IdentidadMedico;

        }

        private void Btnregresar_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FrmBuscarEnfermera nuevo = new FrmBuscarEnfermera();
            nuevo.ShowDialog();

            maskedTextBox3.Text = FrmBuscarEnfermera.IdentidadEncargada;
            txtenM.Text = FrmBuscarEnfermera.NombreEncargada;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FrmBuscarPacienteConsulta nuevo = new FrmBuscarPacienteConsulta();
            nuevo.ShowDialog();
            tcodigo.Text = FrmBuscarPacienteConsulta.codigo;
            maskedTextBox1.Text = FrmBuscarPacienteConsulta.paciente;
            maskedTextBox2.Text = FrmBuscarPacienteConsulta.medico;
            txtnombreP.Text = FrmBuscarPacienteConsulta.nombreP;;
            txtreceta.Text = FrmBuscarPacienteConsulta.codigo;
            
        }

        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            Cargar_Datos("sp_EditarExpediente");
        }

        private void Tcodigo_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Tcodigo_TextChanged(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarExpediente");
                Comando.Parameters.AddWithValue("Codigo", String.Format("{0}", tcodigo.Text));
                Comando.Parameters.AddWithValue("Medico", String.Format("{0}", maskedTextBox2.Text));

                
                Comando.Parameters.Add("Idenfermera", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Nenfermera", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("NMedico", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Peso", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Estatura", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Temperatura", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Presion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Observacion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                txtnomM.Text = Comando.Parameters["NMedico"].Value.ToString();
                txtenM.Text = Comando.Parameters["Nenfermera"].Value.ToString();
                txtpeso.Text = Comando.Parameters["Peso"].Value.ToString();
                txtestatura.Text = Comando.Parameters["Estatura"].Value.ToString();
                txttemperatura.Text = Comando.Parameters["Temperatura"].Value.ToString();
                txtpresion.Text = Comando.Parameters["Presion"].Value.ToString();
                txtobservacion.Text = Comando.Parameters["Observacion"].Value.ToString();
                maskedTextBox3.Text = Comando.Parameters["Idenfermera"].Value.ToString();

            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
            }
            //button4.Visible = true;
            button3.Visible =true;
        }

        private void Limpiar()
        {
            //tcodigo.Text = "";
            //maskedTextBox1.Text = "";
            //maskedTextBox2.Text = "";
            //maskedTextBox3.Text = "";
            //txtnombreP.Text = "";
            //txtnomM.Text = "";
            //txtenM.Text = "";
            //txtpeso.Text = "";
            //txtestatura.Text = "";
            //txtpresion.Text = "";
            //txttemperatura.Text = "";
            //txtobservacion.Text = "";
            //txtreceta.Text = "";
            

        }
        private void Txtreceta_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtpeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btninhabilitar_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(txtenM.Text=="" || txtnombreP.Text=="" || txtnomM.Text == "")
            {
                MessageBox.Show("Debe especificar el médico el paciente y el encargado para acceder.");
            }
            else
            {
                    if (tcodigo.Text=="")
                    {
                        Cargar_Datos("sp_AgregarExpediente");
                        frmEnfermedadExpediente nuevo = new frmEnfermedadExpediente();
                        nuevo.ShowDialog();
                    }
                    else
                    {
                        frmEnfermedadExpediente nuevo = new frmEnfermedadExpediente();
                        Cargar_Datos("sp_EditarExpediente");
                        nuevo.ShowDialog();
                    }   
            }            
        }
    }
}
