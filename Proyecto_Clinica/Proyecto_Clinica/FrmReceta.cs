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
    public partial class FrmReceta : Form
    {
        public String actualizar;
        public string codigoReceta;
        private DataTable tabla = new DataTable();
        public FrmReceta()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReceta_Load(object sender, EventArgs e)
        {
            //txtcodigoreceta.Enabled = false;
            textBox1.Text = FrmExpedientes.cod;
            txtcodigoreceta.Text = FrmExpedientes.cod;
            label9.Text = FrmExpedientes.Medico;
        }

        private void Limpiar()
        {
           
            txtcodigomedicamento.Text = "";
            numericcabtidad.Value = 0;
            txtprescripcion.Text = "";
            txtcodigomedicamento.Focus();
            dataGridView1.DataSource = null;
            label7.Text = "";
           
        }

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registro Guardado Satifactoriamente");
        }

        private void Btnactualizarreceta_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtcodigomedicamento.Text =="" || txtprescripcion.Text =="" ||numericcabtidad.Value==0)
            {
                MessageBox.Show("Hay Datos que necesitan ser ingresados", "Control de Receta", MessageBoxButtons.OK);
            }
            else
            {

           
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea actualizar la receta?", "Control de Receta", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Clase_Conexion con = new Clase_Conexion();
                String m;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_EditarReceta");
                    Comando.Parameters.AddWithValue("CodR", String.Format("{0}", textBox1.Text));
                    Comando.Parameters.AddWithValue("CodM", String.Format("{0}", txtcodigomedicamento.Text));
                    Comando.Parameters.AddWithValue("Cantidad", String.Format("{0}", numericcabtidad.Value));
                    Comando.Parameters.AddWithValue("Prescripcion", String.Format("{0}", txtprescripcion.Text));
                    Comando.Parameters.AddWithValue("codRe", String.Format("{0}", txtcodigoreceta.Text));
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    Limpiar();
                    // actualizamos el datagrid
                    BuscarCualquiera();
                    
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
                    btnagregar.Visible = true;

                }
            else
            {
                Limpiar();
                    btnagregar.Visible = true;
                }
            }
        }

        private void Btninhabilitarreceta_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar la receta?", "Control de Receta", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                //cargar_datos2("sp_InhabilitarTelefono");
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
                    Comando.CommandText = String.Format("sp_InhabilitarReceta");
                    Comando.Parameters.AddWithValue("CodR", String.Format("{0}", txtcodigoreceta.Text));


                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    Comando.Dispose();
                    Limpiar();
                    btnguardar.Visible = true;
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
            else
            {
                Limpiar();
            }
        }

        private void Txtcodigoreceta_Leave(object sender, EventArgs e)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarReceta");
                Comando.Parameters.AddWithValue("CodR", String.Format("{0}", txtcodigoreceta.Text));


                Comando.Parameters.Add("CodM", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Cantidad", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Prescripcion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                txtcodigomedicamento.Text = Comando.Parameters["CodM"].Value.ToString();
                numericcabtidad.Text = Comando.Parameters["Cantidad"].Value.ToString();
                txtprescripcion.Text = Comando.Parameters["Prescripcion"].Value.ToString();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();

                if (m == null || m == "")
                {

                    btnguardar.Visible = true;
                   
                }
                else
                {
                    if (m != "La Receta no se encuetra registrada")
                    {
                        MessageBox.Show(m);
                        Limpiar();
                    }
                    else
                    {
                        btnguardar.Visible = true;
                       
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

        private void Btnbuscarmedicamento_Click(object sender, EventArgs e)
        {
            FrmBuscarMedicina nuevo = new FrmBuscarMedicina();
            nuevo.ShowDialog();

            txtcodigomedicamento.Text = FrmBuscarMedicina.codigo;
            label7.Text = FrmBuscarMedicina.nombre;

        }

        private void Btnagregar_Click(object sender, EventArgs e)
        {
            if (txtcodigomedicamento.Text == "" || numericcabtidad.Value == 0 || txtprescripcion.Text == "")
            {
                MessageBox.Show("Hay espacios en blanco en el formulario", "Control de Recetas", MessageBoxButtons.OK);
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
                    Comando.CommandText = String.Format("sp_AgregarReceta");
                    Comando.Parameters.AddWithValue("CodM", String.Format("{0}", txtcodigomedicamento.Text));
                    Comando.Parameters.AddWithValue("Cantidad", String.Format("{0}", numericcabtidad.Value));
                    Comando.Parameters.AddWithValue("Prescripcion", String.Format("{0}", txtprescripcion.Text));
                    Comando.Parameters.AddWithValue("Expediente", String.Format("{0}", textBox1.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; 
                    Comando.Parameters.Add("codRe", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    codigoReceta = Comando.Parameters["codRe"].Value.ToString();
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


                // actualizamos el datagrid con los valores enviados
                BuscarCualquiera();

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
                Comando.CommandText = String.Format("sp_listarDetalleReceta");
                Comando.Parameters.AddWithValue("Ex", String.Format("{0}", textBox1.Text));
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
                dataGridView1.Rows[x].Cells[4].Value = tabla.Rows[x][4].ToString();
                dataGridView1.Rows[x].Cells[5].Value = tabla.Rows[x][5].ToString();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {

               label7.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                numericcabtidad.Value= Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                txtprescripcion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                txtcodigoreceta.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                txtcodigomedicamento.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                btnagregar.Visible = false;
            }
   
        }
  

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                BuscarCualquiera();
            }
        }

        private void Btneliminar_Click(object sender, EventArgs e)
        {
            if (txtcodigomedicamento.Text == "" || numericcabtidad.Value == 0 || txtprescripcion.Text == "")
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
                    Comando.CommandText = String.Format("sp_EliminarReceta");
                    Comando.Parameters.AddWithValue("idReceta", String.Format("{0}", txtcodigoreceta.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    codigoReceta = Comando.Parameters["idReceta"].Value.ToString();
                    Comando.Dispose();
                    Limpiar();
                    // actualizamos el datgrid
                    BuscarCualquiera();
                }
                catch (MySqlException ex)
                {
                    m = "Excepcion de tipo " + ex.GetType().ToString() +
                            "\n" + ex.ToString() +
                            " fue encontrado al ejecutar consulta.";
                }
                MessageBox.Show(m);
                btnagregar.Visible = true;


               

            }
        }

        private void Numericcabtidad_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}