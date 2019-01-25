

namespace ProyectoDistriGas.ViewModels
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using Views;

    public class SegPedDistriItenViewModel : Pedidos
    {

        #region Commands
        public ICommand FinalizarPedidoCommand
        {
            get
            {
                return new RelayCommand(FinalizarPedidoCo);
            }
        }

        private async void FinalizarPedidoCo()
        {

            MainViewModel.GetInstance().FienalizarPedido = new FinalizarpedidoViewModel(this);

            await Application.Current.MainPage.Navigation.PushAsync(new FinalizarPedidoPage());
        }
        #endregion
       
    }
}
