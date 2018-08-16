using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestApiWs
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Button1.Text = Convert.ToString(Engine.FuncionesDb.ExisteClienteIdMail(Engine.FuncionesApi.IdentificadorReg().ToString(), "mariafksgdfi@gmail.com"));

            DateTime Fecha = DateTime.Now;
            DateTime FechaUtc = DateTime.UtcNow;
            Button1.Text = Fecha.ToString() + " - " + FechaUtc.ToString() + " - " + FechaUtc.ToString(Engine.FuncionesData.dateFormatUtc);
            //int k = 0;
        }
    }
}