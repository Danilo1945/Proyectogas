

namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class CasaViewModel
    {
        



        #region Constructores
        public CasaViewModel()
        {

            MainViewModel.GetInstance().Cilindro = new CilindroViewModel();
            
        }
        #endregion
        #region Comandos
        public ICommand NewCasaCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(NewCasa);
            }
            set
            {


            }

        }

        private async void NewCasa()
        {
            MainViewModel.GetInstance().NewCasa = new NewCasaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new NewCasaPage());
        }
        #endregion


    }
}
