using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApiWs.Models;
using RestApiWs.Engine;

namespace RestApiWs.Controllers
{
    public class SyncInController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostSyncIn([FromBody] string Customer)
        {

            if (Customer == null)
            {
                throw new ArgumentNullException();
            }

            SyncIn SyncInResultado = new SyncIn();
            List<SyncIn> listaSyncIn = new List<SyncIn>();
            var response = Request.CreateResponse<List<SyncIn>>(HttpStatusCode.Created, listaSyncIn );

            return response;
        }
    }
}
