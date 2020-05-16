using Rg.Plugins.Popup.Pages;
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
    public partial class MyLocationPage : PopupPage
    {
        MyLocationViewModel myLocationViewModel;
        public MyLocationPage()
        {
            InitializeComponent();
            BindingContext = myLocationViewModel = new MyLocationViewModel(new DataService());
            myLocationViewModel.GetAll();
            CloseWhenBackgroundIsClicked = true;
        }

        protected override async void OnAppearing()
        {
            await myLocationViewModel.GetAll();
        }

        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }
    }
}