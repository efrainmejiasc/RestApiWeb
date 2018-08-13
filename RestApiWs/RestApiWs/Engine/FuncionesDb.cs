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
        public static DateTime SelectClienteFechaCreacionUtc(string Id)
        {
            object obj = new object();
            DateTime resultado = new DateTime();
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
                resultado = Convert.ToDateTime(obj);
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
        public static int InsertarClienteAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, DateTime FechaCreacionUtc, DateTime FechaModificacion, DateTime FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
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
        public static int ActualizarClienteAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, DateTime FechaCreacionUtc, DateTime FechaModificacion, DateTime FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
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
        public static int ActualizarClienteEstadoAll(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, DateTime FechaCreacionUtc, DateTime FechaModificacion, DateTime FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
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

        //***********************************************************************************************************************************************************************

        [System.Web.Services.WebMethod]
        public static int InsertarCliente(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, DateTime FechaCreacionUtc, DateTime FechaModificacion, DateTime FechaModificacionUtc, int Proceso, string Usuario, string Estado)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarCliente", Conexion);
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
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int InsertarClienteTrack(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaCreacion, DateTime FechaCreacionUtc, DateTime FechaModificacion, DateTime FechaModificacionUtc, int Proceso, string Usuario, string Estado, string Insertar)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarClienteTrack", Conexion);
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
        public static int ActualizarCliente(string Id, string Nombre, int Edad, string Telefono, string Mail, double Saldo, DateTime FechaModificacion, DateTime FechaModificacionUtc, string Usuario, string Estado)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarCliente", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Edad", Edad);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Saldo", Saldo);
                command.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
                command.Parameters.AddWithValue("@FechaModificacionUtc", FechaModificacionUtc);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Estado", Estado);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }

        [System.Web.Services.WebMethod]
        public static int ActualizarClienteEstado(string Id, DateTime FechaModificacion, DateTime FechaModificacionUtc, string Usuario, string Estado)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarClienteEstado", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@FechaModificacion", FechaModificacion);
                command.Parameters.AddWithValue("@FechaModificacionUtc", FechaModificacionUtc);
                command.Parameters.AddWithValue("@Usuario", Usuario);
                command.Parameters.AddWithValue("@Estado", Estado);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }



    }
}