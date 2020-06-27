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
    public partial class AvoidVirus : ContentPage
    {
        public AvoidVirus()
        {
            InitializeComponent();

            List<avoid> avoid = new List<avoid>()
            {
                new avoid{Img = "tosse", Type= "Sintomas & Teste"},
                   new avoid{Img = "macara", Type= "Prevenção"},
                      new avoid{Img = "hosp", Type= "Postos de teste"},
            };

            listOfServicesAvoid.ItemsSource = avoid;
        }

        private void listOfServicesAvoid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (e.CurrentSelection.FirstOrDefault() as avoid).Type;

            if(type == "Sintomas & Teste")
            {
                Navigation.PushAsync(new SymptomsPage());
               
            } else if (type == "Prevenção")
            {
                Navigation.PushAsync(new PreventionPage());
            } else if(type == "Postos de teste")
            {
                Navigation.PushAsync(new HealthcarePage());
            }

            Console.WriteLine(type);
        }
    }
    public class avoid
    {
        public string Img { get; set; }
        public string Type { get; set; }
    }
}