
namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    public class DetallePedidoGeneralViewModel:BaseViewModel
    {
        #region Atributos
        private long id;
        private long idP;
        private string nombres;
        private string apellidos;
        private string cedula;
        private string celular;
        private string direccion;
        private string email;
        private double latitud;
        private double longitud;

        #endregion
        #region propiedades
        public PedidosGenerales PedidosGenerales
        {
            get;
            set;
        }
        public long Id
        {
            get { return id; }
            set { SetValue(ref id, value); }
        }
        public long IdP
        {
            get { return idP; }
            set { SetValue(ref idP, value); }
        }
        public string Cedula
        {
            get { return cedula; }
            set { SetValue(ref cedula, value); }
        }

        #endregion

        public string Nombres
        {
            get { return nombres; }
            set { SetValue(ref nombres, value); }
        }

   
        public string Apellidos
        {
            get { return apellidos; }
            set { SetValue(ref apellidos, value); }
        }

        public string Celular
        {
            get { return celular; }
            set { SetValue(ref celular, value); }
        }
        public string Direccion
        {
            get { return direccion; }
            set { SetValue(ref direccion, value); }
        }

        public double Latitud
        {
            get { return latitud; }
            set { SetValue(ref latitud, value); }
        }

        public double Longitud
        {
            get { return longitud; }
            set { SetValue(ref longitud, value); }
        }

        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }




        public DetallePedidoGeneralViewModel(PedidosGenerales pedidosGenerales)
        {
            this.PedidosGenerales = pedidosGenerales;
            LoadDetallepedidos();
        }

        public void LoadDetallepedidos()
        {
            Id = PedidosGenerales.Usuario.Id;
            IdP = PedidosGenerales.Id;
            Cedula = PedidosGenerales.Usuario.Cedula;
            Nombres = PedidosGenerales.Usuario.Nombres;
            Apellidos = PedidosGenerales.Usuario.Apellidos;

            Celular = PedidosGenerales.Usuario.Celular;
            Direccion = PedidosGenerales.Usuario.Direccion;
            Email = PedidosGenerales.Usuario.Email;
         


    }

    }
}
