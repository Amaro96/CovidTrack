using Rg.Plugins.Popup.Services;
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
    public partial class HeaderView : ContentView
    {
        TesteViewModel _TesteViewModel;
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
            propertyName: "Title",
            returnType: typeof(string),
            declaringType: typeof(HeaderView),
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitleTextPropertyChanged);


        public string TitleText {

            get { return base.GetValue(TitleTextProperty).ToString(); }

            set { base.SetValue(TitleTextProperty, value); }
        }


        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (HeaderView)bindable;
            control.title.Text = newValue.ToString();
        }


        public static readonly BindableProperty SubTitleTextProperty = BindableProperty.Create(
            propertyName: "SubTitle",
            returnType: typeof(string),
            declaringType: typeof(HeaderView),
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: SubTitleTextPropertyChanged);


        public string SubTitleText
        {

            get { return base.GetValue(SubTitleTextProperty).ToString(); }

            set { base.SetValue(SubTitleTextProperty, value); }
        }


        private static void SubTitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (HeaderView)bindable;
            control.subTitle.Text = newValue.ToString();
        }


        public HeaderView()
        {
            InitializeComponent();
            BindingContext = _TesteViewModel = new TesteViewModel();
            switchBt.Toggled += (sender, e) =>
            {

                _TesteViewModel.ChangeAppThemeCommand.Execute(null);
            };
        }

        private async void btnMyLocation_Clicked(object sender, EventArgs e)
        {
           await PopupNavigation.Instance.PushAsync(new MyLocationPage());
        }
    }
}