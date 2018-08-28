using Newtonsoft.Json;
using RestApiWs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RestApiWs.Controllers
{
    public class NuevoClienteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostAddNuevoCliente([FromBody] Cliente Customer)
        {
            if (Customer == null)
            {
                throw new ArgumentNullException();
            }

            int r = Engine.FuncionesDb.SyncEstado();
            if (r == -200)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-109");//EXISTE UNA SINCRONIZACION EN PROCESO
                return response;
            }

            string existeIdMail = "-1";
            while(existeIdMail == "-1")
            {
                Customer.Id = Engine.FuncionesApi.IdentificadorReg().ToString();
                existeIdMail = Convert.ToString(Engine.FuncionesDb.ExisteClienteIdMail(Customer.Id, Customer.Mail));
            }

            if (existeIdMail == "-2")
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-107");//EL MAIL YA ESTA REGISTRADO
                return response;
            }

            int resultado = Engine.FuncionesDb.InsertarClienteAll(Customer.Id, Customer.Nombre, Customer.Edad,
                                               Customer.Telefono, Customer.Mail, Customer.Saldo,
                                               Customer.FechaCreacion, Customer.FechaCreacionUtc,
                                               Customer.FechaModificacion, Customer.FechaModificacionUtc,
                                               Customer.Proceso, Customer.Usuario, Customer.Estado.ToUpper(), Customer.Transaccion);
            if (resultado == -1)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + Customer.Id.ToString());
                return response;
            }
            else
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-104");//EL CLIENTE NO PUDO SER REGISTRADO
                return response;
            }
        }
    }
}
