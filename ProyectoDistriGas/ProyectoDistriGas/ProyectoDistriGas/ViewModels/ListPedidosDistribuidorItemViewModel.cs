
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

    public class ListPedidosDistribuidorItemViewModel:PedidosGenerales
    {
        #region Commands
        public ICommand SelectPedidoGeneralCommand
        {
            get
            {
                return new RelayCommand(SelectPedidoGeneral);
            }
        }

        private async void SelectPedidoGeneral()
        {
            MainViewModel.GetInstance().DetallePedidoGeneral = new DetallePedidoGeneralViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new DetallePedidogeneralPage());
        }
        #endregion

    }
}
