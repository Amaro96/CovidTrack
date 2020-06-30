
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Interfaces;
using XFCovidTrack.Models;
using XFCovidTrack.Services;
using XFCovidTrack.ViewModels;

namespace XFCovidTrack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultCases : ContentPage
    {
        ResultCasesViewModel resultCasesViewModel;
        public ResultCases()
        {
            InitializeComponent();
            BindingContext = resultCasesViewModel = new ResultCasesViewModel(new DataService());
            
         //   UserDialogs.Instance.HideLoading();
        }

        protected override async void OnAppearing()
        {
            await resultCasesViewModel.GetAll();
        }

        private void teste_Refreshing(object sender, EventArgs e)
        {
            if (teste.IsRefreshing == true)
            {
                searchEntry.IsVisible = true;

                teste.IsRefreshing = false;
                

            }
        }

        private void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                listOfCountry.ItemsSource = resultCasesViewModel.countries;
            }
            else
            {
                listOfCountry.ItemsSource = resultCasesViewModel.countries.Where(value =>
                value.country.IndexOf(e.NewTextValue, StringComparison.OrdinalIgnoreCase) >= 0 || value.continent.IndexOf(e.NewTextValue, StringComparison.OrdinalIgnoreCase) >= 0); 
                int _totalCasos = 0;

                if (e.NewTextValue == "Africa")
                {

                    foreach (var  x in resultCasesViewModel.countries)
                {
                   
                    if(x.continent == "Africa")
                    {
                        _totalCasos += x.cases;

                        lblcasos.Text = "total africa " + _totalCasos;
                    }
                }

                    }

            }
        }
    }


}