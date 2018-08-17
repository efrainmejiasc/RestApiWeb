using RestApiWs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace RestApiWs.Controllers
{
    public class SyncOutController : ApiController
    {
        [HttpGet]
        public string  GetSyncOut_Init(string Usuario , string Dispositivo)
        {
            string resultado = string.Empty;
            string version = string.Empty;
            int existe = 1;
            while (existe > 0)
            {
              version = Engine.FuncionesApi.IdentificadorReg().ToString();
              existe = Engine.FuncionesDb.ExisteVersionSync(version);
            }
           

            DateTime FechaCreacion = DateTime.Now;
            string FechaCreacionUtc = DateTime.UtcNow.ToString(Engine.FuncionesData.dateFormatUtc);
            int r = Engine.FuncionesDb.SyncEstado(version, FechaCreacion, FechaCreacionUtc, "Cliente" ,Usuario, Dispositivo, "INICIADO");
            if (r == 200 )
            {
                resultado = GetCliente(version);
            }
            else if (r == -200)
            {
                resultado = "ExisteSync";
            }
            return resultado;
        }

        public string GetCliente(string version)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataCliente();
            List<Cliente> Customer = new List<Cliente>();
            if (dt.Rows.Count == 0)
            {
                Engine.FuncionesDb.ActualizarSyncEstado(version, 0, dt.Rows.Count, "TERMINADO");
            }
            else
            {
                Customer = SetListaCliente(dt);
                resultado = new JavaScriptSerializer().Serialize(Customer);
                Engine.FuncionesDb.ActualizarSyncEstado(version, 1, dt.Rows.Count + 1, "TERMINADO");
            }

            return resultado;
        }

        private List<Cliente> SetListaCliente(DataTable dt)
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
    }
}
