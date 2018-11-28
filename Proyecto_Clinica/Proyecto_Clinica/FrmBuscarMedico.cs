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
    public partial class FrmBuscarMedico : Form
    {
        // Declaramos las variables a utilizar
        public static string IdentidadMedico;
        public static string NombreMedico;
        private DataTable tabla = new DataTable();
        public FrmBuscarMedico()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                IdentidadMedico = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
               NombreMedico = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

                MessageBox.Show(IdentidadMedico + " " + NombreMedico);
                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
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
                if (s == "sp_buscarMedicoIdentidad")
                {
                    Comando.Parameters.AddWithValue("Id", String.Format("{0}", maskedTextBox1.Text));
                    Comando.Parameters.AddWithValue("Nom", String.Format("{0}", textBox1.Text));

                }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            BuscarCualquiera("sp_listarTodosMedicos");
            
        }

        private void FrmBuscarMedico_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
