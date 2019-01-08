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
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cedula")]
        public string Cedula { get; set; }

        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty("modified")]
        public DateTimeOffset? Modified { get; set; }

        [JsonProperty("latitud")]
        public double Latitud { get; set; }

        [JsonProperty("longitud")]
        public double Longitud { get; set; }

        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("pedidos_generales")]
        public List<PedidosGenerales> PedidosGenerales { get; set; }

        [JsonProperty("pedidos")]
        public List<Pedido> Pedidos { get; set; }

        [JsonProperty("casa")]
        public List<Casa> Casa { get; set; }

        [JsonProperty("calificacion_usuario")]
        public List<object> CalificacionUsuario { get; set; }
    }

}
