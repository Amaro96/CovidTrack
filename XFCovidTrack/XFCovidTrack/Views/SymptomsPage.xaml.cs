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
    public partial class SymptomsPage : ContentPage
    {
        public SymptomsPage()
        {
            InitializeComponent();

            var symptom = new List<Symptoms>()
            {

                new Symptoms { typeCase = "febre", typeCaseText = "Febre Alta" },
                new Symptoms { typeCase = "toss", typeCaseText = "Tosse" },
                new Symptoms { typeCase = "dorCabeca", typeCaseText = "Dor de Cabeça" },
                new Symptoms { typeCase = "faltaar", typeCaseText = "Falta de ar" },
            };
            listOfSymptoms.ItemsSource = symptom;
        }
    }

    public class Symptoms
    {
        public string typeCase { get; set; }
        public string typeCaseText { get; set; }
    }
}