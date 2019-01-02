
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

    public class CilindroViewModel: BaseViewModel
    {
        #region Servicios

        #endregion
        #region Atributos

        #endregion
        #region Propiedades

        #endregion
        #region Propiedades

        #endregion
        #region Costructores
        public CilindroViewModel()
        {

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
