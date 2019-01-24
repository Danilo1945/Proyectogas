

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

    public  class NewCasaViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion
        #region Atributos
        string direccion;
        string telefono;

        #endregion
        #region Propiedades
        public string Direccion
        {
            get { return direccion; }
            set
            {
                SetValue(ref direccion, value);
            }
        }
       public string Telefono
        {
            get { return telefono; }
            set { SetValue(ref telefono, value); }
        }
        #endregion
        #region Constructores
        public NewCasaViewModel()
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

        private  async void Guardar()
        {

            string direccio = this.Direccion;
            double latitu = 19.4861151;
            double longitu = -99.1400809;
            string telefon = this.Telefono;
            int UsuarioI = (int)MainViewModel.GetInstance().Sesion.Id;

            Casa casa = new Casa();
            casa = new Casa
            {
                Direccion = direccion,
                Latitud = latitu,
                Longitud=longitu,
                Telefono=telefon,
                UsuarioId= UsuarioI

            };
           


                string urlBase = configService.GetURLBase();
                string Serviceprefix = configService.GetServiceprefix();

                string Controller = "/casa/add.json";



                var resultadoAdd = await this.apiService.Post<Casa>(urlBase, Serviceprefix, Controller, casa);
                await Application.Current.MainPage.DisplayAlert(
                           "Mensaje",
                          resultadoAdd.Message,
                           "Aceptar");











            }
            #endregion
        }
}
