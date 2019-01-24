using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Config
{
    
    public class ConfigService
    {
        public string UrlBase = "http://192.168.0.129"; 
        public string Serviceprefix = "/distrigas";
       



        public ConfigService()
        {

        }

        public string GetURLBase()
        {

            return this.UrlBase;
        }
        public string GetServiceprefix()
        {
            return this.Serviceprefix;
        }


    }

    
}
