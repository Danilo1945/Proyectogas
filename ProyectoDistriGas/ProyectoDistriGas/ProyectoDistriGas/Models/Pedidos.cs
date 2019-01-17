using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
   public class Pedidos
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonProperty("hora")]
        public DateTimeOffset Hora { get; set; }

        [JsonProperty("estado")]
        
        public bool Estado { get; set; }

        [JsonProperty("calificacion_usuario")]
       
        public bool CalificacionUsuario { get; set; }

        [JsonProperty("calificacion_distribuidor")]
        
        public bool CalificacionDistribuidor { get; set; }

        [JsonProperty("usuario_id")]
        public long UsuarioId { get; set; }

        [JsonProperty("distribuidor_id")]
        public long DistribuidorId { get; set; }
    }
}
