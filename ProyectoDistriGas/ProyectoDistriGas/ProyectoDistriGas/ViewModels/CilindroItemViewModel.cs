

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

    public class CilindroItemViewModel:CilindroGas
    {

        
        #region Commands
        public ICommand SelectCilindroCommand
        {
            get
            {
                return new RelayCommand(SelectCilindro);
            }
        }

        private async void SelectCilindro()
        {
            MainViewModel.GetInstance().DetalleCilindro = new DetalleClilindroViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new DetalleCilindroPage());
        }
        #endregion
        
    }
}
