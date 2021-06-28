using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
        public RegisterPage()
        {
            InitializeComponent();
           
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

        private void ImageButton_Clicked1(object sender, EventArgs e)
        {

            var imageButton = sender as ImageButton;
            if (Entry.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("show.png");
                Entry.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("hide.jpg");
                Entry.IsPassword = true;
            }
        }


    }

}