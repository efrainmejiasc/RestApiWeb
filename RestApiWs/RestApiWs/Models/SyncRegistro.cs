using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RestApiWs.Models
{
    public class SyncRegistro
    {
        [JsonProperty("Dispositivo")]
        public string Dispositivo { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

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

    }
}