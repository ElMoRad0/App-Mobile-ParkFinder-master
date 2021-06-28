using ParkFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkFinder.Views.Reservation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeReservationPage : ContentPage
    {
        public MakeReservationPage(int ParkingId, int ParkingLotId = 1)
        {
            InitializeComponent();
            parkId.Text = "ParkingId : " + ParkingId + " | PlaceId : " + ParkingLotId;
        }
    }
}