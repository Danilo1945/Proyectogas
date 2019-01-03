using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    public class CilindroGa
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "colo")]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "detalle")]
        public string Detalle { get; set; }
        [JsonProperty(PropertyName = "direccion_ip")]
        public string Direccion_Ip { get; set; }
        [JsonProperty(PropertyName = "casa_id")]
        public int? Casa_Id { get; set; }
        [JsonProperty(PropertyName = "casa")]
        public Casa Casa { get; set; }
    }
}
