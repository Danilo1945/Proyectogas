
namespace ProyectoDistriGas.ViewModels
{
    using ProyectoDistriGas.Config;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Xamarin.Forms;

    public class ListPedidosDistribuidorViewModel: BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion
        #region Attributes
        private ObservableCollection<PedidosGenerales> pedidosGenerales;
        private bool isRefreshing;
        private string filter;
        private List<PedidosGeneralesObjet> listaPedidos;
        #endregion
        #region Properties
        public ObservableCollection<PedidosGenerales> PedidosGenerales
        {
            get { return this.pedidosGenerales; }
            set { SetValue(ref this.pedidosGenerales, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);

            }
        }
        #endregion
        #region Constructors

        public ListPedidosDistribuidorViewModel()
        {
            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.LoadPedidos();

        }


        #endregion
        #region Methods
        private async void LoadPedidos() 
        {


            await Application.Current.MainPage.DisplayAlert(
                     "mensaje",
                     MainViewModel.GetInstance().Sesion.GetId().ToString(),
                     "Aceptar");

            this.IsRefreshing = true;
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();
            
            string Controller = "/PedidosGenerales/index.json";

            var response = await this.apiService.GetList<PedidosGeneralesObjet>(
               urlBase,
               Serviceprefix,
               Controller);

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            
         this.listaPedidos = (List<PedidosGeneralesObjet>)response.Result;


            MainViewModel.GetInstance().PedidosGenerales = new List<PedidosGenerales>();

            int contador = 0;
            for (int i = 0; i < this.listaPedidos.Count + 1; i++)
            {
                foreach (var item in listaPedidos)
                {
                    MainViewModel.GetInstance().PedidosGenerales.Add(new PedidosGenerales()
                    {
                        Id = item.PedidosGenerales[contador].Id,
                        Fecha=item.PedidosGenerales[contador].Fecha,
                        Hora = item.PedidosGenerales[contador].Hora,
                        Estado= item.PedidosGenerales[contador].Estado,
                        UsuarioId= item.PedidosGenerales[contador].UsuarioId,
                        Usuario= item.PedidosGenerales[contador].Usuario
               
                   });

                }
                contador = contador + 1;
            }


          //  this.PedidosGenerales = new ObservableCollection<PedidosGenerales>(MainViewModel.GetInstance().PedidosGenerales);

            this.IsRefreshing = false;



        }

        private IEnumerable<CasaItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().Casas.Select(l => new CasaItemViewModel
            {
                Id = l.Id,
                Direccion = l.Direccion,
                Latitud = l.Latitud,
                Longitud = l.Longitud,
                Telefono = l.Telefono,
                UsuarioId = l.UsuarioId

            });
        }


        #endregion


    }
}
