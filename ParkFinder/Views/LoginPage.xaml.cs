using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }
        private void TapGestureRecognizer_Tapped (object sender , EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
        private void signin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DashboardPage());
        }
        private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
           
        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {

            var imageButton = sender as ImageButton;
            if (MyEntry.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("show.png");
                MyEntry.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("hide.jpg");
                MyEntry.IsPassword = true;
            }
        }

    }
}