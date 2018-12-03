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
    class Clase_Enfermedades
    {
        // Atributos de la clase
        private int codigo;
        private string nombre;
        private string descripcion;
        private string nuevonombre;
        public string msj;

        // Propiedades de acceso.
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string NuevoNombre
        {
            get { return nuevonombre; }
            set { nuevonombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        // Métodos de la clase

        public static Clase_Enfermedades obtenerEnfermeda(string nombre)
        {
            Clase_Conexion con = new Clase_Conexion();
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            Clase_Enfermedades nueva = new Clase_Enfermedades();
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_listarEnfermedad");
                Comando.Parameters.AddWithValue("nombre", String.Format("{0}", nombre));
                Comando.Parameters.Add("descripcion", MySqlDbType.String).Direction = ParameterDirection.Output;
                Comando.ExecuteNonQuery();
                nueva.descripcion = Comando.Parameters["descripcion"].Value.ToString();
                Comando.Dispose();
                return nueva;
            }
            catch
            {
                return nueva;
            }

        }

        /// <summary>
        /// Se encarga de guardar los datos de una nueva enfermedad.
        /// </summary>
        /// <param name="laEnfermedad"></param>
        /// <returns></returns>

        public static bool InsertarEnfermedad(Clase_Enfermedades laEnfermedad)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_AgregarEnfermedad");
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", laEnfermedad.Nombre));
                Comando.Parameters.AddWithValue("Descripcion", String.Format("{0}",laEnfermedad.Descripcion));
                Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                laEnfermedad.msj = Comando.Parameters["Msj"].Value.ToString();
                Comando.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                laEnfermedad.msj = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
                return false;
            }
        }
        /// <summary>
        /// Se encarga de actualizar los datos de una enfermedad especifica
        /// </summary>
        /// <param name="laEnfermedad"></param>
        /// <returns></returns>

        public static bool ActualizarEnfermdad(Clase_Enfermedades laEnfermedad)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_EditarEnfermedad");
                Comando.Parameters.AddWithValue("nombre", String.Format("{0}", laEnfermedad.Nombre));
                Comando.Parameters.AddWithValue("descripcion", String.Format("{0}", laEnfermedad.Descripcion));
                Comando.Parameters.AddWithValue("nuevoNombre", String.Format("{0}", laEnfermedad.NuevoNombre));
                Comando.Parameters.Add("msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                laEnfermedad.msj = Comando.Parameters["msj"].Value.ToString();
                Comando.Dispose();

                return true;
            }
            catch (MySqlException ex)
            {
                m = "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
                return false;
            }
        
        }

        public static bool InhabilitarEnfermedad(Clase_Enfermedades laEnfermedad)
        {
            Clase_Conexion con = new Clase_Conexion();
            String m;
            con.Conectar();
            MySqlCommand Comando = con.Conexion.CreateCommand();
            Comando.Connection = con.Conexion;
            try
            {
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.CommandText = String.Format("sp_InhabilitarEnfermedad");
                Comando.Parameters.AddWithValue("Nombre", String.Format("{0}", laEnfermedad.Nombre));
                Comando.Parameters.AddWithValue("Descripcion", String.Format("{0}", laEnfermedad.Descripcion));
                Comando.Parameters.Add("Msj", MySqlDbType.String).Direction = ParameterDirection.Output; Comando.ExecuteNonQuery();
                laEnfermedad.msj = Comando.Parameters["Msj"].Value.ToString();
                Comando.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                laEnfermedad.msj= "Excepcion de tipo " + ex.GetType().ToString() +
                        "\n" + ex.ToString() +
                        " fue encontrado al ejecutar consulta.";
                return false;
            }
           
        }
    }
}
