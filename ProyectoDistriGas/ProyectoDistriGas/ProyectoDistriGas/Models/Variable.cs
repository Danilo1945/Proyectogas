using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;



    public class Variable
    {
        [JsonProperty(PropertyName ="porcentaje")]
        public int Porcentaje { get; set; }
    }

   

}
