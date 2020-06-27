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
    public partial class PreventionPage : ContentPage
    {
        public PreventionPage()
        {
            InitializeComponent();

            var prev = new List<Prevention>()
            {
                new Prevention {startImg= "usemask", endImg = "wash", startText= "Use mascara", endText ="Lave as mãos"},
                new Prevention {startImg= "usepapier", endImg = "donttouch", startText= "Não toque á\n boca e ao nariz".Replace("\n", System.Environment.NewLine), endText ="Evite tocar\n em animais".Replace("\n", System.Environment.NewLine)}
            };

            listOfPrevention.ItemsSource = prev;
        }
    } 

    public class Prevention
    {
        public string startImg { get; set; }
        public string endImg { get; set; }
        public string startText { get; set; }
        public string endText { get; set; }
    }
}