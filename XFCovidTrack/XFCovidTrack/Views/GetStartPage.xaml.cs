using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartPage : ContentPage
    {
        public GetStartPage()
        {
            InitializeComponent();
          
            switchBtn.Toggled += (sender, e) =>
            {
                if (switchBtn.IsToggled == true)
                {
                    //BackgroundImageSource = ImageSource.FromResource("WelcomeDark");
                    BackgroundColor = Color.FromHex("#412759");      
                    switchBtn.OnColor = Color.FromHex("#9943EF");
                    switchBtn.ThumbColor = Color.FromHex("#FFFFFF");
                }
                else
                {
                    BackgroundColor = Color.White;
                    switchBtn.OnColor = Color.FromHex("#FFFFFF");
                    switchBtn.ThumbColor = Color.FromHex("#9943EF");
                    //BackgroundImageSource = ImageSource.FromResource("WelcomeLight");
                } 
            };

        }

        private void switchBtn_Toggled(object sender, ToggledEventArgs e)
        {
            
        }
    }
}