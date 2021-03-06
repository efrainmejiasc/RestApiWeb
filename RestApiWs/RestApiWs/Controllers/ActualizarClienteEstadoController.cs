﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using System.Data;

namespace RestApiWs.Controllers
{
    public class ActualizarClienteEstadoController : ApiController
    {
        [HttpPut]
        public HttpResponseMessage PutActualizarClienteEstado([FromBody]  Cliente Customer)
        {
            if (Customer == null)
            {
                throw new ArgumentNullException();
            }

            int r = Engine.FuncionesDb.SyncEstado();
            if (r == -200)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                string uri = Url.Link("DefaultApi", new { id = -109 });//EXISTE UNA SINCRONIZACION EN PROCESO
                response.Headers.Location = new Uri(uri);
                response.Headers.Add("Mensaje", "Sincronizacion en Proceso");
                return response;
            }

            string existeId = Engine.FuncionesDb.SelectClienteId2(Customer.Id);
            if (existeId == string.Empty)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
                response.Headers.Location = new Uri("http://efrain1234-001-site1.ftempurl.com/api/Cliente/" + "-103");//// NO EXISTE EL ID DEL CLIENTE
                return response;
            }

            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataClienteId2(Customer.Id);
            DataRow row = dt.Rows[0];

            int proceso = 0;
            int resultado = Engine.FuncionesDb.ActualizarClienteEstadoAll(Customer.Id, row["Nombre"].ToString(), Convert.ToInt32(row["Edad"]),
                                              row["Telefono"].ToString(), row["Mail"].ToString(), Convert.ToDouble(row["Saldo"]),
                                              Convert.ToDateTime(row["FechaCreacion"]), row["FechaCreacionUtc"].ToString(),
                                              Customer.FechaModificacion, Customer.FechaModificacionUtc,
                                              proceso, Customer.Usuario, Customer.Estado.ToUpper(), Customer.Transaccion);
            if (resultado == -1)
            {
                var response = Request.CreateResponse<Cliente>(HttpStatusCode.Created, Customer);
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
