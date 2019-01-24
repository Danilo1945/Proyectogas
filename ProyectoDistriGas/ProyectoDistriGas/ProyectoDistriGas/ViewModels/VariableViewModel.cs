
namespace ProyectoDistriGas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Config;

    public class VariableViewModel: BaseViewModel
    {
        #region Services
        private ApiService apiService;
       
        private ConfigService configService;
        #endregion


        #region Atributos
        private ObservableCollection<Sensor> sensor;
      
  
        private string valor;
        private bool isRunning;
        private bool isEnable;
        private string direccion_IP;

        #endregion
        #region propiedades
        public CilindroGas CilindroGas
        {
            get;
            set;
        }


        public ObservableCollection<Sensor> Sensor
        {
            get { return this.sensor; }
            set { SetValue(ref this.sensor, value); }
         }

        
        public string Valor
        {
            get { return this.valor; }
            set { SetValue(ref this.valor, value); }

        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
       





        #endregion

        #region constructores

        public VariableViewModel(CilindroGas cilindroGas)
        {
            this.configService = new ConfigService();
           
            this.CilindroGas = cilindroGas;
            this.apiService = new ApiService();
            this.LoadSensor();
            this.Valor = string.Empty;
            IsRunning = true;
            


        }

        #endregion

        #region metodos


        private  async void LoadSensor()
        {
           
            await Application.Current.MainPage.DisplayAlert("mensaje", CilindroGas.Direccion_Ip, "Aceptar");
            IsEnable = false;
            IsRunning = true;
         
            var response = await this.apiService.GetListURL<Sensor>(
                "http://"+CilindroGas.Direccion_Ip+"/");


            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list=(Sensor) response.Result;
            if (response.Result== null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            int porcentaje = list.Variable.Porcentaje;

            await Application.Current.MainPage.DisplayAlert("Ecaner Completo", porcentaje.ToString(), "Aceptar");
            this.Valor = "GLP= " + porcentaje.ToString() + " %";
            
            //int vaGLP = 4;
           // this.Valor ="GLP= " + vaGLP + " %";
            IsRunning = false;
            IsEnable = true;

            CompruebaGLP(porcentaje);

        }


        #endregion

        #region Comandos
        public ICommand RefrescarCommand
        {
            get
            {
                // recibe el evento y lo transfiere al metodo login
                return new RelayCommand(Refrescar);
            }
            set
            {


            }

        }

        private void Refrescar()
        {
            LoadSensor();


        }


        #endregion
        #region Funciones
        public async void CompruebaGLP(int PorcentajeGLP)
        {


            DateTime fechaHoy = DateTime.Now;


            string fecha = fechaHoy.Year.ToString() + "-" + fechaHoy.Month.ToString() + "-" + fechaHoy.Day.ToString();

            string hora = fechaHoy.Hour.ToString() + ":" + fechaHoy.Minute.ToString() + ":" + fechaHoy.Second.ToString();
            bool estado = false;
            int usuarioid = (int)MainViewModel.GetInstance().Sesion.Id;
            if (PorcentajeGLP <= 5)
            {
                PedidosGenerales pedidoGeneral = new PedidosGenerales();


                /*  await Application.Current.MainPage.DisplayAlert(
                             "mensaje",
                              usuarioid,
                             "Aceptar"
                             );*/

                pedidoGeneral = new PedidosGenerales
                {
                    Fecha = fechaHoy,
                    Hora = fechaHoy,
                    Estado = estado,
                    UsuarioId= usuarioid
                };



                string urlBase = configService.GetURLBase();
                string Serviceprefix = configService.GetServiceprefix();

                string Controller = "/pedidos-generales/add.json";

               

                var resultadoAdd = await this.apiService.Post<PedidosGenerales>(urlBase, Serviceprefix, Controller, pedidoGeneral);
                await Application.Current.MainPage.DisplayAlert(
                           "Mensaje",
                          resultadoAdd.Message,
                           "Aceptar");












            }
        }
        #endregion

    }
}
