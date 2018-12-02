using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Agregamos los namesPaces necesarios.
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_Clinica
{
    public partial class frmEnfermedadExpediente : Form
    {

        private DataTable tabla = new DataTable();
        public frmEnfermedadExpediente()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount==0){
                MessageBox.Show("No hay enfermedades para guardar", "Registro vacío");
            }
            else
            {
                MessageBox.Show("Enfermedades registradas satifactoriamente", "Control de enfermedades");
                MessageBox.Show("regresando al expediente del paciente...");
                this.Close();
            }

        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtenfermedad.Text == "" && txtcodigo.Text == "")
            {
                MessageBox.Show("Hay espacios en blanco", "Control de enfermedades", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_AgregarEnfermedadConsulta");
                    Comando.Parameters.AddWithValue("codigoExpediente", String.Format("{0}", txtExpediente.Text));
                    Comando.Parameters.AddWithValue("codigoEnfermedad", String.Format("{0}", txtcodigo.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();

                    // Actualizamos los datos del datagrid
                    BuscarCualquiera();
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);

                txtenfermedad.Text = "";
                txtcodigo.Text = "";
                txtcodigo.Focus();


            }
        }

            private void BuscarCualquiera()
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
                    tabla.Reset();
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_ListarEnfermedadConsulta");
                    Comando.Parameters.AddWithValue("Ex", String.Format("{0}", txtExpediente.Text));
                    Comando.ExecuteNonQuery();
                    adaptador.SelectCommand = Comando;

                    adaptador.Fill(tabla);
                    Llenar_grid();
                    Transacsion.Commit();
                }
                catch (Exception)
                {
                    Transacsion.Rollback();

                }

            }

        private void Llenar_grid()
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = tabla;
            for (int x = 0; x < tabla.Rows.Count; x++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells[0].Value = tabla.Rows[x][0].ToString();
                dataGridView1.Rows[x].Cells[1].Value = tabla.Rows[x][1].ToString();
                dataGridView1.Rows[x].Cells[2].Value = tabla.Rows[x][2].ToString();
            }
        }

        private void frmEnfermedadExpediente_Load(object sender, EventArgs e)
        {
            txtPaciente.Text = FrmExpedientes.NombrePaciente;
            txtExpediente.Text = FrmExpedientes.cod;
            BuscarCualquiera();
            txtcodigo.Focus();
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text=="")
            {
                MessageBox.Show("No ha seleccionado nada a eliminar", "Control de Recetas", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_EliminarEnfermedadConsulta");
                    Comando.Parameters.AddWithValue("EX", String.Format("{0}", txtExpediente.Text));
                    Comando.Parameters.AddWithValue("codigoEnfermedad", String.Format("{0}", txtcodigo.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    // actualizamos el datgrid
                    BuscarCualquiera();
                    btnagregar.Visible = true;
                    MessageBox.Show(m);
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
           
            
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

               txtenfermedad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
              txtcodigo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                btnagregar.Visible = false;
            }
        }
    }
}
