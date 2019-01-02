﻿
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

    public class VariableViewModel: BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Atributos
        private ObservableCollection<Sensor> sensor;
      
  
        private string valor;
        private bool isRunning;

        #endregion
        #region propiedades
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




        #endregion

        #region constructores

        public VariableViewModel()
        {
            this.apiService = new ApiService();
            this.LoadSensor();
            this.Valor = string.Empty;
            IsRunning = true;


        }

        #endregion

        #region metodos


        private  async void LoadSensor()
        {
            IsRunning = true;
         
            var response = await this.apiService.GetListURL<Sensor>(
                "http://192.168.137.79/");


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

            await Application.Current.MainPage.DisplayAlert("Error", porcentaje.ToString(), "Aceptar");
            this.Valor = porcentaje.ToString();
            IsRunning = false; ;
        }


        #endregion

        #region Comandos



        #endregion

    }
}
