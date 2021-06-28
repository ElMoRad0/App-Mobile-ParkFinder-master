using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ParkFinder.Views.ListParking;
using ParkFinder.Views.Credit;
using ParkFinder.Views.ParkingPages;

namespace ParkFinder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }
        private async void MakeReservation_Tapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListParkingPage());

        }

        private async void FindParkingRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExploreMapPage());
        }
        private async void ProfilRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Account());
        }
        private async void SoldeRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreditSoldePage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CreditSoldePage());
            
        }
    }
}