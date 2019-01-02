
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

    public class VariableViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<Sensor> sensor;
        #endregion
        #region propiedades
        public ObservableCollection<Sensor> Sensor
        {
            get { return this.sensor; }
            set { SetValue(ref this.sensor, value); }
         }

        #endregion

        #region constructores

        public VariableViewModel()
        {
            this.apiService = new ApiService();
            this.LoadSensor();
        }

        #endregion

        #region metodos


        private  async void LoadSensor()
        {
            var response = await this.apiService.GetListURL<Sensor>(
                "http://192.168.1.4/");


            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list=(List<Sensor>) response.Result;
            this.Sensor = new ObservableCollection<Models.Sensor>(list);
        }


        #endregion
    }
}
