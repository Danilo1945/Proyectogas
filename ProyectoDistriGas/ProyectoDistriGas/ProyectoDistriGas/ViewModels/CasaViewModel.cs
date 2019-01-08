

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
        #endregion

        #region Properties
        public ObservableCollection<CasaItemViewModel> Casa
        {
            get { return this.casa; }
            set { SetValue(ref this.casa, value); }
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

            int contador = 0;
           
           
            for ( int i=0; i< this.listUsuarios.Count+1;i++)
            {
                foreach (var item in listUsuarios)
                {
                    MainViewModel.GetInstance().Casas.Add(new Casa() {
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
            
           


            this.Casa = new ObservableCollection<CasaItemViewModel>(this.ToLandItemViewModel());
            
            this.IsRefreshing = false;



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
