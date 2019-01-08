using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
   public class Usuarios
    {
        [JsonProperty("usuario")]
        public List<Usuario> Usuario { get; set; }
    }
}
