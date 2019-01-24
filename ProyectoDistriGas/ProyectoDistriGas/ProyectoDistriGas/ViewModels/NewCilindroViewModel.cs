
namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectoDistriGas.Config;
    using ProyectoDistriGas.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Models;
    using Xamarin.Forms;

    public class NewCilindroViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion
        #region Atributos
        string color;
        string detalle;
        string direccionIP;
        private bool isRefreshing;

        #endregion
        #region Propiedades
        public string Color
        {
            get { return color; }
            set
            {
                SetValue(ref color, value);
            }
        }
        public string Detalle
        {
            get { return detalle; }
            set { SetValue(ref detalle, value); }
        }
        public string DireccionIP
        {
            get { return direccionIP; }
            set { SetValue(ref direccionIP, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
        #region Constructores
        public NewCilindroViewModel()
        {
            this.configService = new ConfigService();
            this.apiService = new ApiService();
        }
        
        #endregion

        #region Comandos
        public ICommand GuardarCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(Guardar);
            }
            set
            {


            }

        }
      

        private async void Guardar()
        {


            string colo = this.Color;
            string detall = this.Detalle;
            string direccionI = this.direccionIP;
            int CasaI = MainViewModel.GetInstance().CasaSelected;


           

            CilindroGas cilindroGLP = new CilindroGas();
            cilindroGLP = new CilindroGas
            {
                Color=colo,
                Detalle=detall,
                Direccion_Ip=direccionI,
                Casa_Id=CasaI

            };



            string urlBase = configService.GetURLBase();
            string Serviceprefix = configService.GetServiceprefix();

            string Controller = "/cilindro-gas/add.json";



            var resultadoAdd = await this.apiService.Post<CilindroGas>(urlBase, Serviceprefix, Controller, cilindroGLP);
            await Application.Current.MainPage.DisplayAlert(
                       "Mensaje",
                      resultadoAdd.Message,
                       "Aceptar");
            this.Color = string.Empty;
            this.Detalle = string.Empty;
            this.DireccionIP = string.Empty;

           

        }
        #endregion
    }
}
