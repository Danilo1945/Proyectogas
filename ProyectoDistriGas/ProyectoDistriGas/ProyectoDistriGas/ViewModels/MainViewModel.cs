

namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;  


    public class MainViewModel
    {

       

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

        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
         
            this.Inicio= new InicioViewModel();
           

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
