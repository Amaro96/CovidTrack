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
    public partial class ResultCases : ContentPage
    {
        public ResultCases()
        {
            InitializeComponent();
            List<Test> aa = new List<Test>()
            {

                new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                 new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                 new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                 new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                 new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                 new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
                  new Test{caseNumbers = 11, countrys="AJKAKJA",day ="CVKLD",morecases= 11},
            };
    
            listOfCountry.ItemsSource = aa;
        }
    
    }

    public class Test {
        public int caseNumbers { get; set; }
        public string countrys { get; set; }
        public int morecases { get; set; }
        public string day { get; set; }

    }
}