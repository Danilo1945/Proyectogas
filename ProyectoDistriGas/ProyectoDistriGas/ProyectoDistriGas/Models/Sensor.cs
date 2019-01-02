

namespace ProyectoDistriGas.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Sensor
    {
        
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "hardware")]
        public string Hardware { get; set; }
        [JsonProperty(PropertyName = "connected")]
        public bool Connected { get; set; }
    }
}
