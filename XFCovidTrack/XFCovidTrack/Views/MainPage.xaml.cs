using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Models;
using XFCovidTrack.ViewModels;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
            List<CovidData> listItems = new List<CovidData>()
            {
                new CovidData{title ="CORONAVIRUS", subTitle= "COVID-19", information = "COVID-19 is an infectious disease caused",subInformation= " by a virus.",  img="CovidYellow", BackGroundColor = "#8F2FEE"},
                new CovidData{title ="MRSA", subTitle= "VIRUS",information = "COVID-19 is an infectious disease caused",subInformation= " a new virus.",img="covidAzul", BackGroundColor = "#2D1048"},


            };

            listInformation.ItemsSource = listItems;


        }
        protected override async void OnAppearing()
        {
            viewModel.SubscribeChangeLanguage();
            await viewModel.GetAll();
        }

        protected override void OnDisappearing()
        {
            viewModel.OnDisappearing();
        }

    }

    public class CovidData
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public string information { get; set; }
        public string subInformation { get; set; }
        public string BackGroundColor { get; set; }
        public string img { get; set; }
    }
}