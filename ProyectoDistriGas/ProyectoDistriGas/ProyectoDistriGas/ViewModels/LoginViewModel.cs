

namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    using Xamarin.Forms;
    using Views;
    using ViewModels;
    using Services;
    using Config;
    using System.Collections.Generic;
    using Models;

    public class LoginViewModel: BaseViewModel
    {

        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion

        #region Atributos

        //la accion o capacidad de retorno que tiene cada elemento
        //sirve para refrescar en las vistas los cambios efectuados por codigo 
        //siempre van con minisculas
        private string password;
        private bool isRunning;
        private bool isEnable;
        private List<Usuarios> usuarioLista;
        private List<Distribuidores> distribuidorLista;



        #endregion


        #region propeties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                // para poder refrescar los valores de las vistas 
                // esta eredando de baseviewmodel
                SetValue(ref password, value);
              
            }
        }
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                SetValue(ref isRunning, value);

            }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public int TipoUsuario;
        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                SetValue(ref isEnable, value);

            }
        }
        #endregion

        #region constructores
        public LoginViewModel( int tipoUsuario)
        {
            this.TipoUsuario = tipoUsuario;
            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnable = true;
            this.Email = "liliana.tapia1@utc.edu.ec";
            this.Password = "0503950131";
           
        }

      

        #endregion
        #region comandos
        public ICommand LoginCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(login);
            }
            set {


            }

        }
      
       

        private async void login()
        {
            this.IsRunning = true;
            if (string.IsNullOrWhiteSpace(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor llena el campo del  Email",
                    "Aceptar"
                    );
            }
            if (string.IsNullOrWhiteSpace(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Por favor llena el campo de la contraseña",
                    "Aceptar"
                    );
            }



            if (this.TipoUsuario == 1)
            { 
                string urlBase = configService.GetURLBase();
                string Serviceprefix = configService.GetServiceprefix();
                string Controller = "/usuario/index.json";
                var response = await this.apiService.GetList<Usuarios>(
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
                this.usuarioLista = (List<Usuarios>)response.Result;
                if (!VerificaSesionUsuario())
                {
                    this.Password = string.Empty;
                }
                else
                {
                    this.IsRunning = true;
                    this.IsEnable = true;
                    MainViewModel.GetInstance().Casa = new CasaViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new CasaTabbedPage());

                }

            }
            if (this.TipoUsuario == 2)
            {
                string urlBase = configService.GetURLBase();
                string Serviceprefix = configService.GetServiceprefix();
                string Controller = "/distribuidor/index.json";
                var response = await this.apiService.GetList<Distribuidores>(
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
                this.distribuidorLista = (List<Distribuidores>)response.Result;
                if (!VerificaSesionDistribuidor())
                {
                    this.Password = string.Empty;
                }
                else
                {
                    this.IsRunning = true;
                    this.IsEnable = true;
                    MainViewModel.GetInstance().ListPedidosDistribuidor = new ListPedidosDistribuidorViewModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new ListPedidosDistribuidorPage());

                }

            }




            #endregion
           
        }
        #region Funciones

        public bool  VerificaSesionUsuario()
        {
            var cont1 = 0;
            var correo = "";
            var password = "";
            long id=0;
            var estado = false;
            var res = false;
            for (int i = 0; i < this.usuarioLista.Count + 1; i++)
            {
                foreach (var d1 in this.usuarioLista)
                {
                    if (this.Email == d1.Usuario[cont1].Email && this.Password == d1.Usuario[cont1].Password)
                    {
                        correo = d1.Usuario[cont1].Email;
                        password = d1.Usuario[cont1].Password;
                        res = true;
                        estado = d1.Usuario[cont1].Enable;
                        id = d1.Usuario[cont1].Id;

                    }
                }
                cont1 = cont1 = 1; ;

            }

            if(res==true && estado == true)
            {
                MainViewModel.GetInstance().Sesion = new Sesion(id, estado, correo, password);
            }


            return res;
        }
        public bool VerificaSesionDistribuidor()
        {
            var cont1 = 0;
            var correo = "";
            var password = "";
            long id = 0;
            var estado = false;
            var res = false;
            for (int i = 0; i < this.distribuidorLista.Count + 1; i++)
            {
                foreach (var d1 in this.distribuidorLista)
                {
                    if (this.Email == d1.Distribuidor[cont1].Email && this.Password == d1.Distribuidor[cont1].Password)
                    {
                        correo = d1.Distribuidor[cont1].Email;
                        password = d1.Distribuidor[cont1].Password;
                        res = true;
                        estado = d1.Distribuidor[cont1].Enable;
                        id = d1.Distribuidor[cont1].Id;

                    }
                }
                cont1 = cont1 = 1; ;

            }

            if (res == true && estado == true)
            {
                MainViewModel.GetInstance().Sesion = new Sesion(id, estado, correo, password);
            }


            return res;
        }
        #endregion
    }
}

