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
                StringBuilder covid = new StringBuilder();

                covid.AppendLine("");
                covid.AppendLine("");
                covid.AppendLine("* Limpe suas mãos frequentemente. Use sabão e água, ou esfregue as mãos à base de álcool.");
                covid.AppendLine("");
                covid.AppendLine("* Mantenha uma distância segura de quem estiver tossindo ou espirrando.");
                covid.AppendLine("");
                covid.AppendLine("* Não toque nos olhos, nariz ou boca.");
                covid.AppendLine("");
                covid.AppendLine("* Cubra o nariz e a boca com o cotovelo dobrado ou um lenço de papel quando tossir ou espirrar.");
                covid.AppendLine("");
                covid.AppendLine("* Fique em casa se não se sentir bem.");
                covid.AppendLine("");
                covid.AppendLine("* Se você tiver febre, tosse e dificuldade em respirar, procure atendimento médico. Ligue com antecedência.");
                covid.AppendLine("");
                covid.AppendLine("* Siga as instruções da sua autoridade sanitária local.");

                App.Current.MainPage.DisplayAlert("Para impedir a propagação do COVID-19:", covid.ToString(), "OK");
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