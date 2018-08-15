using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWs.Engine
{
    public class FuncionesApi
    {
        public static Guid IdentificadorReg()
        {
            Guid g = CrearGuid();
            while (g != Guid.Empty)
            {
                return g;
            }
            return g;
        }

        private static Guid CrearGuid()
        {
            return Guid.NewGuid();
        }

        public static DateTime FechaActual()
        {
            return DateTime.Now;
        }

        public static DateTime FechaActualUtc()
        {
            return DateTime.UtcNow;
        }




      
    }
}