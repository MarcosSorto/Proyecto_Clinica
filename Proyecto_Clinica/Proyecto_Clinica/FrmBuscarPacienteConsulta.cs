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

 
    public partial class FrmBuscarPacienteConsulta : Form
    {
        private DataTable tabla = new DataTable();
        public static string codigo;
        public static string paciente;
        public static string medico;
        public static string nombreP;
        public FrmBuscarPacienteConsulta()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BuscarCualquiera("Sp_ListarConsultas");
        }

        private void BuscarCualquiera(String s)
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
                Comando.CommandText = String.Format(s);
  
           
                    Comando.Parameters.AddWithValue("Medico", String.Format("{0}", maskedTextBox1.Text));
                    Comando.Parameters.AddWithValue("Fecha", String.Format("{0}", dateTimePicker1.Value.Date.ToString()));

                

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
                dataGridView1.Rows[x].Cells[3].Value = tabla.Rows[x][3].ToString();
            }
        }

        private void FrmBuscarPacienteConsulta_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {

               paciente= Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                nombreP = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                medico = maskedTextBox1.Text;
                codigo= Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
            

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.Close();
        }
    }
}
