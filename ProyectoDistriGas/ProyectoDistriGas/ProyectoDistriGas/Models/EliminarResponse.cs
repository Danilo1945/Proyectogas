﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Models
{
   public  class EliminarResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("message")]
        public String Mensaje { get; set; }



    }
}
