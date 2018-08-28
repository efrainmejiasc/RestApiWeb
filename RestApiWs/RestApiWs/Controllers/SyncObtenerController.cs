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
    public class SyncObtenerController : ApiController
    {
        // METODO USADO PARA SINCRONIZAR SIN EVIAR FILAS DE INSERCCION (SOLO DEVUELVE DATOS)

        [HttpGet]
        public string GetSyncInOut_Init(string Usuario, string Dispositivo, string Version)
        {
            string resultado = string.Empty;
            string versionNew = string.Empty;
            int existe = 1;
            //CREAR VERSION DE LA SINCRONIZACION
            while (existe > 0)
            {
                versionNew = Engine.FuncionesApi.IdentificadorReg().ToString();
                existe = Engine.FuncionesDb.ExisteVersionSync(versionNew);
            }

            DateTime FechaCreacion = DateTime.Now;
            string FechaCreacionUtc = DateTime.UtcNow.ToString(Engine.FuncionesData.dateFormatUtc);
            string nombreTabla = "Cliente";
            string estado = "INICIADO";
            int r = Engine.FuncionesDb.SyncEstado(versionNew, FechaCreacionUtc, nombreTabla, Usuario, Dispositivo, estado); //NUEVO REGISTRO DE TRANSACCION DE SINCRONIZCION, ESTADO INCIADO

            if (r == 200)// NO EXISTE SINCRONIZACION EN PROCESO
            {
                DataTable dt = new DataTable();
                dt = Engine.FuncionesDb.SelectFilasSync(Version);
                dt = Engine.FuncionesApi.AddColumnVersion(dt, versionNew);
                List<SyncRegistro> Customer = new List<SyncRegistro>();
                estado = "TERMINADO";
                if (dt.Rows.Count == 0) // NO HAY FILAS NUEVAS
                {
                    Engine.FuncionesDb.ActualizarSyncEstado(versionNew, estado);// ACTUALIZA EL ESTADO DE LA TRANCACCION  A TERMINADO
                }
                else // EXISTEN FILA NUEVAS 
                {
                    Customer = Engine.FuncionesApi.SetListaRegistro(dt);  // CONVIERTE  LAS FILAS EN EL MODELO
                    resultado = new JavaScriptSerializer().Serialize(Customer); //SERIALIZA A JSON EL MODELO
                    Engine.FuncionesDb.ActualizarSyncEstado(versionNew, estado);// ACTUALIZA EL ESTADO DE LA TRANSACCION  A TERMINADO
                }
            }
            else if (r == -200)// EXISTE SINCRONIZACION EN PROCESO
            {
                return resultado = "-109";
            }

            return resultado;
        }
    }
}
