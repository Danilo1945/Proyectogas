
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
    public partial class CasaPage : ContentPage
    {
        public CasaPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            MainViewModel.GetInstance().NewCasa = new NewCasaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new NewCasaPage());
        }
    }
}