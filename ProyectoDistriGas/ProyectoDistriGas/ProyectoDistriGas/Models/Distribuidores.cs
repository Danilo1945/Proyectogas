using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    class Distribuidores
    {
        [JsonProperty("distribuidor")]
        public List<Distribuidor> Distribuidor { get; set; }
    }
}
