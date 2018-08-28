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
        //METODO PARA OBTENER REGISTROS LA VEZ QUE SE INSTALA LA APLICACION EN EL CLIETE
        [HttpGet]
        public string  GetSyncOut_Init(string Usuario , string Dispositivo)
        {
            string resultado = string.Empty;
            string version = string.Empty;
            int existe = 1;
            //CREAR VERSION DE LA SINCRONIZACION
            while (existe > 0)
            {
                version = Engine.FuncionesApi.IdentificadorReg().ToString();
                existe = Engine.FuncionesDb.ExisteVersionSync(version);
            }

            DateTime FechaCreacion = DateTime.Now;
            string FechaCreacionUtc = DateTime.UtcNow.ToString(Engine.FuncionesData.dateFormatUtc);
            string nombreTabla = "Cliente";
            string estado = "INICIADO";
            int r = Engine.FuncionesDb.SyncEstado(version,FechaCreacionUtc, nombreTabla, Usuario, Dispositivo, estado);//NUEVO REGISTRO DE TRANSACCION DE SINCRONIZCION, ESTADO INCIADO

            if (r == 200)// NO EXISTE SINCRONIZACION EN PROCESO
            {
                resultado = GetClienteAll(version);
            }
            else if (r == -200)// EXISTE SINCRONIZACION EN PROCESO
            {
                resultado = "-109";
            }
            return resultado;
        }

        private string GetClienteAll(string version)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataCliente();
            dt = Engine.FuncionesApi.AddColumnVersion(dt,version);
            List<SyncRegistro> Customer = new List<SyncRegistro>();
            string estado = "TERMINADO";
            if (dt.Rows.Count == 0)// NO HAY FILAS NUEVAS
            {
                Engine.FuncionesDb.ActualizarSyncEstado(version, estado);// ACTUALIZA EL ESTADO DE LA TRANCACCION  A TERMINADO
            }
            else// EXISTEN FILA NUEVAS 
            {
                Customer = Engine.FuncionesApi.SetListaRegistro(dt);// CONVIERTE  LAS FILAS EN EL MODELO
                resultado = new JavaScriptSerializer().Serialize(Customer);//SERIALIZA A JSON EL MODELO
                Engine.FuncionesDb.ActualizarSyncEstado(version ,estado);// ACTUALIZA EL ESTADO DE LA TRANSACCION  A TERMINADO
            }
            return resultado;
        }

        //*****************************************************************************************************************************************************************************
        //*****************************************************************************************************************************************************************************

        //METODO PARA OBTENER REGISTROS DESPUES DEL POST DE LA SINCRONIZACION
        [HttpGet]
        public string GetSyncOut_Next(string Usuario, string Dispositivo, string Version)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.SelectFilasSync(Version);
            dt = Engine.FuncionesApi.AddColumnVersion(dt, Version);
            List<SyncRegistro> Customer = new List<SyncRegistro>();
            string estado = "TERMINADO";
            if (dt.Rows.Count == 0)
            {
                Engine.FuncionesDb.ActualizarSyncEstado(Version, estado);// ACTUALIZA EL ESTADO DE LA TRANSACCION  A TERMINADO
            }
            else
            {
                Customer = Engine.FuncionesApi.SetListaRegistro(dt);// CONVIERTE  LAS FILAS EN EL MODELO
                resultado = new JavaScriptSerializer().Serialize(Customer);//SERIALIZA A JSON EL MODELO
                Engine.FuncionesDb.ActualizarSyncEstado(Version, estado);// ACTUALIZA EL ESTADO DE LA TRANSACCION  A TERMINADO
            }
            return resultado;
        }


        //METODO PARA OBTENER EL ESTADO DE LA SINCRONIZACION
        [HttpGet]
        public string GetSyncInOut_Exito(string version)
        {
            string resultado = string.Empty;
            SyncEstado SyncEstado = new SyncEstado();
            int r = Engine.FuncionesDb.SyncInOutExito(version);
            if (r > 0)
            {
                SyncEstado = Engine.FuncionesApi.SetSynEstado(version, "OK");
                resultado = new JavaScriptSerializer().Serialize(SyncEstado);
            }
            else
            {
                SyncEstado = Engine.FuncionesApi.SetSynEstado(version, "FALLO");
                resultado = new JavaScriptSerializer().Serialize(SyncEstado);
            }
            return resultado;
        }

    }
}
