
namespace ProyectoDistriGas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System;
    using Views;

    public class DetalleClilindroViewModel:BaseViewModel
    {


        #region Atributos
        private int id;
        private string color;
        private  string detalle;
        private string direccion_Ip;
        private int casa_Id;
        #endregion

        #region Propiedades
        public CilindroGas CilindroGas
        {
            get;
            set;
        }
        public int Id
        {
            get { return id;}
            set{SetValue(ref id, value);}
        }

        public string Color
        {
            get { return color; }
            set { SetValue(ref color, value); }
        }

        public string Detalle
        {
            get { return detalle; }
            set { SetValue(ref detalle, value); }
        }
        
        public string Direccion_Ip
        {
            get { return direccion_Ip; }
            set { SetValue(ref direccion_Ip, value); }
        }

        public int Casa_Id
        {
            get { return casa_Id; }
            set { SetValue(ref casa_Id, value); }
        }



        #endregion
        private CilindroItemViewModel cilindroItemViewModel;

        #region Constructores
        public DetalleClilindroViewModel(CilindroGas cilindroGas)
        {
            this.CilindroGas = cilindroGas;
            LoadCilindro();
            Direccion_Ip = CilindroGas. Direccion_Ip;
           Id=CilindroGas.Id;
           Detalle= CilindroGas.Detalle;
           Casa_Id= (int)CilindroGas.Casa_Id;
           Color = CilindroGas.Color;
        }
        #endregion

        #region Metodos
        public async void LoadCilindro()
        {
            await Application.Current.MainPage.DisplayAlert(
                    "mensaje",
                     CilindroGas.Color,
                    "Aceptar"
                    );
        }
        #endregion
        #region Comandos

        public ICommand SensorCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(SensorC);
            }
            set
            {


            }

        }

        private async void SensorC()
        {
            MainViewModel.GetInstance().Variable = new VariableViewModel(this.CilindroGas);
            await Application.Current.MainPage.Navigation.PushAsync(new VariablePage());
        }

        #endregion

    }
}
