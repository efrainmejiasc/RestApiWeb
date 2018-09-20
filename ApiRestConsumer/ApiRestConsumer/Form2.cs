using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ApiRestConsumer.FloraNuevaProductor;

namespace ApiRestConsumer
{
    public partial class Form2 : Form
    {
        private string Version = string.Empty;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            picImagenEmpleado.Image = Image.FromFile(Application.StartupPath + @"\efrain.jpg");
        }

        // REGISTRO DE SINCRONIZACION 
        private void BtnIniciarSync_Click(object sender, EventArgs e)
        {
            ClienteRegistroSync Cliente = new ClienteRegistroSync()
            {
                Version = string.Empty,
                Usuario = "Efrain-001",
                Dispositivo = "EMCServer",
                Estado = "INICIADO"
            };
            var jsonInicioSync = JsonConvert.SerializeObject(Cliente);
            IniciarSync(jsonInicioSync);
        }

        public async void IniciarSync(string jsonInicioSync)
        {
            string urlValidacion = string.Empty;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsync("http://localhost:52143/api/EngineSync/", new StringContent(jsonInicioSync, Encoding.UTF8, "application/json"));
           // HttpResponseMessage response = await client.PostAsync("http://floranueva-001-site1.ctempurl.com/api/EngineSync/", new StringContent(jsonInicioSync, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                urlValidacion = response.Headers.Location.ToString();
                richTextBox1.Text = urlValidacion;
                if (richTextBox1.Text != string.Empty)
                {
                    string [] partes = richTextBox1.Text.Split('/');
                    if (partes[partes.Length -1] != "-109" && partes[partes.Length - 1] != "-110")//-109 Sincronizacion en proceso , -110 registro fallido para sincronizar
                    {
                        Version = partes[partes.Length - 1];
                    }
                }
            }
            else
            {
                urlValidacion = response.IsSuccessStatusCode.ToString();
                richTextBox1.Text = urlValidacion;
            }

        }

        public class ClienteRegistroSync
        {
            public string Version { get; set; }

            public string Usuario { get; set; }

            public string Dispositivo { get; set; }

            public string Estado { get; set; }
        }

        //OBTENER  TABLAS DESDE API 1ERA SINCRONIZACION
        private void BtnPrimerSync_Click(object sender, EventArgs e)
        {
            ClientGetTablas("api/SeleccionCompleta?Version=" + Version);
        }

        private void ClientGetTablas(string RequestURI)
        {
            string resultado = string.Empty;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:52143/");
            //client.BaseAddress = new Uri("http://floranueva-001-site1.ctempurl.com/" + Version);
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
                resultado = resultado.Replace("r", "");
                resultado = resultado.Replace("n", "");
                richTextBox1.Text = resultado;
            }
            else
            {
                resultado = response.IsSuccessStatusCode.ToString();
                richTextBox1.Text = resultado;
            }
        }

        // FINALIZAR SINCRONIZACION 
        private void BtnFinalizarSync_Click(object sender, EventArgs e)
        {
            SyncEstado SyncEstado = new SyncEstado
            {
                Version = Version,
                Estado = "TERMINADO",
            };

            var jsonFinalizarSync = JsonConvert.SerializeObject(SyncEstado);
            FinalizarSync(jsonFinalizarSync);
        }

        public async void FinalizarSync(string jsonFinalizarSync)
        {
            string urlValidacion = string.Empty;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PutAsync("http://localhost:52143/api/EngineSync/", new StringContent(jsonFinalizarSync, Encoding.UTF8, "application/json"));
            //HttpResponseMessage response = await client.PutAsync("http://floranueva-001-site1.ctempurl.com/api/EngineSync/", new StringContent(jsonFinalizarSync, Encoding.UTF8, "application/json"));
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

        public class SyncEstado
        {
            public string Version { get; set; }

            public string Estado { get; set; }
        }


        // OBTENER REGISTROS ACTUALIZADOS LUEGO DE LA ULTIMA SINCRONIZACION
        private void BtnPosterioresSync_Click(object sender, EventArgs e)
        {
            string VersionOld = "82B76B2D-2FBF-4EDD-8B39-CB8035F1CCAA"; // Ultima Version Obtenida
            ClientGetRegistros("api/SeleccionRegistrosSync?VersionOld=" + VersionOld + "&VersionNew=" +  Version);
        }

        private void ClientGetRegistros(string RequestURI)
        {
            string resultado = string.Empty;
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:52143/");
            client.BaseAddress = new Uri("http://floranueva-001-site1.ctempurl.com/" + Version);
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
                resultado = resultado.Replace("r", "");
                resultado = resultado.Replace("n", "");
                richTextBox1.Text = resultado;
            }
            else
            {
                resultado = response.IsSuccessStatusCode.ToString();
                richTextBox1.Text = resultado;
            }
        }

        private void BtnNuevoProductor_Click(object sender, EventArgs e)
        {
            FloraNuevaProductor FloraNueva = new FloraNuevaProductor()
            {
                MiProductor = new Productor()
                {
                    Identificador = string.Empty,
                    IdUsuarioEncuestador = 2,
                    FechaEncuesta = DateTime.Now,
                    VisitaALaCasa = false,
                    IdEstadoDiagnostico = 2,
                    Nombres = "Juan Carlos",
                    Apellido1 = "Gonzalez",
                    Apellido2 = "Beltran",
                    NumeroCedula = "11589753",
                    Estado = "ACTIVO",
                    Usuario = "efrain001",
                    Dispositivo = "EmcServer",
                    Transaccion = "INSERTAR"
                },
               MiProductorDocumentoEntregado = new ProductorDocumentoEntregado()
               {
                   IdProductorDocumentoEntregado = 0,
                   IdProductor = 0,
                   IdTipoDocumento = 6,
                   Detalle = "Detalle de Documento Entregado"
               }
            };
            var jsonCliente = JsonConvert.SerializeObject(FloraNueva);
            CrearProductor(jsonCliente);
            //InsertarPrueba();
        }


        public async void CrearProductor(string json)
        {
            string urlValidacion = string.Empty;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsync("http://localhost:52143/api/NuevoRegistroProductor", new StringContent(json, Encoding.UTF8, "application/json"));
            //HttpResponseMessage response = await client.PostAsync("http://floranueva-001-site1.ctempurl.com/api/NuevoRegistroProductor", new StringContent(json, Encoding.UTF8, "application/json"));
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
        public Image Foto { get; set; }
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["CnxFloraNueva"].ToString();

        public int InsertarPrueba()
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarPrueba", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Identificador", "42A60455-36F2-4EEE-A55F-C02D5D0BF95A");
                command.Parameters.AddWithValue("@Nombre", "EFRAIN");
                command.Parameters.AddWithValue("@Edad", 46);
                command.Parameters.AddWithValue("@Estado", "ACTIVO");
                if (Foto == null)
                {
                    Foto = ObtenerImagenNoDisponible();
                    byte[] Imagen = ImageToByteArray(Foto)
 ;
                    SqlParameter imageParam = command.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                    imageParam.Value = Imagen;
                }
                else
                {
                    SqlParameter imageParam = command.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                    imageParam.Value = ImageToByteArray(Foto);
                }
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }
            return resultado;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image ObtenerImagenNoDisponible()
        {
            Image img = Image.FromFile(Application.StartupPath  + @"\efrain.jpg");
            return img;
        }

    }
}
