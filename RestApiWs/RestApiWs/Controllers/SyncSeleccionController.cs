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
    public class SyncSeleccionController : ApiController
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
            string nombreTabla = "Cliente";
            string estado = "INICIADO";
            int r = Engine.FuncionesDb.SyncEstado(version, FechaCreacion, FechaCreacionUtc, nombreTabla, Usuario, Dispositivo, estado);
            if (r == 200)
            {
                resultado = GetClienteAll(version);
            }
            else if (r == -200)
            {
                resultado = "-109";
            }
            return resultado;
        }

        public string GetClienteAll(string version)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataCliente();
            dt = Engine.FuncionesApi.AddColumnVersion(dt,version);
            List<SyncRegistro> Customer = new List<SyncRegistro>();
            string estado = "TERMINADO";
            if (dt.Rows.Count == 0)
            {
                Engine.FuncionesDb.ActualizarSyncEstado(version, estado);
            }
            else
            {
                Customer = Engine.FuncionesApi.SetListaRegistro(dt);
                resultado = new JavaScriptSerializer().Serialize(Customer);
                Engine.FuncionesDb.ActualizarSyncEstado(version ,estado);
            }
            return resultado;
        }

        [HttpGet]
        public string GetSyncOut_Next(string Usuario, string Dispositivo, string version)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.SelectFilasSync(version);
            dt = Engine.FuncionesApi.AddColumnVersion(dt, version);
            List<SyncRegistro> Customer = new List<SyncRegistro>();
            string estado = "TERMINADO";
            if (dt.Rows.Count == 0)
            {
                Engine.FuncionesDb.ActualizarSyncEstado(version, estado);
            }
            else
            {
                Customer = Engine.FuncionesApi.SetListaRegistro(dt);
                resultado = new JavaScriptSerializer().Serialize(Customer);
                Engine.FuncionesDb.ActualizarSyncEstado(version, estado);
            }
            return resultado;
        }



    }
}
