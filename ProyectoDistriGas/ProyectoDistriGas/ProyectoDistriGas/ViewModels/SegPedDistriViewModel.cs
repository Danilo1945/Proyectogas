using GalaSoft.MvvmLight.Command;
using ProyectoDistriGas.Config;
using ProyectoDistriGas.Models;
using ProyectoDistriGas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoDistriGas.ViewModels
{
   public class SegPedDistriViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion

        #region Attributes
        private ObservableCollection<SegPedDistriItenViewModel> pedidos;
        private bool isRefreshing;
        private string filter;
        private List<DistribuidorObjet> listDistribuidor;
        private ObservableCollection<Pedidos> pedidoList;
        string prueba;

        #endregion

        #region Properties
        public ObservableCollection<SegPedDistriItenViewModel> Pedidos
        {
            get { return this.pedidos; }
            set { SetValue(ref this.pedidos, value); }
        }
        public string Prueba
        {
            get { return this.prueba; }
            set { SetValue(ref this.prueba, value); }
        }
        public ObservableCollection<Pedidos> PedidoList
        {
            get { return this.pedidoList; }
            set { SetValue(ref this.pedidoList, value); }
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
        public SegPedDistriViewModel()
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
                   "Pedidos Pendientes Cargados"  ,//MainViewModel.GetInstance().Sesion.GetId().ToString(),
                     "Aceptar");
                   


            this.IsRefreshing = true;
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();
            string Controller = "/distribuidor/view/" + MainViewModel.GetInstance().Sesion.GetId().ToString() + ".json";

            var response = await this.apiService.GetList<DistribuidorObjet>(
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
            this.listDistribuidor = (List<DistribuidorObjet>)response.Result;
           
            MainViewModel.GetInstance().Pedidos = new List<Pedidos>();
           
            if (this.listDistribuidor[0].Distribuidor.Pedidos.Count > 0)
            {
                

                int contador2 = 0;
                for (int i = 0; i < this.listDistribuidor[0].Distribuidor.Pedidos.Count; i++)
                {
                    foreach (var item2 in listDistribuidor)
                    {
                        string estado = "";
                        if (item2.Distribuidor.Pedidos[contador2].Estado == "False")
                        {
                            estado = "Pendiente";
                        }
                        else
                        {
                            estado = "Atendido";
                        }


                        MainViewModel.GetInstance().Pedidos.Add(new Pedidos
                        {
                            Id = item2.Distribuidor.Pedidos[contador2].Id,
                            Fecha = item2.Distribuidor.Pedidos[contador2].Fecha,
                            Hora = item2.Distribuidor.Pedidos[contador2].Hora,
                            Estado = estado,
                            CalificacionUsuario = item2.Distribuidor.Pedidos[contador2].CalificacionUsuario,
                            CalificacionDistribuidor = item2.Distribuidor.Pedidos[contador2].CalificacionDistribuidor,
                            UsuarioId = item2.Distribuidor.Pedidos[contador2].UsuarioId,
                            DistribuidorId = item2.Distribuidor.Pedidos[contador2].DistribuidorId

                        });



                    }
                    contador2 = contador2 + 1;
                }
              
                this.Pedidos = new ObservableCollection<SegPedDistriItenViewModel>(this.ToPedidosItemViewModel());
             
                this.IsRefreshing = false;
              //  MainViewModel.GetInstance().Pedido = new PedidoViewModel(); //instancio pedidos
                

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Aun no tienes pedidos por entregar",
                    "Aceptar");
                this.IsRefreshing = false;
            }

            this.IsRefreshing = false;


        }

        private IEnumerable<SegPedDistriItenViewModel> ToPedidosItemViewModel()
        {
            return MainViewModel.GetInstance().Pedidos.Select(l => new SegPedDistriItenViewModel
            {
                Id = l.Id,
                Fecha = l.Fecha,
                Hora = l.Hora,
                Estado = l.Estado,
                CalificacionUsuario = l.CalificacionUsuario,
                CalificacionDistribuidor = l.CalificacionDistribuidor,
                UsuarioId = l.UsuarioId,
                DistribuidorId = l.DistribuidorId

            });
        }


        #endregion

        #region Methods


        #endregion

        #region Commands
      
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPedidos);
            }
        }

    


        #endregion
    }
}
