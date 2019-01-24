

namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectoDistriGas.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;
    using Models;
    using Config;

    public class CasaViewModel:BaseViewModel
    {
        
        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion

        #region Attributes
        private ObservableCollection<CasaItemViewModel> casa;
        private bool isRefreshing;
        private string filter;
        private List<UsuarioObjet> listUsuarios;
        private ObservableCollection<Pedidos> pedidoList;
     
        #endregion

        #region Properties
        public ObservableCollection<CasaItemViewModel> Casa
        {
            get { return this.casa; }
            set { SetValue(ref this.casa, value); }
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

        public CasaViewModel()
        {
          

            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.LoadCasas();
           

        }
       
        #endregion

        #region Methods
        private async void LoadCasas()
        {
            
          
            await Application.Current.MainPage.DisplayAlert(
                     "mensaje",
                     MainViewModel.GetInstance().Sesion.GetId().ToString(),
                     "Aceptar");



            this.IsRefreshing = true;
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();
            string Controller = "/usuario/view/"+ MainViewModel.GetInstance().Sesion.GetId().ToString() + ".json";

             var response = await this.apiService.GetList<UsuarioObjet>(
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
          this.listUsuarios = (List<UsuarioObjet>)response.Result;
            MainViewModel.GetInstance().Casas = new List<Casa>();
            MainViewModel.GetInstance().Pedidos = new List<Pedidos>();

            if (this.listUsuarios[0].Usuario.Casa.Count >0)
            {
                int contador = 0;
                for (int i = 0; i < this.listUsuarios[0].Usuario.Casa.Count; i++)
                {
                    foreach (var item in listUsuarios)
                    {
                        MainViewModel.GetInstance().Casas.Add(new Casa()
                        {
                            Id = item.Usuario.Casa[contador].Id,
                            Direccion = item.Usuario.Casa[contador].Direccion,
                            Latitud = item.Usuario.Casa[contador].Latitud,
                            Longitud = item.Usuario.Casa[contador].Longitud,
                            Telefono = item.Usuario.Casa[contador].Telefono,
                            UsuarioId = item.Usuario.Casa[contador].UsuarioId

                        });


                    }
                    contador = contador + 1;
                }


                int contador2 = 0;
                for (int i = 0; i < this.listUsuarios[0].Usuario.Pedidos.Count; i++)
                {
                    foreach (var item2 in listUsuarios)
                    {
                        string estado = "";
                        if (item2.Usuario.Pedidos[contador2].Estado == "False")
                        {
                            estado = "Pendiente";
                        }
                        else
                        {
                            estado = "Atendido";
                        }


                        MainViewModel.GetInstance().Pedidos.Add(new Pedidos
                        {
                            Id = item2.Usuario.Pedidos[contador2].Id,
                            Fecha = item2.Usuario.Pedidos[contador2].Fecha,
                            Hora = item2.Usuario.Pedidos[contador2].Hora,
                            Estado = estado,
                            CalificacionUsuario = item2.Usuario.Pedidos[contador2].CalificacionUsuario,
                            CalificacionDistribuidor = item2.Usuario.Pedidos[contador2].CalificacionDistribuidor,
                            UsuarioId = item2.Usuario.Pedidos[contador2].UsuarioId,
                            DistribuidorId = item2.Usuario.Pedidos[contador2].DistribuidorId

                        });



                    }
                    contador2 = contador2 + 1;
                }
                this.Casa = new ObservableCollection<CasaItemViewModel>(this.ToLandItemViewModel());
                this.PedidoList = new ObservableCollection<Pedidos>(MainViewModel.GetInstance().Pedidos);

                this.IsRefreshing = false;
                MainViewModel.GetInstance().Pedido = new PedidoViewModel(); //instancio pedidos


            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Aun no tienes registrado una casa",
                    "Aceptar");
                this.IsRefreshing = false;
            }

        

        }

        private IEnumerable<CasaItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().Casas.Select(l => new CasaItemViewModel {
                Id = l.Id,
                Direccion=l.Direccion,
                Latitud=l.Latitud,
                Longitud=l.Longitud,
                Telefono=l.Telefono,
                UsuarioId=l.UsuarioId
             
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
                return new RelayCommand(LoadCasas);
            }
        }

        


        #endregion
    }
}
