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
    public partial class FrmBuscarPaciente : Form
    {
        // Declaramos las variables a utilizar
        public static string    IdentidadPaciente;
        public  static string NombrePaciente;
        private DataTable tabla = new DataTable();
        public FrmBuscarPaciente()
        {
            InitializeComponent();
            
        }

        private void FrmBuscarPaciente_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buscarCualquiera(String s)
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
                if (s == "sp_buscarPacienteIdentidad")
                {
                    Comando.Parameters.AddWithValue("Id", String.Format("{0}", maskedTextBox1.Text));
                    Comando.Parameters.AddWithValue("Nom", String.Format("{0}", textBox1.Text));

                }
                
                Comando.ExecuteNonQuery();
                adaptador.SelectCommand = Comando;

                adaptador.Fill(tabla);
                llenar_grid();
             
                Transacsion.Commit();
            }
            catch (MySqlException ex)
            {
                Transacsion.Rollback();

            }

        }

        private void llenar_grid()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MarginChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskChanged(object sender, EventArgs e)
        {
            

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarCualquiera("sp_listarTodosPaciente");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                IdentidadPaciente = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                NombrePaciente = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
        
                MessageBox.Show(IdentidadPaciente + " " + NombrePaciente);
                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            buscarCualquiera("sp_buscarPacienteIdentidad");
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            buscarCualquiera("sp_buscarPacienteIdentidad");
        }
    }
}
