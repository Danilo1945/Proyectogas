
namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class InicioViewModel:BaseViewModel
    {

        #region atributos
        private bool isEnable;
        #endregion

        #region propiedadades
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
        public InicioViewModel()
        {
            this.isEnable = true;

        }

        #endregion

        #region comandos
        public ICommand UsuarioCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(Usuario);
            }


        }
        public ICommand DistribuidorCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(Distribuidor);
            }


        }
        

        private async void Usuario()
        {
           
            MainViewModel.GetInstance().Login = new LoginViewModel(1);
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        private async void Distribuidor()
        {

            MainViewModel.GetInstance().Login = new LoginViewModel(2);
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        #endregion





    }







}
