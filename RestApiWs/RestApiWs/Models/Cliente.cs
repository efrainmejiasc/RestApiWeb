using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RestApiWs.Models
{
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
            public string Transaccion { get; set; }

        


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

    }
}