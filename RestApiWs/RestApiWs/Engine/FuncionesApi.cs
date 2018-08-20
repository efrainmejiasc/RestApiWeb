using RestApiWs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RestApiWs.Engine
{
    public class FuncionesApi
    {
        public static Guid IdentificadorReg()
        {
            Guid g = CrearGuid();
            while (g != Guid.Empty)
            {
                return g;
            }
            return g;
        }

        private static Guid CrearGuid()
        {
            return Guid.NewGuid();
        }

        public static List<Cliente> SetListaCliente(DataTable dt)
        {
            List<Cliente> Customer = new List<Cliente>();
            foreach (DataRow r in dt.Rows)
            {
                Cliente lineaCliente = new Cliente
                {
                    Numero = Convert.ToInt32(r[0]),
                    Id = r[1].ToString(),
                    Nombre = r[2].ToString(),
                    Edad = Convert.ToInt32(r[3]),
                    Telefono = r[4].ToString(),
                    Mail = r[5].ToString(),
                    Saldo = Convert.ToDouble(r[6]),
                    FechaCreacion = Convert.ToDateTime(r[7]),
                    FechaCreacionUtc = r[8].ToString(),
                    FechaModificacion = Convert.ToDateTime(r[9]),
                    FechaModificacionUtc = r[10].ToString(),
                    Proceso = Convert.ToInt32(r[11]),
                    Usuario = r[12].ToString(),
                    Estado = r[13].ToString(),
                };
                Customer.Add(lineaCliente);
            }
            return Customer;
        }

        public static List<SyncRegistro> SetListaRegistro(DataTable dt)
        {
            List<SyncRegistro> Customer = new List<SyncRegistro>();
            foreach (DataRow r in dt.Rows)
            {
                SyncRegistro lineaCliente = new SyncRegistro
                {
                    Numero = Convert.ToInt32(r[0]),
                    Id = r[1].ToString(),
                    Nombre = r[2].ToString(),
                    Edad = Convert.ToInt32(r[3]),
                    Telefono = r[4].ToString(),
                    Mail = r[5].ToString(),
                    Saldo = Convert.ToDouble(r[6]),
                    FechaCreacion = Convert.ToDateTime(r[7]),
                    FechaCreacionUtc = r[8].ToString(),
                    FechaModificacion = Convert.ToDateTime(r[9]),
                    FechaModificacionUtc = r[10].ToString(),
                    Proceso = Convert.ToInt32(r[11]),
                    Usuario = r[12].ToString(),
                    Estado = r[13].ToString(),
                    Version = r[14].ToString()
                };
                Customer.Add(lineaCliente);
            }
            return Customer;
        }


        public static DataTable AddColumnVersion (DataTable dt , string version)
        {
            dt.Columns.Add("Version");
            foreach (DataRow row in dt.Rows)
            {
                row["Version"] = version;
            }
            return dt;
        }


        public static SyncEstado SetSynEstado(string version , string estado)
        {
            SyncEstado SyncEstado = new SyncEstado
            {
                Version = version,
                Estado = estado
            };
            return SyncEstado;
        }
      
    }
}