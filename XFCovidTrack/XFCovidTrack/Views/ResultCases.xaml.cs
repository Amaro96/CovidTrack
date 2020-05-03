using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovidTrack.Interfaces;
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
            BindingContext = resultCasesViewModel = new ResultCasesViewModel(new RestService()); 
            
        }

        protected override async void OnAppearing()
        {
           await resultCasesViewModel.GetAll();
        }

        protected override void OnDisappearing()
        {
          
        }

    }

  
}