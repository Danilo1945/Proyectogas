
namespace ProyectoDistriGas.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PedidosGeneralesObjet
    {
        [JsonProperty("pedidosGenerales")]
        public List<PedidosGenerales> PedidosGenerales { get; set; }
    }
}
