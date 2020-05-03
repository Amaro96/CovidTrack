using System;
using System.Collections.Generic;
using System.Text;
using XFCovidTrack.Interfaces;

namespace XFCovidTrack.ViewModels
{
    public class HeaderViewModel : BaseViewModel
    {
        private readonly IRestService _services;
        public HeaderViewModel(IRestService _restServices)
        {
            _services = _restServices;
        }
    }
}
