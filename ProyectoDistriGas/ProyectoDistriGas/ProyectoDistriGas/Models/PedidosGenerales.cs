using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    public class PedidosGenerales
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("hora")]
        public DateTime Hora { get; set; }

        [JsonProperty("estado")]
        
        public bool Estado { get; set; }

        [JsonProperty("usuario_id")]
        public long UsuarioId { get; set; }
        [JsonProperty("usuario")]
        public Usuario Usuario { get; set; }
    }
}
