using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWs.Engine
{
    public class FuncionesData
    {
        private static FuncionesData valor;
        public static FuncionesData Instance()
        {
            if ((valor == null))
            {
                valor = new FuncionesData();
            }
            return valor;
        }

        public const string dateFormatUtc = "yyyy-MM-ddTHH:mm:ss+hh:mm";
    }
}