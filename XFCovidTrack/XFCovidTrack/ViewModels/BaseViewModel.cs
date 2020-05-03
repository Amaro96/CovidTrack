using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFCovidTrack.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public INavigation Navigation;
        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public static bool CheckConnectivity()
        {
            var connection = Connectivity.NetworkAccess;
            if (connection == NetworkAccess.Internet)
                return true;

            return false;
        }

        private bool _isTouched;
        public bool IsTouched
        {
            get { return _isTouched; }
            set
            {
                SetProperty(ref _isTouched, value);
            }
        }

        public virtual void OnDisappearing() { }
    }
}

