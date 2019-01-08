using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
     public class CasaObjet
    {
        [JsonProperty("casa")]
        public Casa Casa { get; set; }
    }
}
