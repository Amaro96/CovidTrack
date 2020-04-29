using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Models;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<CovidData> listItems = new List<CovidData>()
            {
                new CovidData{title ="CORONAVIRUS", subTitle= "COVID-19", information = "COVID-19 is an infectious disease caused",subInformation= " by a virus.",  img="CovidYellow", BackGroundColor = "#8F2FEE"},
                new CovidData{title ="MRSA", subTitle= "VIRUS",information = "COVID-19 is an infectious disease caused",subInformation= " a new virus.",img="covidAzul", BackGroundColor = "#2D1048"},


            };
      
            listInformation.ItemsSource = listItems;
            

        }

  
    }
}