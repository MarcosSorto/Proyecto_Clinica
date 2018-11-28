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
    public partial class FrmPacientes : Form
    {

        public static string identidad;
        public static string nombre;
        public FrmPacientes()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cierra el formulario paciente y regresa la menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnregresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load Carga todo los elemento y llamamos a la función limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            limpiar();
            maskedTextBox1.Focus();
        }
        /// <summary>
        /// Función limpiar se encarga de vaciar los textbox y inicializar los valores iniciales.
        /// </summary>
        private void limpiar()
        {
            maskedTextBox1.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtanio.Text = "";
            cmbdia.Text = "";
            cmbmes.Text = "";
            cmbEstado.SelectedIndex = -1;
            rbtMasculino.Checked = false;
            rbtFemenino.Checked = false;
            btnactualizar.Visible = false;
            btninhabilitar.Visible = false;
            btnguardar.Visible = true;
            maskedTextBox1.Focus();

        }
        /// <summary>
        /// Llama al procedimiento de guardar y almacena los datos en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || txtNombre.Text == "")

            {
                MessageBox.Show("Debe de ingresar la identidad y nombres del paciente", "Control de pacientes", MessageBoxButtons.OK);
            }
            else if (rbtMasculino.Checked == false && rbtFemenino.Checked == false)
            {
                MessageBox.Show("Debe de seleccionar un genero", "Control de pacientes", MessageBoxButtons.OK);

            }
            else if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un estado civil", "Control de pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Pacientes guardar = new Clase_Pacientes();
                guardar.Identidad = maskedTextBox1.Text;
                guardar.Nombres = txtNombre.Text;
                guardar.Apellidos = txtApellido.Text;
                guardar.Direccion = txtDireccion.Text;
                guardar.Estado = cmbEstado.SelectedItem.ToString();
                if (rbtFemenino.Checked == true)
                    guardar.Genero = "F";
                else
                    guardar.Genero = "M";
                guardar.Correo = txtCorreo.Text;
                guardar.Dia = cmbdia.Text;
                guardar.Mes = cmbmes.Text;
                guardar.Anio = txtanio.Text;

                // Verificamos la correcta inserción de los datos
                if (Clase_Pacientes.InsertartPaciente(guardar))
                {
                    MessageBox.Show(guardar.m);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante la operación", "Control de Pacientes");
                }
            }
        }
        /// <summary>
        /// Se encarga de cargar todos los datos de un paciente en el formulario si este existe en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            Clase_Pacientes nuevo = Clase_Pacientes.ListarPaciente(maskedTextBox1.Text);

            // llenamos con los resultados obtenidos.
            txtNombre.Text = nuevo.Nombres;
            txtApellido.Text = nuevo.Apellidos;
            txtDireccion.Text = nuevo.Direccion;
            if (nuevo.Genero == "M")
                rbtMasculino.Checked = true;
            else
                rbtFemenino.Checked = true;
            txtCorreo.Text = nuevo.Correo;
            cmbdia.Text = nuevo.Dia;
            cmbmes.Text = nuevo.Mes;
            txtanio.Text = nuevo.Anio;
            cmbEstado.Text = nuevo.Estado;

            // Verificamos si hay datos recuperados
            if(txtNombre.Text != "" || txtDireccion.Text !="" || txtApellido.Text != "")
            {
                btnguardar.Visible= false;
                btnactualizar.Visible = true;
                btninhabilitar.Visible = true;
            }
            else
            {
                if(nuevo.m == "El paciente está inhabilitado")
                {
                    MessageBox.Show(nuevo.m);
                    limpiar();
                }
                else
                {
                    btnguardar.Visible = true;
                    btnactualizar.Visible = false;
                    btninhabilitar.Visible = false;
                }
                
                
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text == "" || txtNombre.Text == "")

            {
                MessageBox.Show("Debe de ingresar la identidad y nombres del paciente", "Control de pacientes", MessageBoxButtons.OK);
            }
            else if (rbtMasculino.Checked == false && rbtFemenino.Checked == false)
            {
                MessageBox.Show("Debe de seleccionar un genero", "Control de pacientes", MessageBoxButtons.OK);

            }
            else if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un estado civil", "Control de pacientes", MessageBoxButtons.OK);
            }
            else
            {
                Clase_Pacientes guardar = new Clase_Pacientes();
                guardar.Identidad = maskedTextBox1.Text;
                guardar.Nombres = txtNombre.Text;
                guardar.Apellidos = txtApellido.Text;
                guardar.Direccion = txtDireccion.Text;
                guardar.Estado = cmbEstado.SelectedItem.ToString();
                if (rbtFemenino.Checked == true)
                    guardar.Genero = "F";
                else
                    guardar.Genero = "M";
                guardar.Correo = txtCorreo.Text;
                guardar.Dia = cmbdia.Text;
                guardar.Mes = cmbmes.Text;
                guardar.Anio = txtanio.Text;

                // Verificamos la correcta inserción de los datos
                if (Clase_Pacientes.ActualizarPaciente(guardar))
                {
                    MessageBox.Show(guardar.m);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error durante la operación", "Control de Pacientes");
                }
            }

        }
       

        private void btninhabilitar_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("¿Está Seguro que desea inhabilitar al paciente?", "Control de pacientes", MessageBoxButtons.YesNo);
            if (s == DialogResult.Yes)
            {
                Clase_Pacientes inhabilitar = new Clase_Pacientes();
                inhabilitar.Identidad = maskedTextBox1.Text;

                if (Clase_Pacientes.InhabilitarPaciente(inhabilitar))
                {
                    MessageBox.Show(inhabilitar.m);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error durante la operación", "Control de Pacientes");
                }

            }
            else
            {
                limpiar();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAntecedentesPaciente nuevo = new FrmAntecedentesPaciente();
            nuevo.ShowDialog();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FrmBuscarPaciente nuevo = new FrmBuscarPaciente();
            //nuevo.ShowDialog();
            //maskedTextBox1.Text = FrmBuscarPaciente.IdentidadPaciente;
            //textBox2.Text = FrmBuscarPaciente.NombrePaciente;
            //maskedTextBox1.Focus();
        }
    }
}
