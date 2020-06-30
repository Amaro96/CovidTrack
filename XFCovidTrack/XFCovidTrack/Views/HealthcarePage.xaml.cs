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
    public partial class HealthcarePage : ContentPage
    {
        public List<Person> Data { get; set; }
        public HealthcarePage()
        {
            InitializeComponent();

            Data = new List<Person>()
            {
                new Person { Name = "David", Height = 180 },
                new Person { Name = "Michael", Height = 170 },
                new Person { Name = "Steve", Height = 160 },
                new Person { Name = "Joel", Height = 182 }
            };

         
       
            BindingContext = new ChartMV();

          //  test.ItemsSource = Data;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public double Height { get; set; }
    }
}