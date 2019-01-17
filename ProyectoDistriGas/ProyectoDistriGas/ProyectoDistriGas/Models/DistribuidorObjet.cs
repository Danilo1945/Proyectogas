

namespace ProyectoDistriGas.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    class DistribuidorObjet
    {
        [JsonProperty("distribuidor")]
        public Distribuidor Distribuidor { get; set; }
    }

}
