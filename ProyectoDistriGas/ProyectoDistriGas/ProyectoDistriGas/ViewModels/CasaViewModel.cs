using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDistriGas.ViewModels
{
   public class CasaViewModel
    {
        #region Constructores
        public CasaViewModel()
        {

            MainViewModel.GetInstance().Cilindro = new CilindroViewModel();
            
        }
        #endregion



    }
}
