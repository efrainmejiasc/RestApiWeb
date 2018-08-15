using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using Newtonsoft.Json;
using System.Data;
using RestApiWs.Engine;
using System.Web.Script.Serialization;

namespace RestApiWs.Controllers
{
    public class ClienteController : ApiController
    {
        public string  GetCliente()
        {
            string  resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataCliente();
            List<Cliente> Customer = new List<Cliente>();
            if (dt.Rows.Count == 0)
            {
                return resultado ;
            }
            else
            {
             Customer = SetListaCliente(dt);
             resultado = new JavaScriptSerializer().Serialize(Customer);
            }

            return resultado;
        }

        public string  GetCliente(string Id)
        {
            string resultado = string.Empty;
            DataTable dt = new DataTable();
            dt = Engine.FuncionesDb.TableDataClienteId(Id);
            List<Cliente> Customer = new List<Cliente>();
            if (dt.Rows.Count == 0)
            {
                return resultado;
            }
            else
            {
              Customer = SetListaCliente(dt);
              resultado = new JavaScriptSerializer().Serialize(Customer);
            }

            return resultado;
        }

        private List<Cliente> SetListaCliente (DataTable dt)
        {
            List<Cliente> Customer = new List<Cliente>();
            foreach (DataRow r in dt.Rows)
            {
                Cliente lineaCliente = new Cliente
                {
                    Numero = Convert.ToInt32(r[0]),
                    Id = r[1].ToString(),
                    Nombre = r[2].ToString(),
                    Edad = Convert.ToInt32(r[3]),
                    Telefono = r[4].ToString(),
                    Mail = r[5].ToString(),
                    Saldo = Convert.ToDouble(r[6]),
                    FechaCreacion = Convert.ToDateTime(r[7]),
                    FechaCreacionUtc = Convert.ToDateTime(r[8]),
                    FechaModificacion = Convert.ToDateTime(r[9]),
                    FechaModificacionUtc = Convert.ToDateTime(r[10]),
                    Proceso = Convert.ToInt32(r[11]),
                    Usuario = r[12].ToString(),
                    Estado = r[13].ToString(),
                };
                Customer.Add(lineaCliente);
            }
            return Customer;
        } 

   
    }
}