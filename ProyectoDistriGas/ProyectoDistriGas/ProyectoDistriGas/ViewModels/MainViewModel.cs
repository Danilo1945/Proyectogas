

namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;
    using Services;
    using Models;


    public class MainViewModel
    {
        #region Propiedades
        public List<Casa> Casas
        {
            get;
            set;
        }
        public List<Distribuidor> Distribuidores
        {
            get;
            set;
        }
        public List<CilindroGas> CilindroGas
        {
            get;
            set;
        }
        public List<ListPedidosDistribuidorItemViewModel> PedidosGenerales
        {
            get;
            set;
        }
       
        #endregion


        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }
        public VariableViewModel Variable
        {
            get;
            set;
        }
        public InicioViewModel Inicio
        {
            get;
            set;
        }
        public CasaViewModel Casa
        {
            get;
            set;
        }
        public NewCasaViewModel NewCasa
        {
            get;
            set;
        }
        public CilindroViewModel Cilindro
        {
            get;
            set;
        }
        public NewCilindroViewModel NewCilindro
        {
            get;
            set;
        }
        
  
        public Sesion Sesion
        {
            get;
            set;
        }
        public DetalleClilindroViewModel DetalleCilindro
        {
            get;
            set;
        }
        public DistribuidorViewModel Distribuidor
        {
            get;
            set;
        }
        public ListPedidosDistribuidorViewModel ListPedidosDistribuidor
        {
            get;
            set;
        }
        
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
         
            this.Inicio= new InicioViewModel();
            this.Sesion = new Sesion();

        }
        #endregion
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance==null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion



    }
}
