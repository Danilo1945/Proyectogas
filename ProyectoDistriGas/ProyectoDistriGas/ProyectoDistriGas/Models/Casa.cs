using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    public class Casa
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("latitud")]
        public double Latitud { get; set; }

        [JsonProperty("longitud")]
        public double Longitud { get; set; }

        [JsonProperty("telefono")]
      
        public string Telefono { get; set; }

        [JsonProperty("usuario_id")]
        public long UsuarioId { get; set; }

        [JsonProperty("usuario")]
        public Usuario Usuario { get; set; }
    }
}
