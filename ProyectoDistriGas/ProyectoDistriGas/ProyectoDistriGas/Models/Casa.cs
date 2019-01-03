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
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }
        [JsonProperty(PropertyName = "latitud")]
        public double Latitud { get; set; }
        [JsonProperty(PropertyName = "longitud")]
        public double Longitud { get; set; }
        [JsonProperty(PropertyName = "telefono")]
        public string Telefono { get; set; }
        [JsonProperty(PropertyName = "usuario_id")]
        public int Usuario_Id { get; set; }
        [JsonProperty(PropertyName = "usuario")]
        public Usuario Usuario { get; set; }
    }
}
