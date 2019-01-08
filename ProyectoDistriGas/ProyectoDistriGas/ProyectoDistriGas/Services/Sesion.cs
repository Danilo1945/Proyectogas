using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.Services
{
    public class Sesion
    {
     
        public long Id { get; set; }
        public bool Enable { get; set; }
         public string Email { get; set; }
        public string Password { get; set; }
        public Sesion(long id,bool enable,string email,string password)
        {
            this.Id = id;
            this.Enable = enable;
            this.Email = email;
            this.Password = password;

        }
        public Sesion()
        {

        }

        public long GetId()
        {
            return this.Id;
        }

    }
}
