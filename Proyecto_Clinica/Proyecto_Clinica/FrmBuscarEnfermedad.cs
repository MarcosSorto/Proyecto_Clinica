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
    public partial class FrmBuscarEnfermedad : Form
    {
        private DataTable tabla = new DataTable();
        public static string nombre;
        public static string descripcion;
        public static string codigo;

        public FrmBuscarEnfermedad()
        {
            InitializeComponent();
        }

        private void FrmBuscarEnfermedad_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarCualquiera("sp_listarTodoEnfermedad");
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
                Comando.ExecuteNonQuery();
                adaptador.SelectCommand = Comando;

                adaptador.Fill(tabla);
                llenar_grid();

                Transacsion.Commit();
            }
            catch (Exception)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

                nombre = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                descripcion = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                codigo = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);

                MessageBox.Show(nombre);
                this.Close();
            }
            else
                MessageBox.Show("debe de seleccionar una fila");
        }
    }
}
