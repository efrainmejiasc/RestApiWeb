using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using RestApiWs.Engine;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace RestApiWs.Controllers
{
  
    public class SyncInController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostAddSyncIn([FromBody] List<Cliente> Customer)
        {
            string result = string.Empty;

            if (Customer == null)
            {
                throw new ArgumentNullException();
            }
          
            List<SyncIn> listaSync = new List<SyncIn>();
            int resultado = 0;
            int i = 0;
            foreach (Cliente a in Customer)
            {
                SyncIn sync = new SyncIn();
                string updateId = a.Id;
                a.Id = Engine.FuncionesApi.IdentificadorReg().ToString();
                string existeIdMail = Convert.ToString(Engine.FuncionesDb.ExisteClienteIdMail(a.Id, a.Mail));
                if (existeIdMail == "0" && a.Transaccion == "INSERTAR".ToUpper())
                {
                    resultado = Engine.FuncionesDb.InsertarClienteAll(a.Id, a.Nombre, a.Edad,
                                                                          a.Telefono, a.Mail, a.Saldo,
                                                                          a.FechaCreacion, a.FechaCreacionUtc,
                                                                          a.FechaModificacion, a.FechaModificacionUtc,
                                                                          a.Proceso, a.Usuario, a.Estado.ToUpper(),a.Transaccion);
                    if (resultado == -1)
                    {
                        sync.Id = string.Empty;
                        sync.Id = a.Id;
                        sync.Resultado = true;
                        sync.Error = 0;
                    }
                    else
                    {
                        sync.Id = string.Empty;
                        sync.Id = a.Id;
                        sync.Resultado = false;
                        sync.Error = -102; //EL CLIENTE NO SE PUDO INSERTAR
                    }
                }
                else if ((existeIdMail == "-1" || existeIdMail == "-2") && a.Transaccion == "INSERTAR".ToUpper())
                {
                    sync.Id = string.Empty;
                    sync.Id = a.Id;
                    sync.Resultado = false;
                    sync.Error = -332;// EL ID O MAIL EXISTEN
                }
                else if((existeIdMail == "-1" || existeIdMail == "-2") && (a.Transaccion == "ACTUALIZAR".ToUpper() || a.Transaccion == "ACTUALIZAR_ESTADO".ToUpper()))
                {
                    int proceso = 0;
                    a.Id = updateId;
                    a.FechaCreacion = Engine.FuncionesDb.SelectClienteFechaCreacion(a.Id);
                    a.FechaCreacionUtc = Engine.FuncionesDb.SelectClienteFechaCreacionUtc(a.Id);
                    resultado = Engine.FuncionesDb.ActualizarClienteAll(a.Id, a.Nombre, a.Edad,
                                                                              a.Telefono, a.Mail, a.Saldo,
                                                                              a.FechaCreacion, a.FechaCreacionUtc,
                                                                              a.FechaModificacion, a.FechaModificacionUtc,
                                                                              proceso, a.Usuario, a.Estado.ToUpper(), a.Transaccion);
                    if (resultado == -1)
                    {
                        sync.Id = string.Empty;
                        sync.Id = a.Id;
                        sync.Resultado = true;
                        sync.Error = 0;
                    }
                    else
                    {
                        sync.Id = string.Empty;
                        sync.Id = a.Id;
                        sync.Resultado = false;
                        sync.Error = -104; //EL CLIENTE NO SE PUDO ACTUALIZAR
                    }
                }
                else
                {
                    sync.Id = string.Empty;
                    sync.Id = a.Id;
                    sync.Resultado = false;
                    sync.Error = -333; //EL PAYLOAD NO TIENE EL FORMATO CORRECTO
                }

                listaSync.Insert(i, sync);
                i++;
            }

            result = new JavaScriptSerializer().Serialize(listaSync);
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json")
            };
            response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "OK");
            return response;

        }
    }
}
