using Echovoice.JSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                //string k = Convert.ToDateTime (json[0].FechaCreacionUtc).ToString("yyyy-MM-ddTHH:mm:ss+hh:mm");
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
                FechaCreacionUtc = DateTime.UtcNow,
                FechaModificacion = DateTime.Now,
                FechaModificacionUtc = DateTime.UtcNow,
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

        class Wrapper
        {
            [JsonProperty("JsonValues")]
            public Cliente Cliente { get; set; }
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

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime FechaCreacionUtc { get; set; }

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime FechaModificacion { get; set; }

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime FechaModificacionUtc { get; set; }

            [JsonProperty("Proceso")]
            public int Proceso { get; set; }

            [JsonProperty("Usuario")]
            public string Usuario { get; set; }

            [JsonProperty("Estado")]
            public string Estado { get; set; }

            [JsonProperty("Transaccion")]
            public string Transaccion{ get; set; }

        }


        public class Cliente2
        {
            public string Numero { get; set; }

            public string Id { get; set; }

            public string Nombre { get; set; }

            public string  Edad { get; set; }

            public string Telefono { get; set; }

            public string Mail { get; set; }

            public double Saldo { get; set; }

            public string FechaCreacion { get; set; }

            public string FechaCreacionUtc { get; set; }

            public string FechaModificacion { get; set; }

            public string FechaModificacionUtc { get; set; }

            public string Proceso { get; set; }

            public string Usuario { get; set; }

            public string Estado { get; set; }

            public string Transaccion { get; set; }

        }

        public class CustomDateTimeConverter : DateTimeConverterBase
        {
            /// <summary>
            /// DateTime format
            /// </summary>
            private const string Format = "dd. MM. yyyy HH:mm";

            /// <summary>
            /// Writes value to JSON
            /// </summary>
            /// <param name="writer">JSON writer</param>
            /// <param name="value">Value to be written</param>
            /// <param name="serializer">JSON serializer</param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value).ToString(Format));
            }

            /// <summary>
            /// Reads value from JSON
            /// </summary>
            /// <param name="reader">JSON reader</param>
            /// <param name="objectType">Target type</param>
            /// <param name="existingValue">Existing value</param>
            /// <param name="serializer">JSON serialized</param>
            /// <returns>Deserialized DateTime</returns>
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

        public class ExceptionDef
        {
            public string Error { get; set; }

            public string CasoUso { get; set; }

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
                FechaModificacionUtc = DateTime.UtcNow,
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
                FechaModificacionUtc = DateTime.UtcNow,
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
    }
}
