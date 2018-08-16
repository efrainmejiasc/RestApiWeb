using Echovoice.JSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ApiRestConsumer
{
    public partial class Form1 : Form
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["CnxRestSync"].ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
             string cliente = string.Empty;
             if (txtId2.Text == string.Empty)
             {
                 cliente = ClientGetRequest("api/Cliente/");
             }
             else
             {
                 cliente  = ClientGetRequest("api/Cliente/" + txtId2.Text);
             }
        }

        private string  ClientGetRequest(string RequestURI)
        {
            string resultado = string.Empty;

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:50445/");
            client.BaseAddress = new Uri("http://efrain1234-001-site1.ftempurl.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = new HttpResponseMessage();
            response = client.GetAsync(RequestURI).Result;
            if (response.IsSuccessStatusCode)
            {
                resultado = response.Content.ReadAsStringAsync().Result;
                resultado = resultado.Replace("\\", "");
                resultado = resultado.Replace("/", "");
                resultado = resultado.Replace("\"[", "[");
                resultado = resultado.Replace("]\"", "]");
                string [] partes = resultado.Split(',');
                foreach (string item in partes)
                {
                 richTextBox1.Text = richTextBox1.Text + Environment.NewLine + item;
                }

                var resulta = resultado;
                List<Cliente> json = JsonConvert.DeserializeObject<List<Cliente>>(resulta);
            }
            else
            {
                resultado  = response.IsSuccessStatusCode.ToString();
                richTextBox1.Text = resultado;
            }

            return resultado;
        }

     
        private void BtnPost_Click(object sender, EventArgs e)
        {
            Cliente Customer = new Cliente
            {
                Numero = 0,
                Id = string.Empty,
                Nombre = txtNombre.Text,
                Edad = Convert.ToInt16(txtEdad.Text),
                Telefono = txtTelefono.Text,
                Mail = txtEmail.Text,
                Saldo = Convert.ToDouble(txtSaldo.Text),
                FechaCreacion = DateTime.Now,
                FechaCreacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = txtUsuario.Text,
                Estado = "ACTIVO",
                Transaccion="INSERTAR"

            };
            var jsonCliente = JsonConvert.SerializeObject(Customer);
            EnviarDocumentoPost(jsonCliente);
        }

        public async void  EnviarDocumentoPost(string json)
        {
            string urlValidacion = string.Empty;
         
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.PostAsync("http://localhost:50445/api/NuevoCliente/", new StringContent(json, Encoding.UTF8, "application/json"));
            HttpResponseMessage response = await client.PostAsync("http://efrain1234-001-site1.ftempurl.com/api/NuevoCliente/", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.Location.ToString();
                richTextBox1.Text = urlValidacion;
            }
            else
            {
                urlValidacion = response.IsSuccessStatusCode.ToString();
                richTextBox1.Text = urlValidacion;
            }

        }

        public class Cliente
        {

            [JsonProperty("Numero")]
            public int Numero { get; set; }

            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Nombre")]
            public string Nombre { get; set; }

            [JsonProperty("Edad")]
            public int Edad { get; set; }

            [JsonProperty("Telefono")]
            public string Telefono { get; set; }

            [JsonProperty("Mail")]
            public string Mail { get; set; }

            [JsonProperty("Saldo")]
            public double Saldo { get; set; }

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime FechaCreacion { get; set; }

            [JsonProperty("FechaCreacionUtc")]
            public string FechaCreacionUtc { get; set; }

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime FechaModificacion { get; set; }

            [JsonProperty("FechaModificacionUtc")]
            public string FechaModificacionUtc { get; set; }

            [JsonProperty("Proceso")]
            public int Proceso { get; set; }

            [JsonProperty("Usuario")]
            public string Usuario { get; set; }

            [JsonProperty("Estado")]
            public string Estado { get; set; }

            [JsonProperty("Transaccion")]
            public string Transaccion { get; set; }
        }



            public class CustomDateTimeConverter : DateTimeConverterBase
        {
            
            private const string Format = "dd. MM. yyyy HH:mm";

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString(Format));
            }

      
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null)
                {
                    return null;
                }

                var s = reader.Value.ToString();
                DateTime result;
                if (DateTime.TryParseExact(s, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    return result;
                }

                return DateTime.Now;
            }
        }


        private void btnPut_Click(object sender, EventArgs e)
        {
            Cliente Customer = new Cliente
            {
                Numero = 0,
                Id = txtId.Text,
                Nombre = txtNombre2.Text,
                Edad = Convert.ToInt16(txtEdad2.Text),
                Telefono = txtTelefono2.Text,
                Mail = txtEmail2.Text,
                Saldo = Convert.ToDouble(txtSaldo2.Text),
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = txtUsuario2.Text,
                Estado = txtEstado.Text,
                Transaccion = "ACTUALIZAR"
            };

            var jsonCliente = JsonConvert.SerializeObject(Customer);
            EnviarDocumentoPut(jsonCliente);
        }

        public async void EnviarDocumentoPut(string json)
        {
            string urlValidacion = string.Empty;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             //HttpResponseMessage response = await client.PutAsync("http://localhost:50445/api/ActualizarCliente/", new StringContent(json, Encoding.UTF8, "application/json"));
            HttpResponseMessage response = await client.PutAsync("http://efrain1234-001-site1.ftempurl.com/api/ActualizarCliente/", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.Location.ToString();
                richTextBox1.Text = urlValidacion;
            }
            else
            {
                urlValidacion = response.StatusCode.ToString();
                richTextBox1.Text = urlValidacion;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId2.Text == string.Empty) return;
            EnviarDocumentoDelete(txtId2.Text);
        }

        public async void EnviarDocumentoDelete(string Id)
        {
            string urlValidacion = string.Empty;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.DeleteAsync("http://efrain1234-001-site1.ftempurl.com/api/EliminarCliente/" + txtId2.Text);
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.ToString();
                richTextBox1.Text = urlValidacion;
            }
            else
            {
                urlValidacion = response.StatusCode.ToString();
                richTextBox1.Text = urlValidacion;
            }

        }

        private void btnPut2_Click(object sender, EventArgs e)
        {
            Cliente Customer = new Cliente
            {
                Numero = 0,
                Id = txtId2.Text,
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = txtUsuario3.Text,
                Estado = txtEstado2.Text,
                Transaccion = "ACTUALIZAR_ESTADO"
            };

            var jsonCliente = JsonConvert.SerializeObject(Customer);
            EnviarDocumentoPut2(jsonCliente);
        }

        public async void EnviarDocumentoPut2(string json)
        {
            string urlValidacion = string.Empty;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.PutAsync("http://localhost:50445/api/ActualizarClienteEstado/", new StringContent(json, Encoding.UTF8, "application/json"));
            HttpResponseMessage response = await client.PutAsync("http://efrain1234-001-site1.ftempurl.com/api/ActualizarClienteEstado/", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.Location.ToString();
                richTextBox1.Text = urlValidacion + Environment.NewLine  + "SI MODIFICASTE A INACTIVO O ELIMINADO AL CONSULTARLO NO FOUND";
            }
            else
            {
                urlValidacion = response.StatusCode.ToString();
                richTextBox1.Text = urlValidacion;
            }

        }



        private void btnJsonSend_Click(object sender, EventArgs e)
        {
           string json = SetListaCliente();
           EnviarDocumentoPost2(json);
        }

        public string SetListaCliente()
        {
           List<Cliente> Customer = new List<Cliente>();
           Cliente lineaCliente = new Cliente
           {
                Numero = 0,
                Id = "C0A2D3F2-8530-47BB-B833-000BA4FB1B7B",
                Nombre = "EFRAIN MEJIAS",
                Edad = 46,
                Telefono = "0424-4133677",
                Mail = "efrainmejiasc@gmail.com",
                Saldo = 20000000.678,
                FechaCreacion = DateTime.Now,
                FechaCreacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = "EFRAIN",
                Estado = "ACTIVO",
                Transaccion= "INSERTAR",
           };
            Customer.Insert (0,lineaCliente);
            lineaCliente = new Cliente
            {
                Numero = 0,
                Id = "866B3180-C080-4CD9-BA19-DE5E983DE9D5",
                Nombre = "JUAN MEJIAS",
                Edad = 42,
                Telefono = "0424-4133677",
                Mail = "Juan@gmail.com",
                Saldo = 3000,
                FechaCreacion = DateTime.Now,
                FechaCreacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = "EFRAIN",
                Estado = "ACTIVO",
                Transaccion = "INSERTAR",
            };
            Customer.Insert(1, lineaCliente);
            lineaCliente = new Cliente
            {
                Numero = 0,
                Id = "33125839-A192-4BB6-A0D0-5C022AAFC02F",
                Nombre = "ROGER MEJIAS",
                Edad = 32,
                Telefono = "0424-4133677",
                Mail = "JuanCarlos@gmail.com",
                Saldo = 1000000,
                FechaCreacion = DateTime.Now,
                FechaCreacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss+hh:mm"),
                Proceso = 0,
                Usuario = "EFRAIN",
                Estado = "INACTIVO",
                Transaccion = "INSERTAR",
            };
            Customer.Insert(2, lineaCliente);

            var jsonCliente = JsonConvert.SerializeObject(Customer);
            return jsonCliente;
        }

        public async void EnviarDocumentoPost2(string json)
        {
            string urlValidacion = string.Empty;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.PostAsync("http://localhost:50445/api/SyncIn/", new StringContent(json, Encoding.UTF8, "application/json"));
            HttpResponseMessage response = await client.PostAsync("http://efrain1234-001-site1.ftempurl.com/api/SyncIn/", new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.Location.ToString();
                string  jsonValidacion = response.Content.ReadAsStringAsync().Result;
                richTextBox1.Text = urlValidacion;
            }
            else
            {
                urlValidacion = response.IsSuccessStatusCode.ToString();
                string jsonValidacion = response.Content.ReadAsStringAsync().Result;
                richTextBox1.Text = urlValidacion;
            }

        }

    }
}
