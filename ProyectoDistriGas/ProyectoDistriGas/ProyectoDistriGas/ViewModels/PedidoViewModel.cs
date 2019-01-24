

namespace ProyectoDistriGas.ViewModels
{
    using ProyectoDistriGas.Config;
    using ProyectoDistriGas.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class PedidoViewModel:BaseViewModel
    {


        #region Services
        private ApiService apiService;
        private ConfigService configService;
        #endregion

        #region Attributes
        private ObservableCollection<Pedidos> pedidoList;
        private bool isRefreshing;
        private string filter;
        public string estados;

        #endregion

        #region Properties
        public ObservableCollection<Pedidos> PedidoList
        {
            get { return this.pedidoList; }
            set { SetValue(ref this.pedidoList, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Estados
        {
            get { return this.estados; }
            set { SetValue(ref this.estados, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);

            }
        }
        #endregion

        #region Constructors


        public PedidoViewModel()
        {

            this.configService = new ConfigService();
            this.apiService = new ApiService();
            this.LoadPedidos();
        }
       

        #endregion

        #region Methods
        private async void LoadPedidos()
        {

            this.Estados = MainViewModel.GetInstance().Pedidos[0].Estado;
            this.PedidoList = new ObservableCollection<Pedidos>(MainViewModel.GetInstance().Pedidos);


            this.IsRefreshing = false;



        }

        private IEnumerable<CasaItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().Casas.Select(l => new CasaItemViewModel
            {
                Id = l.Id,
                Direccion = l.Direccion,
                Latitud = l.Latitud,
                Longitud = l.Longitud,
                Telefono = l.Telefono,
                UsuarioId = l.UsuarioId

            });
        }


        #endregion

        #region Methods


        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPedidos);
            }
        }




        #endregion
    }
}
