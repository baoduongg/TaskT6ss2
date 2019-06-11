using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Themes;

namespace TaskT6.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }
        public enum Themes
        {
            Dark,
            Light
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var origin = App.Current.Resources;
            origin.MergedWith = typeof(DarkThemeResources);
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            var origin = App.Current.Resources;
            origin.MergedWith = typeof(LightThemeResources);
        }
    }
}