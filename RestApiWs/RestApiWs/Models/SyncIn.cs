using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWs.Models
{
    public class SyncIn
    {
       public string Id { get; set; }

       public bool Resultado { get; set; }

       public int  Error { get; set; }

       public string Version { get; set; }

       public string Email { get; set; }
    }
}