

namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using Views;

   public  class CasaItemViewModel :Casa
    {
        #region Commands
        public ICommand SelectCasaCommand
        {
            get
            {
                return new RelayCommand(SelectCasa);
            }
        }

        private async void SelectCasa()
        {
            MainViewModel.GetInstance().Cilindro = new CilindroViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new CilindrosPage());
        }
        #endregion

    }
}
