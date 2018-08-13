﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;


namespace RestApiWs.Controllers
{
    public class ActualizarClienteController : ApiController
    {
        public HttpResponseMessage PutActualizarCliente([FromBody] Cliente Customer)
        {
            if (Customer == null)
            {
                throw new ArgumentNullException();
            }
            string existeNumero= Engine.FuncionesDb.SelectNumeroClienteId(Customer.Id,"ACTIVO");
            if (existeNumero == string.Empty)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                string uri = Url.Link("DefaultApi", new { id = -103});// NO EXISTE EL ID DEL CLIENTE
                response.Headers.Location = new Uri(uri);
                response.Headers.Add("Mensaje", "No Existe el ID");
                return response;
            }

             int proceso  = 0;
             int resultado = Engine.FuncionesDb.ActualizarClienteAll(Customer.Id, Customer.Nombre, Customer.Edad,
                                               Customer.Telefono, Customer.Mail, Customer.Saldo,
                                               Engine.FuncionesDb.SelectClienteFechaCreacion(Customer.Id), Engine.FuncionesDb.SelectClienteFechaCreacionUtc(Customer.Id),
                                               Customer.FechaModificacion, Customer.FechaModificacionUtc,
                                               proceso,Customer.Usuario, Customer.Estado.ToUpper(),"ACTUALIZAR");
            if (resultado == -1)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                //string uri = Url.Link("DefaultApi", new { id = Customer.Id });
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + Customer.Id.ToString());
                response.Headers.Add("Mensaje", "Actualizacion Exitosa");
                return response;
            }
            else
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                string uri = Url.Link("DefaultApi", new { id = -104 });// NO SE PUDO ACTUALIZAR LA TABLA CLIENTE
                response.Headers.Location = new Uri(uri);
                response.Headers.Add("Mensaje", "Actualizacion Fallida");
                return response;
            }

        }
    }
}