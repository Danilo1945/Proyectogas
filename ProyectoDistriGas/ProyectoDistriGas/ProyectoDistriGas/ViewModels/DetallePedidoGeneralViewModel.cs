
namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Config;
    using Xamarin.Forms;
    using Views;
    using ViewModels;

    public class DetallePedidoGeneralViewModel:BaseViewModel
    {


        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion
        
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


        #region Constructores

        public DetallePedidoGeneralViewModel(PedidosGenerales pedidosGenerales)
        {
            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.PedidosGenerales = pedidosGenerales;
            LoadDetallepedidos();
        }
        #endregion


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

       
        public ICommand AceptarPedidoCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(AceptarPedido);
            }
            set
            {


            }

        }

        private async void AceptarPedido()
        {

            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();

            string Controller = "/pedidos/add.json";

            Pedidos pedido = new Pedidos {
                Id = 0,
            
                Fecha=this.PedidosGenerales.Fecha,
                Hora=this.PedidosGenerales.Hora,
                Estado=this.PedidosGenerales.Estado.ToString(),
                CalificacionUsuario=false,
                CalificacionDistribuidor=false,
                UsuarioId=this.PedidosGenerales.UsuarioId,
                DistribuidorId= MainViewModel.GetInstance().Sesion.Id


            };

            var resultadoAdd = await this.apiService.Post<Pedidos>(urlBase, Serviceprefix, Controller, pedido);
            await Application.Current.MainPage.DisplayAlert(
                       "Mensaje",
                      resultadoAdd.Message,
                       "Aceptar");

            string ControllerDelete =  "/pedidos-generales/delete" ;
            EliminarResponse status = new EliminarResponse();
            var resultadoDelete = await this.apiService.Delete(urlBase, Serviceprefix, ControllerDelete, this.PedidosGenerales.Id.ToString());


            MainViewModel.GetInstance().DetallePedidoGeneral.MemberwiseClone();
            MainViewModel.GetInstance().ListPedidosDistribuidor = new ListPedidosDistribuidorViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new ListPedidosDistribuidorPage());

        }
       

    }
}
