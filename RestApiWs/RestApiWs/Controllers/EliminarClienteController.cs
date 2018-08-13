using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Engine;
namespace RestApiWs.Controllers
{
    public class EliminarClienteController : ApiController
    {

        public HttpResponseMessage DeleteCliente(string  Id)
        {
            if (Id == string.Empty)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            int resultado = FuncionesDb.BorrarCliente(Id);
            if (resultado == -1)
            {
                var response = new HttpResponseMessage();
                response.Headers.Add("EliminarCliente", "Eliminado Exitosamente");
                return response;
            }
            else
            {
                var response = new HttpResponseMessage();
                response.Headers.Add("EliminarCliente", "Fallo Al Eliminar");
                return response;
            }
        }
    }
}
