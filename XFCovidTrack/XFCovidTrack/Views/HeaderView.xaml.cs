using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.ViewModels;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderView : ContentView
    {
        TesteViewModel _TesteViewModel;
        public HeaderView()
        {
            InitializeComponent();
            BindingContext = _TesteViewModel = new TesteViewModel();
            switchBt.Toggled += (sender, e) =>
            {

                _TesteViewModel.ChangeAppThemeCommand.Execute(null);
            };
        }

        private async void btnMyLocation_Clicked(object sender, EventArgs e)
        {
           await PopupNavigation.Instance.PushAsync(new MyLocationPage());
        }
    }
}