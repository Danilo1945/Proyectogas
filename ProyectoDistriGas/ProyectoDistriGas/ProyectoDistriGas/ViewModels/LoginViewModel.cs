

namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {
        #region Atributos

        //la accion o capacidad de retorno que tiene cada elemento
        //sirve para refrescar en las vistas los cambios efectuados por codigo 
        //siempre van con minisculas
        private string password;
        private bool isRunning;
        private bool isEnable;
        


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
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;
            this.IsEnable = true;
            this.Email = "danilomoya19@ymail.com";
            this.Password = "12345";
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
           

             
            if (this.Email != "danilomoya19@ymail.com" || this.Password != "12345")
            {
                this.Password = string.Empty;
             
                
            }
            else
            {
                this.IsRunning = true;
                this.IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Mensaje",
                   "ok",
                   "Aceptar"
                   );
            }

            #endregion



        }
    }
}

