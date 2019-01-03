

namespace ProyectoDistriGas.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CilindrosPage : ContentPage
    {
        public CilindrosPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            MainViewModel.GetInstance().NewCilindro = new NewCilindroViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new NewCilindroPage());
        }
    }
}