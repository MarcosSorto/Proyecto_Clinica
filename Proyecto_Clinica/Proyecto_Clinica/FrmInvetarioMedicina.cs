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
    public partial class FrmInvetarioMedicina : Form
    {
        // Declaramos las variables a utilizar
        public String actualizar;
        private DataTable tabla = new DataTable();
        private DataTable presentacionTabla = new DataTable();
        private int total = 0;
        public FrmInvetarioMedicina()
        {
            InitializeComponent();
            Actulizar_P();
            dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Cierra el formulario actual y regresa al menu principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnregresar_Click(object sender, EventArgs e)
        {
            txttotal.Text = "";
            this.Close();
        }

        /// <summary>
        /// Guarda y limpia los datos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (cmbpresentacion.SelectedIndex == -1 || txtnombre.Text == "")
            {
                MessageBox.Show("Hay datos que no han sido llenados, !Revise!", "Control de inventario", MessageBoxButtons.OK);
            }
            else
            {
                Limpiar();
                dateTimePicker1.Value = System.DateTime.Now;
                btnguardar.Enabled = true;
                MessageBox.Show("Registro Guardado Exitosamente", "Control de inventario", MessageBoxButtons.OK);
                Limpiar();
            }
            
        }
        /// <summary>
        /// Se encarga de llamar a los procedimientos almacenados, y los ejecuta.
        /// parámetros
        /// string s: es el nombre del procedimiento almacenado.
        /// </summary>
        /// <param name="s"></param>
        private void Cargar_Datos(string s)
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
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", txtnombre.Text));
                Comando.Parameters.AddWithValue("Laboratorio", String.Format("{0}", txtcodigolaboratorio.Text));
                Comando.Parameters.AddWithValue("Presentacion", String.Format("{0}", cmbpresentacion.SelectedValue.ToString()));
                Comando.Parameters.AddWithValue("codigoM", String.Format("{0}", actualizar));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                Transacsion.Commit();
            }
            catch (Exception)
            {
                MessageBox.Show("Hay problemas en los datos ingresados");
                Transacsion.Rollback();
            }

        }

        /// <summary>
        /// Función que se encarga de limpiar todo el contenido de los botones.
        /// </summary>
        private void Limpiar()
        {
            txtnombre.Text = "";
            txtcodigolaboratorio.Text = "";
            cmbpresentacion.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            txttotal.Text = "";
            txtcantidad.Text = "";
            dateTimePicker1.Value = System.DateTime.Now;    
            btnguardar.Enabled = true;
            cmbpresentacion.Text = "Seleccione una opción";
            btnactualizar.Enabled = true;
            btnguardar.Enabled = true;
            btninhabilitar.Enabled = true;
            txttotal.Text = "";
            cmbpresentacion.Focus();
        }

        /// <summary>
        /// Se encarga de verificar y cargar todos los datos del registro si este yá existe en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txtnombre_Leave(object sender, EventArgs e)
        {
            String m = "", m2 = "";
            if (cmbpresentacion.SelectedIndex ==-1)
            {
                MessageBox.Show("Ingrese la presentación para continuar", "Control de ingreso", MessageBoxButtons.OK);
                cmbpresentacion.Focus();
            }
            else
            {
                Clase_Conexion con = new Clase_Conexion();
                
                // Variable que almacenará el codigo autoincremental que retornará el procedimiento almacenado.
                String codigo;

                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_listarMedicina");
                    Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", txtnombre.Text));
                    Comando.Parameters.AddWithValue("Presentacion", String.Format("{0}", cmbpresentacion.SelectedValue.ToString()));
                    Comando.Parameters.Add("Laboratorio", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.Parameters.Add("msj2", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.Parameters.Add("CodigoM", MySqlDbType.String).Direction = ParameterDirection.Output;

                    Comando.ExecuteNonQuery();


                    txtcodigolaboratorio.Text = Comando.Parameters["Laboratorio"].Value.ToString();
                    m = Comando.Parameters["msj"].Value.ToString();
                    m2 = Comando.Parameters["msj2"].Value.ToString();
                    codigo = Comando.Parameters["CodigoM"].Value.ToString();
                    //Asignamos a actualizar el codigo autoincremetal del registro que fue enviado por el procedimieto almacenado.
                    actualizar = codigo;
                    // LLenamos el datagrid con los datos que tenga el registro.
                    BuscarCualquiera(codigo);
                    Comando.Dispose();

                    // Evaluamos si el medicina existe
                    // m2 == null -- no existe
                    // m2 != null ---si existe
                    if (m2 == null || m2 == "")
                    {
                        btnguardar.Enabled = true;
                        btnactualizar.Enabled = false;
                        btninhabilitar.Enabled = false;
                        
                    }
                    else
                    {
                        if (m =="No disponible")
                        {

                            MessageBox.Show("Este Medicamento está inhabilitado");
                            txttotal.Text = "";
                            Limpiar();
                        }
                        else
                        {
                            btnguardar.Enabled = false;
                            btnactualizar.Enabled = true;
                            btninhabilitar.Enabled = true;
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

        /// <summary>
        /// Se encarga de guardar los primeros datos y las caducidades que tenga el medicamento, ademas actualiza
        /// y muestra los datos en el grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {

            if (txtnombre.Text == "" || cmbpresentacion.SelectedIndex == -1|| txtcantidad.Text =="")
            {
                MessageBox.Show("Debe ingresar los todos los datos", "Control de inventario", MessageBoxButtons.OK);
            }
            else
            {
                //Guardamos los datos de la medicina primero.
                Cargar_Datos("sp_AgregarInventario");

                // Guardamos los detalles de caducidad de la medicina
                Clase_Conexion con = new Clase_Conexion();
                MySqlTransaction Transacsion;
                Transacsion = con.Conexion.BeginTransaction();
                String m;
                String co;
                con.Conectar();
                MySqlCommand Comando = con.Conexion.CreateCommand();
                Comando.Connection = con.Conexion;
                try
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.CommandText = String.Format("sp_AgregarCaducidad");
                    Comando.Parameters.AddWithValue("NombreMed", String.Format("{0}", txtnombre.Text));
                    Comando.Parameters.AddWithValue("Presentacion", String.Format("{0}", cmbpresentacion.SelectedValue.ToString()));
                    Comando.Parameters.AddWithValue("Fechac", String.Format("{0}", dateTimePicker1.Value.Date.ToString()));
                    Comando.Parameters.AddWithValue("Cantidad", String.Format("{0}", txtcantidad.Text));

                    Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.Parameters.Add("CodigoMed", MySqlDbType.String).Direction = ParameterDirection.Output;
                    Comando.ExecuteNonQuery();
                    m = Comando.Parameters["msj"].Value.ToString();
                    co = Comando.Parameters["CodigoMed"].Value.ToString();
                    Comando.Dispose();

                    // Actualizamos el datagreview con las opciones de caducidad
                    Transacsion.Commit();
                    if (m == "Esta fecha yá esta definida")
                    {
                        MessageBox.Show("Esta fecha yá esta definida");
                    }
                    else
                    {
                        BuscarCualquiera(co);
                        // actualizamos el total de unidades que hay de medicamentos

                        txtcantidad.Text = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se completó la acción");
                    Transacsion.Rollback();
                }

            }

            

        }
        /// <summary>
        /// Función que se encarga de actualizar y cargar los datos en el dataGrid
        /// parámetros
        /// string cod: codigo autoincremental del medicamento
        /// </summary>
        /// <param name="cod"></param>
        private void BuscarCualquiera(string cod)
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
                Comando.CommandText = String.Format("sp_listarCaducidad");
                Comando.Parameters.AddWithValue("codigoM", String.Format("{0}", cod));
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
            total = 0;

            for (int x = 0; x < tabla.Rows.Count; x++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells[0].Value = tabla.Rows[x][0].ToString();
                dataGridView1.Rows[x].Cells[1].Value = tabla.Rows[x][1].ToString();
                dataGridView1.Rows[x].Cells[2].Value = tabla.Rows[x][2].ToString();
                dataGridView1.Rows[x].Cells[3].Value = tabla.Rows[x][3].ToString();
            // dataGridView1.Rows[x].Cells[4].Value = tabla.Rows[x][4].ToString();
            }
            for (int x = 0; x < tabla.Rows.Count; x++)
            {

                total = total + Convert.ToInt16(dataGridView1.Rows[x].Cells[1].Value);
                txttotal.Text = Convert.ToString(total);
            }
        }

        /// <summary>
        /// función que se encarga de actulizar los cambios que se hagan al registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnactualizar_Click(object sender, EventArgs e)
        {
            if(cmbpresentacion.SelectedIndex==-1|| txtnombre.Text == "")
            {
                MessageBox.Show("Revise, hay datos importantes sin llenar", "Control de inventario", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult s = MessageBox.Show("¿Está seguro que desea modificar el registro?", "Control de inventario", MessageBoxButtons.YesNo);
                if (s == DialogResult.Yes)
                {
                    //llamamos al procedimiento de actualiarInventario.
                    Cargar_Datos("sp_EditarInventario");
                    dateTimePicker1.Value = System.DateTime.Now;
                    Limpiar();
                }
                else
                {
                    Limpiar();
                }
                
            }
            
        }



        private void Txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)|| Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

  

        private void Btninhabilitar_Click(object sender, EventArgs e)
        {
            if(txtnombre.Text =="" || cmbpresentacion.SelectedIndex ==-1)
            {
                MessageBox.Show("Debe ingresar presentación y nombre del medicamento", "Control de Inventario", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea inhabilitar este medicamento?", "Conttrol de Inventario", MessageBoxButtons.YesNoCancel);

                if (r == DialogResult.Yes)
                {
                    Cargar_Datos("sp_InhabilitarInventario");
                    MessageBox.Show("Registro inhabilitado Correctamente", "Control de Invetario", MessageBoxButtons.OK);
                    Limpiar();
                }
                else
                {
                    Limpiar();
                }
            }
            
        }
        /// <summary>
        /// Función se encarga de cargar los tipos de presentacion al comboBox en el imvetario.
        /// </summary>
        /// <param name="sql"></param>


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
                presentacionTabla.Reset();
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarPresentacionTodo");
                Comando.ExecuteNonQuery();
                adaptador.SelectCommand = Comando;

                adaptador.Fill(presentacionTabla);
                Transacsion.Commit();
            }
            catch (Exception)
            {
                Transacsion.Rollback();

            }
            cmbpresentacion.DataSource = null;
            cmbpresentacion.Items.Clear();
            cmbpresentacion.ValueMember = presentacionTabla.Columns["Codigo"].ColumnName;
            cmbpresentacion.DisplayMember = presentacionTabla.Columns["Descripcion"].ColumnName;
            cmbpresentacion.DataSource = presentacionTabla.DefaultView;
            cmbpresentacion.SelectedIndex = -1;
            cmbpresentacion.Text = "Seleccione una opción";
        }

        private void FrmInvetarioMedicina_Load(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Cmbpresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
