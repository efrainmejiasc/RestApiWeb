using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestApiWs.Engine
{
    public class FuncionesDb
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["CnxRestSync"].ToString();

        [System.Web.Services.WebMethod]
        public static string ExisteClienteIdMail(string Id, string MAIL)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ExisteIdMail", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@MAIL", MAIL);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }


        [System.Web.Services.WebMethod]
        public static string SelectClienteIdMail(string Id,string MAIL)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteIdMail", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id",Id);
                command.Parameters.AddWithValue("@MAIL", MAIL);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static string SelectClienteMail(string MAIL)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteMail", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MAIL", MAIL);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static DateTime SelectClienteFechaCreacion(string Id)
        {
            object obj = new object();
            DateTime resultado = new DateTime();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteFechaCreacion", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToDateTime (obj);
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static string SelectClienteFechaCreacionUtc(string Id)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteFechaCreacionUtc", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static string SelectClienteId(string Id)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteId", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static string SelectNumeroClienteId(string Id, string Estado)
        {
            object obj = new object();
            string resultado = string.Empty;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectNumeroClienteId", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Estado", Estado);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = obj.ToString();
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int SyncInOutExito(string version)
        {
            object obj = new object();
            int resultado = 0;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SyncInOutExito", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Version", version);
                command.Parameters.AddWithValue("@Estado", "TERMINADO");
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32(obj);
            }
            return resultado;
        }


        [System.Web.Services.WebMethod]
        public static int InsertarClienteAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, string FechaCreacionUtc, DateTime FechaModificacion, string FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarClienteAll", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Edad", Edad);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Saldo", Saldo);
                command.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                command.Parameters.AddWithValue("@FechaCreacionUtc", FechaCreacionUtc);
                command.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
                command.Parameters.AddWithValue("@FechaModificacionUtc", FechaModificacionUtc);
                command.Parameters.AddWithValue("@Proceso", Proceso);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.Parameters.AddWithValue("@Transaccion", Insertar);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }
     
        [System.Web.Services.WebMethod]
        public static int ActualizarClienteAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, string FechaCreacionUtc, DateTime FechaModificacion, string FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarClienteAll", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Edad", Edad);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Saldo", Saldo);
                command.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                command.Parameters.AddWithValue("@FechaCreacionUtc", FechaCreacionUtc);
                command.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
                command.Parameters.AddWithValue("@FechaModificacionUtc", FechaModificacionUtc);
                command.Parameters.AddWithValue("@Proceso", Proceso);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.Parameters.AddWithValue("@Transaccion", Insertar);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int ExisteVersionSync(string Version)
        {
            object obj = new object();
            int resultado = -1;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ExisteVersionSync", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Version", Version);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32 (obj);
            }
            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int ActualizarClienteEstadoAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, string FechaCreacionUtc, DateTime FechaModificacion, string FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarClienteEstadoAll", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Edad", Edad);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Saldo", Saldo);
                command.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                command.Parameters.AddWithValue("@FechaCreacionUtc", FechaCreacionUtc);
                command.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
                command.Parameters.AddWithValue("@FechaModificacionUtc", FechaModificacionUtc);
                command.Parameters.AddWithValue("@Proceso", Proceso);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Estado", Estado);
                command.Parameters.AddWithValue("@Transaccion", Insertar);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int SyncEstado(string Version,  DateTime FechaCreacion, string FechaCreacionUtc,  string NombreTabla, string Usuario, string Dispositivo, string Estado)
        {
            int resultado = new int();
            object obj = new object();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SyncEstado", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Version", Version);
                command.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                command.Parameters.AddWithValue("@FechaCreacionUtc", FechaCreacionUtc);
                command.Parameters.AddWithValue("@NombreTabla", NombreTabla);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Dispositivo", Dispositivo);
                command.Parameters.AddWithValue("@Estado", Estado);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32(obj);
            }

            return resultado;
        }


        [System.Web.Services.WebMethod]
        public static int SyncEstado()
        {
            int resultado = 0;
            object obj = new object();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ExisteSyncIniciada", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32(obj);
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int ActualizarSyncEstado(string Version,string Estado)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarSyncEstado", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Version", Version);
                command.Parameters.AddWithValue("@Estado", Estado);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int BorrarCliente(string Id)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_BorrarCliente", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static DataTable TableDataClienteId(object ID)
        {
            DataTable dataTabla = new DataTable();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);

            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectClienteId", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", ID);
                SqlDataAdapter dataAdaptador = new SqlDataAdapter(command);
                dataAdaptador.Fill(dataTabla);
                Conexion.Close();
            }
            return dataTabla;
        }

        [System.Web.Services.WebMethod]
        public static DataTable TableDataCliente()
        {
            DataTable dataTabla = new DataTable();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);

            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectCliente", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdaptador = new SqlDataAdapter(command);
                dataAdaptador.Fill(dataTabla);
                Conexion.Close();
            }
            return dataTabla;
        }

        [System.Web.Services.WebMethod]
        public static DataTable SelectFilasSync(string version)
        {
            DataTable dataTabla = new DataTable();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);

            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SelectFilasSync", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@version", version);
                SqlDataAdapter dataAdaptador = new SqlDataAdapter(command);
                dataAdaptador.Fill(dataTabla);
                Conexion.Close();
            }
            return dataTabla;
        }

        //***********************************************************************************************************************************************************************

        public string Listado( string campo1 , string campo2)
        {
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_BorrarCliente", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                SqlDataReader lector = lector = command.ExecuteReader();
                while ((lector.Read()))
                {
                    campo1 = lector[campo1].ToString();
                    campo2 = lector[campo2].ToString();
                }
                lector.Close();
                command.Connection.Close();
                Conexion.Close();
            }
            return campo1 + campo2;
        }

    }
}