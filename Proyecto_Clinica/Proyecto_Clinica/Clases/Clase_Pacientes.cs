using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregamos los namespaces necesarios.
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace Proyecto_Clinica
{
    class Clase_Pacientes
    {
        // Atributos de la clase
        private string identidad;
        private string nombres;
        private string apellidos;
        private string genero;
        private string estado;
        private string correo;
        private string anio;
        private string direccion;
        private string mes;
        private string dia;
        public string m;
        

        // Propiedades
        public string Identidad
        {
            get { return identidad; }
            set { identidad = value; }
        }
        public string Nombres {
            get { return nombres; }
            set{ nombres = value; }
        }
        public string Apellidos {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string Genero {
            get { return genero; }
            set { genero = value; }
        }
        public string Estado {
            get { return estado; }
            set { estado = value; }
        }
        public string Correo {
            get { return correo; }
            set { correo = value; }
        }
        public string Anio {
            get { return anio; }
            set { anio = value; }
        }

        public string Mes {
            get { return mes; }
            set { mes = value; }

        }
        public string Dia {
            get { return dia; }
            set { dia = value; }
        }
        public string Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        // Métodos de la clase paciente

            /// <summary>
            /// Se encarga de cargar los datos de un paciente en particular.
            /// </summary>
            /// <param name="elPaciente"></param>
            /// <returns></returns>
        public static Clase_Pacientes ListarPaciente(string  Identidad)
        {
            //Definimos la conexion y el comando
            Clase_Conexion con = new Clase_Conexion();

            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;

            Clase_Pacientes elPaciente = new Clase_Pacientes();
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarPaciente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", Identidad));


                Comando.Parameters.Add("Nombre", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Apellido", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Direccion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Genero", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Estado", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("Correo", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("dia", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("mes", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("anio", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();

                elPaciente.Nombres = Comando.Parameters["Nombre"].Value.ToString();
                elPaciente.Apellidos = Comando.Parameters["Apellido"].Value.ToString();
                elPaciente.Direccion = Comando.Parameters["Direccion"].Value.ToString();
                elPaciente.Genero = Comando.Parameters["Genero"].Value.ToString();
                elPaciente.Estado = Comando.Parameters["Estado"].Value.ToString();
                elPaciente.Correo = Comando.Parameters["Correo"].Value.ToString();
                elPaciente.Dia = Comando.Parameters["dia"].Value.ToString();
                elPaciente.Mes = Comando.Parameters["mes"].Value.ToString();
                elPaciente.Anio = Comando.Parameters["anio"].Value.ToString();
                elPaciente.m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();

                return elPaciente;

            }

            catch (Exception)
            {
                return elPaciente;
            }
        }

        /// <summary>
        /// Ejecuta el procedimiento almacenado para insertar un paciente en
        /// la base de datos.
        /// </summary>
        /// <param name="elPaciente"></param>
        /// <returns></returns>
        public static bool InsertartPaciente(Clase_Pacientes elPaciente)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_AgregarPaciente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", elPaciente.Identidad));
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", elPaciente.Nombres));
                Comando.Parameters.AddWithValue("Apellido", String.Format("{0}", elPaciente.Apellidos));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", elPaciente.Direccion));
                Comando.Parameters.AddWithValue("Genero", String.Format("{0}", elPaciente.Genero));
                Comando.Parameters.AddWithValue("Estado", String.Format("{0}", elPaciente.Estado));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", elPaciente.Correo));
                Comando.Parameters.AddWithValue("dia", String.Format("{0}", elPaciente.Dia));
                Comando.Parameters.AddWithValue("mes", String.Format("{0}", elPaciente.Mes));
                Comando.Parameters.AddWithValue("anio", String.Format("{0}", elPaciente.Anio));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                elPaciente.m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
        /// <summary>
        /// Se encarga de actualizar los datos de un paciente en particular 
        /// y lo almacena en la base de datos.
        /// </summary>
        /// <param name="elPaciente"></param>
        /// <returns></returns>
        public static bool ActualizarPaciente(Clase_Pacientes elPaciente)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_EditarPaciente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", elPaciente.Identidad));
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", elPaciente.Nombres));
                Comando.Parameters.AddWithValue("Apellido", String.Format("{0}", elPaciente.Apellidos));
                Comando.Parameters.AddWithValue("Direccion", String.Format("{0}", elPaciente.Direccion));
                Comando.Parameters.AddWithValue("Genero", String.Format("{0}", elPaciente.Genero));
                Comando.Parameters.AddWithValue("Estado", String.Format("{0}", elPaciente.Estado));
                Comando.Parameters.AddWithValue("Correo", String.Format("{0}", elPaciente.Correo));
                Comando.Parameters.AddWithValue("dia", String.Format("{0}", elPaciente.Dia));
                Comando.Parameters.AddWithValue("mes", String.Format("{0}", elPaciente.Mes));
                Comando.Parameters.AddWithValue("anio", String.Format("{0}", elPaciente.Anio));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                elPaciente.m = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Se encarga de inhabilitar un paciente
        /// </summary>
        /// <param name="elPaciente"></param>
        /// <returns></returns>
        public static bool InhabilitarPaciente(Clase_Pacientes elPaciente)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_InhabilitarPaciente");
                Comando.Parameters.AddWithValue("Identidad", String.Format("{0}", elPaciente.Identidad));

                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                elPaciente.m = Comando.Parameters["msj"].Value.ToString();
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
