using RestApiWs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace RestApiWs.Controllers
{
    public class SyncSelectController : ApiController
    {

        [HttpGet]
        public string GetSyncOut_Only(string Usuario, string Dispositivo, string version)
        {
            string resultado = string.Empty;
            string versionNew = string.Empty;
            int existe = 1;
            while (existe > 0)
            {
                versionNew = Engine.FuncionesApi.IdentificadorReg().ToString();
                existe = Engine.FuncionesDb.ExisteVersionSync(versionNew);
            }
            DateTime FechaCreacion = DateTime.Now;
            string FechaCreacionUtc = DateTime.UtcNow.ToString(Engine.FuncionesData.dateFormatUtc);
            string nombreTabla = "Cliente";
            string estado = "INICIADO";
            int r = Engine.FuncionesDb.SyncEstado(versionNew, FechaCreacionUtc, nombreTabla, Usuario, Dispositivo, estado);
            if (r == 200)
            {
                DataTable dt = new DataTable();
                dt = Engine.FuncionesDb.SelectFilasSync(version);
                dt = Engine.FuncionesApi.AddColumnVersion(dt, versionNew);
                List<SyncRegistro> Customer = new List<SyncRegistro>();
                estado = "TERMINADO";
                if (dt.Rows.Count == 0)
                {
                    Engine.FuncionesDb.ActualizarSyncEstado(versionNew, estado);
                }
                else
                {
                    Customer = Engine.FuncionesApi.SetListaRegistro(dt);
                    resultado = new JavaScriptSerializer().Serialize(Customer);
                    Engine.FuncionesDb.ActualizarSyncEstado(version, estado);
                }
            }
            else if (r == -200)
            {
                return resultado = "-109";
            }
            return resultado;
        }
    }
}
