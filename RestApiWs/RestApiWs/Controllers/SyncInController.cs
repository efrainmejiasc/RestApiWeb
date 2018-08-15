using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using RestApiWs.Engine;
using Newtonsoft.Json;

namespace RestApiWs.Controllers
{
    public class SyncInController : ApiController
    {
        [HttpPost]
        public string  PostSyncIn([FromBody] List<Cliente> Customer)
        {
            string result = string.Empty;

            if (Customer == null)
            {
                throw new ArgumentNullException();
            }
            SyncIn sync = new SyncIn();
            List<SyncIn> listaSync = new List<SyncIn>();
            // var resultado = JsonConvert.DeserializeObject<List<Cliente>>(Customer);
            int resultado = 0;
            foreach (Cliente a in Customer)
            {
                a.Id = Engine.FuncionesApi.IdentificadorReg().ToString();
                string existeIdMail = Convert.ToString(Engine.FuncionesDb.ExisteClienteIdMail(a.Id, a.Mail));
                if (existeIdMail == "0" && a.Transaccion.Contains("INSERTAR".ToUpper()))
                {
                    resultado = Engine.FuncionesDb.InsertarClienteAll(a.Id, a.Nombre, a.Edad,
                                                                          a.Telefono, a.Mail, a.Saldo,
                                                                          a.FechaCreacion, a.FechaCreacionUtc,
                                                                          a.FechaModificacion, a.FechaModificacionUtc,
                                                                          a.Proceso, a.Usuario, a.Estado.ToUpper(),a.Transaccion);
                    if (resultado == -1)
                    {
                        sync.Id = a.Id;
                        sync.Resultado = true;
                        sync.Error = 0;
                    }
                    else
                    {
                        sync.Id = a.Id;
                        sync.Resultado = false;
                        sync.Error = -102; //EL CLIENTE NO SE PUDO INSERTAR
                    }
                }
                else if((existeIdMail == "-1" || existeIdMail == "-2") && a.Transaccion.Contains ("ACTUALIZAR".ToUpper()) )
                {
                    int proceso = 0;
                    resultado = Engine.FuncionesDb.ActualizarClienteAll(a.Id, a.Nombre, a.Edad,
                                                                              a.Telefono, a.Mail, a.Saldo,
                                                                              Engine.FuncionesDb.SelectClienteFechaCreacion(a.Id), Engine.FuncionesDb.SelectClienteFechaCreacionUtc(a.Id),
                                                                              a.FechaModificacion, a.FechaModificacionUtc,
                                                                              proceso, a.Usuario, a.Estado.ToUpper(), a.Transaccion);
                    if (resultado == -1)
                    {
                        sync.Id = a.Id;
                        sync.Resultado = true;
                        sync.Error = 0;
                    }
                    else
                    {
                        sync.Id = a.Id;
                        sync.Resultado = false;
                        sync.Error = -104; //EL CLIENTE NO SE PUDO ACTUALIZAR
                    }
                }
                else
                {
                    sync.Id = a.Id;
                    sync.Resultado = false;
                    sync.Error = -333; //EL PAYLOAD NO TIENE EL FORMATO CORRECTO
                }

                listaSync.Add(sync);
            }

            return result;
        }
    }
}
