using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using Newtonsoft.Json;
using System.Data;
using System.Web.Script.Serialization;

namespace RestApiWs.Controllers
{

    public class ClienteController : ApiController
    {
        [HttpGet]
        public string  GetCliente()
        {
            string  resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataCliente();
            List<Cliente> Customer = new List<Cliente>();
            if (dt.Rows.Count > 0)
            {
                Customer = Engine.FuncionesApi.SetListaCliente(dt);
                resultado = new JavaScriptSerializer().Serialize(Customer);
            }
            return resultado;
        }

        [HttpGet]
        public string  GetCliente(string Id)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataClienteId(Id);
            List<Cliente> Customer = new List<Cliente>();
            if (dt.Rows.Count > 0)
            {
                Customer = Engine.FuncionesApi.SetListaCliente(dt);
                resultado = new JavaScriptSerializer().Serialize(Customer);
            }
            return resultado;
        }

      
    }
}