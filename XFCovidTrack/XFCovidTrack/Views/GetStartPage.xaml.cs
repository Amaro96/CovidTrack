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
    public partial class GetStartPage : ContentPage
    {
        TesteViewModel _TesteViewModel;
        public GetStartPage()
        {
            InitializeComponent();
            BindingContext = _TesteViewModel =new  TesteViewModel();
            switchBtn.Toggled += (sender, e) =>
            {

                _TesteViewModel.ChangeAppThemeCommand.Execute(null);
            };

        }

        private void switchBtn_Toggled(object sender, ToggledEventArgs e)
        {
            
        }

        private async void btnGetMain_Clicked(object sender, EventArgs e)
        {
          await  Navigation.PushAsync(new MainPage());
        }
    }
}