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
    public partial class FrmBuscarEnfermera : Form
    {
        // Declaramos las variables a utilizar
        public static string IdentidadEncargada;
        public static string NombreEncargada;
        private DataTable tabla = new DataTable();
        public FrmBuscarEnfermera()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                IdentidadEncargada = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                NombreEncargada = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

                MessageBox.Show(IdentidadEncargada);
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
            if (s == "sp_listarPersonalIdentidad")
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
            dataGridView1.Rows[x].Cells[3].Value = tabla.Rows[x][3].ToString();
            }
    }

        private void Button1_Click(object sender, EventArgs e)
        {
            BuscarCualquiera("sp_listarPersonalTodo");
        }

        private void MaskedTextBox1_Leave(object sender, EventArgs e)
        {
            BuscarCualquiera("sp_listarPersonalIdentidad");
        }

        private void FrmBuscarEnfermera_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
