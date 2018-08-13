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
        public HttpResponseMessage PostAddNuevoCliente([FromBody] NuevoCliente Customer)
        {
            if (Customer == null)
            {
                throw new ArgumentNullException();
            }

            Customer.Id = Engine.FuncionesApi.IdentificadorReg().ToString();
            string existeIdMail = Convert.ToString(Engine.FuncionesDb.ExisteClienteIdMail(Customer.Id, Customer.Mail));
            if ( existeIdMail == "-1" )
            {
                var response = Request.CreateResponse<NuevoCliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-100");//EL ID  YA ESTA REGISTRADO
                return response;
            }
           else if (existeIdMail == "-2")
            {
                var response = Request.CreateResponse<NuevoCliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-107");//EL MAIL YA ESTA REGISTRADO
                return response;
            }

            int resultado = Engine.FuncionesDb.InsertarClienteAll(Customer.Id, Customer.Nombre, Customer.Edad,
                                               Customer.Telefono, Customer.Mail, Customer.Saldo,
                                               Customer.FechaCreacion, Customer.FechaCreacionUtc,
                                               Customer.FechaModificacion, Customer.FechaModificacionUtc,
                                               Customer.Proceso, Customer.Usuario, Customer.Estado.ToUpper(), "INSERTAR");
            if (resultado == -1)
            {
                var response = Request.CreateResponse<NuevoCliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + Customer.Id.ToString());
                return response;

            }

            else
            {
                var response = Request.CreateResponse<NuevoCliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-102");//EL CLIENTE NO PUDO SER REGISTRADO
                return response;
            }
        }
    }
}
