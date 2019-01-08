using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
   public  class UsuarioObjet
    {
        [JsonProperty("usuario")]
        public Usuario Usuario { get; set; }
    }
}
