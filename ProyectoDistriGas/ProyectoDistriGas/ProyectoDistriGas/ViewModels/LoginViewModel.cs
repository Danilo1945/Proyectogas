

namespace ProyectoDistriGas.ViewModels
{
  
    using System.Windows.Input;
    public class LoginViewModel
    {
        #region propeties
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRunning { get; set; }
        public bool IsRemembered { get; set; }
        #endregion


        #region constructores
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;
        }
       
        #endregion
        #region comandos
        public ICommand LoginCommand
        {
            get;
            set;
        }

        #endregion



    }
}
