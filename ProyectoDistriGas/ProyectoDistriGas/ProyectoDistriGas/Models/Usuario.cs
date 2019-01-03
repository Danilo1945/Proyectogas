using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    public class Usuario
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "cedula")]
        public string Cedula { get; set; }
        [JsonProperty(PropertyName = "nombres")]
        public string Nombres { get; set; }
        [JsonProperty(PropertyName = "apellidos")]
        public string Apellidos { get; set; }
        [JsonProperty(PropertyName = " celula")]
        public string Celular { get; set; }
        [JsonProperty(PropertyName = "direccion")]
        public string Direccion { get; set; }
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; set; }
        [JsonProperty(PropertyName = "modified")]
        public DateTime? Modified { get; set; }
        [JsonProperty(PropertyName = "latitud")]
        public double Latitud { get; set; }
        [JsonProperty(PropertyName = "longitud")]
        public double Longitud { get; set; }
        [JsonProperty(PropertyName = "enable")]
        public bool Enable { get; set; }
        [JsonProperty(PropertyName = "enable")]
        public string Email { get; set; }
    }

}
