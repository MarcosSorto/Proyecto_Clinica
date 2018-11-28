using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Clinica
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           DialogResult s =  MessageBox.Show("¿Está Seguro que desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNoCancel);
            if (s == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            ejecutarlimpieza();
            FrmPacientes nuevo = new FrmPacientes();
            nuevo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ejecutarlimpieza();
            //FrmExpedientes nuevo = new FrmExpedientes();
            //nuevo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ejecutarlimpieza();
            //FrmInvetarioMedicina nuevo = new FrmInvetarioMedicina();
            //nuevo.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ejecutarlimpieza();
            mostrarPersonal();
        }
        private void mostrarPersonal()
        {
            pcmedicos.Visible = true;
            pcenfermeras.Visible = true;

            btnenfermeras.Visible = true;
            btnmedicos.Visible = true;
        }
        private void ocultarPersonal()
        {
            pcenfermeras.Visible = false;
            pcmedicos.Visible = false;

            btnenfermeras.Visible = false;
            btnmedicos.Visible = false;
        }
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            ocultarPersonal();
            ocultarMantenimiento();
        }

        private void btnmedicos_Click(object sender, EventArgs e)
        {
            //ocultarPersonal();
            //FrmMedicos nuevo = new FrmMedicos();
            //nuevo.ShowDialog();
        }

        private void btnenfermeras_Click(object sender, EventArgs e)
        {
            //ocultarPersonal();
            //FrmPersonal nuevo = new FrmPersonal();
            //nuevo.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ejecutarlimpieza();
            mostrarMantenimiento();
        }

        private void ocultarMantenimiento()
        {
            pcusua.Visible = false;
            pcpresmed.Visible = false;
            pcespecialis.Visible = false;
            pcmedicam.Visible = false;
            pctelefono.Visible = false;

            btncuentas.Visible = false;
            btnpresentacion.Visible = false;
            btnespecialidad.Visible = false;
            btnmedicamentos.Visible = false;
            btntelefono.Visible = false;
            btnEnfermedad.Visible = false;
        }

        private void mostrarMantenimiento()
        {
            pcusua.Visible = true;
            pcpresmed.Visible = true;
            pcespecialis.Visible = true;
            pcmedicam.Visible = true;
            pctelefono.Visible = true;

            btncuentas.Visible = true;
            btnpresentacion.Visible = true;
            btnespecialidad.Visible = true;
            btnmedicamentos.Visible = true;
            btntelefono.Visible = true;
            btnEnfermedad.Visible =true;


        }

        private void btnlaboratorios_Click(object sender, EventArgs e)
        {
            ocultarMantenimiento();
        }

        private void btnespecialidad_Click(object sender, EventArgs e)
        {
            //ocultarMantenimiento();
            //FrmEspecialidad nuevo = new FrmEspecialidad();
            //nuevo.ShowDialog();

        }

        private void btncuentas_Click(object sender, EventArgs e)
        {
            //ejecutarlimpieza();
            //FrmUsuarios n = new FrmUsuarios();
            //n.ShowDialog();
            //    ocultarMantenimiento();
        }

        private void btnpresentacion_Click(object sender, EventArgs e)
        {
            ////ejecutarlimpieza();
            ////FrmPresentacion nuevo = new FrmPresentacion();
            ////nuevo.ShowDialog();
        }

        private void ejecutarlimpieza()
        {
            ocultarPersonal();
            ocultarMantenimiento();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FrmReportesTodo nuevo = new FrmReportesTodo();
            //nuevo.ShowDialog();
            //ejecutarlimpieza();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmAcercade nuevo = new FrmAcercade();
            nuevo.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //ejecutarlimpieza();
            //FrmTelefono nuevo = new FrmTelefono();
            //nuevo.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pcpresmed_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btnmedicos_MouseLeave(object sender, EventArgs e)
        {
            btnmedicos.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btnenfermeras_MouseLeave(object sender, EventArgs e)
        {
            btnenfermeras.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btnpresentacion_MouseLeave(object sender, EventArgs e)
        {
            btnpresentacion.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pcpresmed_MouseLeave(object sender, EventArgs e)
        {
            pcpresmed.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btnmedicamentos_MouseLeave(object sender, EventArgs e)
        {
            btnmedicamentos.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pcmedicam_MouseLeave(object sender, EventArgs e)
        {
            pcmedicam.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btntelefono_MouseLeave(object sender, EventArgs e)
        {
            btntelefono.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pctelefono_MouseLeave(object sender, EventArgs e)
        {
            pctelefono.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btnespecialidad_MouseLeave(object sender, EventArgs e)
        {
            btnespecialidad.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pcespecialis_MouseLeave(object sender, EventArgs e)
        {
            pcespecialis.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void btncuentas_MouseLeave(object sender, EventArgs e)
        {
            btncuentas.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void pcusua_MouseLeave(object sender, EventArgs e)
        {
            pcusua.BackColor = Color.FromArgb(12, 6, 86);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //FrmEnfermedades nuevo = new FrmEnfermedades();
            //nuevo.ShowDialog();
        }
    }
}
