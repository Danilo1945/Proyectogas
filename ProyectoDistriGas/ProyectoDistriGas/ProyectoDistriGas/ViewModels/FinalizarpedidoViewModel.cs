
namespace ProyectoDistriGas.ViewModels
{
    using ProyectoDistriGas.Config;
    using ProyectoDistriGas.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class FinalizarpedidoViewModel: BaseViewModel
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
        private List<UsuarioObjet> listUsuarios;
        #endregion
        #region propiedades
        public Pedidos Pedidos
        {
            get;
            set;
        }
        public Usuario Usuario
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
        #endregion

        #region Constructores

        public FinalizarpedidoViewModel(Pedidos pedidos)
        {

            this.configService = new ConfigService( );
            this.apiService = new ApiService();
            this.Pedidos = pedidos;
            LoadDetallepedidos();
        }
       
        #endregion

        #region Funciones
        public async void LoadDetallepedidos()
        {



          
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();
            string Controller = "/usuario/view/" + this.Pedidos.UsuarioId+ ".json";

            var response = await this.apiService.GetList<UsuarioObjet>(
               urlBase,
               Serviceprefix,
               Controller);

            if (!response.IsSuccess)
            {
                
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            this.listUsuarios = (List<UsuarioObjet>)response.Result;



            foreach( var item in listUsuarios)
            {

                this.Usuario = new Usuario
                {
                    Id=item.Usuario.Id,
                    Cedula=item.Usuario.Cedula,
                    Nombres = item.Usuario.Nombres,
                    Apellidos = item.Usuario.Apellidos,
                    Latitud=item.Usuario.Latitud,
                    Longitud=item.Usuario.Longitud,
                     Celular= item.Usuario.Celular,
                    Direccion = item.Usuario.Direccion,
                    Email = item.Usuario.Email,


                };

            } 


            
            Id = this.Usuario.Id;
            IdP = this.Pedidos.Id;
             Cedula = this.Usuario.Cedula;
            Nombres = this.Usuario.Nombres;
            Apellidos = this.Usuario.Apellidos;

            Celular = this.Usuario.Celular;
            Direccion = this.Usuario.Direccion;
            Email = this.Usuario.Email;

           

        }
        #endregion

        #region Comendos
        public ICommand FinalizarPedidoCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(FinalizarPedido);
            }
            set
            {


            }

        }

        private async void FinalizarPedido()
        {
            /*
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();

            string Controller = "/pedidos/add.json";

            Pedidos pedido = new Pedidos
            {
                Id = 0,

                Fecha = this.PedidosGenerales.Fecha,
                Hora = this.PedidosGenerales.Hora,
                Estado = this.PedidosGenerales.Estado.ToString(),
                CalificacionUsuario = false,
                CalificacionDistribuidor = false,
                UsuarioId = this.PedidosGenerales.UsuarioId,
                DistribuidorId = MainViewModel.GetInstance().Sesion.Id


            };

            var resultadoAdd = await this.apiService.Post<Pedidos>(urlBase, Serviceprefix, Controller, pedido);
            await Application.Current.MainPage.DisplayAlert(
                       "Mensaje",
                      resultadoAdd.Message,
                       "Aceptar");

            string ControllerDelete = "/pedidos-generales/delete";
            EliminarResponse status = new EliminarResponse();
            var resultadoDelete = await this.apiService.Delete(urlBase, Serviceprefix, ControllerDelete, this.PedidosGenerales.Id.ToString());


            MainViewModel.GetInstance().DetallePedidoGeneral.MemberwiseClone();
            MainViewModel.GetInstance().ListPedidosDistribuidor = new ListPedidosDistribuidorViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new ListPedidosDistribuidorPage());
*/
        }
        #endregion



    }
}
