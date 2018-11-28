using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregamos los namespaces necesarios.
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_Clinica.Clases
{
    class Clase_AntecedentePaciente
    {
        // Atributos
        private string identidad;
        private string alergiaAlimento;
        private string alergiaMedicina;
        private string otrasAlergias;
        private string enfermedadCronica;
        private string tratamientoMedico;
        public string m;

        // Propiedades

        public string Identidad
        {
            get { return identidad; }
            set { identidad = value; }
        } 

        public string AlergiasAlimentos
        {
            get { return alergiaAlimento; }
            set { alergiaAlimento = value; }
        }

        public string AlergiaMedicinas
        {
            get { return alergiaMedicina; }
            set { alergiaMedicina = value; }
        }

        public string OtrasAlergias
        {
            get { return otrasAlergias; }
            set { otrasAlergias = value; }
        }

        public string EnfermedadCronica
        {
            get { return enfermedadCronica; }
            set { enfermedadCronica = value; }
        }

        public string TtatamientosMedicos
        {
            get { return tratamientoMedico; }
            set { tratamientoMedico = value; }
        }

        // Métodos de la clase.

            /// <summary>
            /// Obtiene todas las especificaciones que pertencen al cliete con la 
            /// identidad especificada.
            /// </summary>
            /// <param name="identidad"></param>
            /// <returns></returns>
        public static Clase_AntecedentePaciente BuscarAntecedente(string identidad)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;

            Clase_AntecedentePaciente nuevo = new Clase_AntecedentePaciente();
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarAntecendente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", identidad));


                Comando.Parameters.Add("AlergiaA", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("AlergiaM", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("OAlergia", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("EnfermedadC", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("TratamientoM", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();


                nuevo.alergiaAlimento = Comando.Parameters["AlergiaA"].Value.ToString();
                nuevo.m = Comando.Parameters["msj"].Value.ToString();
                nuevo.AlergiaMedicinas = Comando.Parameters["AlergiaM"].Value.ToString();
               nuevo.OtrasAlergias = Comando.Parameters["OAlergia"].Value.ToString();
                nuevo.EnfermedadCronica = Comando.Parameters["EnfermedadC"].Value.ToString();
                nuevo.TtatamientosMedicos = Comando.Parameters["TratamientoM"].Value.ToString();
                Comando.Dispose();

                return nuevo;
            }
            catch (Exception)
            {
                return nuevo;
            }
        }

        /// <summary>
        /// Se encarga de guardar un nuevo registro de antecedentes
        /// para un nuevo paciente.
        /// </summary>
        /// <param name="nuevo"></param>
        /// <returns></returns>
        public static bool InsertarAntecedente(Clase_AntecedentePaciente nuevo)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_AgregarAntecedenteP");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", nuevo.Identidad));
                Comando.Parameters.AddWithValue("AlergiaA", String.Format("{0}", nuevo.alergiaAlimento));
                Comando.Parameters.AddWithValue("AlergiaM", String.Format("{0}", nuevo.AlergiaMedicinas));
                Comando.Parameters.AddWithValue("OAlergia", String.Format("{0}", nuevo.OtrasAlergias));
                Comando.Parameters.AddWithValue("EnfermedadC", String.Format("{0}", nuevo.EnfermedadCronica));
                Comando.Parameters.AddWithValue("TratamientoM", String.Format("{0}", nuevo.tratamientoMedico));
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                nuevo.m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public static bool ActualizarAntecedente(Clase_AntecedentePaciente nuevo)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_EditarAntecedenteP");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", nuevo.Identidad));
                Comando.Parameters.AddWithValue("AlergiaA", String.Format("{0}", nuevo.alergiaAlimento));
                Comando.Parameters.AddWithValue("AlergiaM", String.Format("{0}", nuevo.AlergiaMedicinas));
                Comando.Parameters.AddWithValue("OAlergia", String.Format("{0}", nuevo.OtrasAlergias));
                Comando.Parameters.AddWithValue("EnfermedadC", String.Format("{0}", nuevo.EnfermedadCronica));
                Comando.Parameters.AddWithValue("TratamientoM", String.Format("{0}", nuevo.tratamientoMedico));
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                nuevo.m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
