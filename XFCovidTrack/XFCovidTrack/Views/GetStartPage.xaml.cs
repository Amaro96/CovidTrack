using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Services;
using XFCovidTrack.ViewModels;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartPage : ContentPage
    {
        TesteViewModel _TesteViewModel;
        MainPageViewModel viewModel;
        public GetStartPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel(new DataService());

        }

        protected override async void OnAppearing()
        {
            viewModel.SubscribeChangeLanguage();
            await viewModel.GetAll();
        }

        protected override void OnDisappearing()
        {
            viewModel.OnDisappearing();
        }

        private async void btnGetMain_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["Main"] = "activo";
           await  Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }
    }
}