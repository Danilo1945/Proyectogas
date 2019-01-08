
namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Models;
    using Services;
    using Config;
    using System.Collections.ObjectModel;

    public  class CilindroViewModel: BaseViewModel   
    {

        #region Servicios
        private ApiService apiService;
        private ConfigService configService;
        #endregion
        #region Atributos
        
        private ObservableCollection<CilindroGas> cilindro;
        private List<CasaObjet> Casa;
        #endregion
        #region Propiedades
        public ObservableCollection<CilindroGas> Cilindro
        {
            get { return this.cilindro; }
            set { SetValue(ref this.cilindro, value); }
        }
        public Casa Casas
        {
            get;
            set;
        }


        #endregion
        #region Propiedades

        #endregion
        #region Costructores
        public  CilindroViewModel(Casa casa)
        {
            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.Casas = casa;
            loadCilindro();
        }
        #endregion
        #region Metodos
        public async void loadCilindro()
        {
           
            
            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();
            string Controller = "/casa/view/" + Casas.Id.ToString() + ".json";

            var response = await this.apiService.GetList<CasaObjet>(
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
            this.Casa = (List<CasaObjet>)response.Result;
            List<CilindroGas> listaCindros = new List<CilindroGas>();

            int contador = 0;


            for (int i = 0; i < this.Casa.Count + 1; i++)
            {
                foreach (var item in this.Casa)
                {
                    listaCindros.Add(new CilindroGas() {
                    Id= item.Casa.CilindroGas[contador].Id

                    });
                   

                }
                contador = contador + 1;
            }







            await Application.Current.MainPage.DisplayAlert(
                     "mensaje",
                    Casas.Direccion.ToString(),
                     "Aceptar");
        }
        #endregion
        #region Comandos

        public ICommand ConectarCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(Conectar);
            }
            set {


            }

        }

        private async void Conectar()
        {
          
            MainViewModel.GetInstance().Variable = new VariableViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new VariablePage());
        }
        #endregion




    }
}
