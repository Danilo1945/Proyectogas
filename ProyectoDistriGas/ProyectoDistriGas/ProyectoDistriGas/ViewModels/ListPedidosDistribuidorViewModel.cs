
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
        private ObservableCollection<ListPedidosDistribuidorItemViewModel> pedidosGenerales;
        private bool isRefreshing;
        private string filter;
        private List<PedidosGeneralesObjet> listaPedidos;
        #endregion
        #region Properties
        public ObservableCollection<ListPedidosDistribuidorItemViewModel> PedidosGenerales
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


            MainViewModel.GetInstance().PedidosGenerales = new List<ListPedidosDistribuidorItemViewModel>();
            
            int contador = 0;
            for (int i = 0; i < this.listaPedidos.Count ; i++)
            {
                foreach (var item in listaPedidos)
                {
                    MainViewModel.GetInstance().PedidosGenerales.Add(new ListPedidosDistribuidorItemViewModel()
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


           this.PedidosGenerales = new ObservableCollection<ListPedidosDistribuidorItemViewModel>(this.ToListGeneralItemViewModel());

            await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    PedidosGenerales[0].Id.ToString(),
                    "Aceptar");
            this.IsRefreshing = false;



        }

        private IEnumerable<ListPedidosDistribuidorItemViewModel> ToListGeneralItemViewModel()
        {
            return MainViewModel.GetInstance().PedidosGenerales.Select(l => new ListPedidosDistribuidorItemViewModel
            {

                Id = l.Id,
                Fecha = l.Fecha,
                Hora = l.Hora,
                Estado = l.Estado,
                UsuarioId = l.UsuarioId,
                Usuario = l.Usuario
              
            });
        }


        #endregion


    }
}
