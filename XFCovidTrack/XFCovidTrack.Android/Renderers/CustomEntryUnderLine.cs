using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCovidTrack.Droid.Renderers;
using XFCovidTrack.Renderers;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryUnderLineRenderer))]
namespace XFCovidTrack.Droid.Renderers
{
   public class CustomEntryUnderLineRenderer : EntryRenderer
    {
    public CustomEntryUnderLineRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.Gravity = GravityFlags.Start;
            }
        }
    }
}