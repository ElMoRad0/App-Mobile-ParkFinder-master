using Microcharts;
using ParkFinder.Models;
using ParkFinder.Views.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkFinder.Views.ParkingInfo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParkingInfoPage : ContentPage
    {
        ParkingModel Parking;
        private Random _rand = new Random();
        public ParkingInfoPage(ParkingModel Parking, int parkingId=0)
        {
            InitializeComponent();
            this.Parking = Parking;
            DisplayParkingInfo();
            
            // GET : ..../Parkings?id=parkingId
            // Parking <= Reponse
        }

        public ParkingInfoPage(int parkingId)
        {
            InitializeComponent();
            //this.Parking = 
            DisplayParkingInfo();

            // GET : ..../Parkings?id=parkingId
            // Parking <= Reponse
        }

        private void DisplayParkingInfo()
        {
            ParkNameLabel.Text = this.Parking.Name;
            LocationLabel.Text = this.Parking.Adresse;
            ParkImg.Source = this.Parking.Img_URL;
            CapacityLabel.Text = this.Parking.Capacity.ToString();
            AvailablePlacesLabel.Text = this.Parking.Computed_State;
            AvailablePlacesLabel.TextColor = (this.Parking.Computed_Color.ToLower() == "red") ? Color.Red : Color.Green;
            PriceLabel.Text = this.Parking.Computed_Price;
            SetChartData();
        }

        private void SetChartData()
        {
            var entries = new List<ChartEntry>()
            {
                new ChartEntry(this.Parking.OccupiedPlaces)
                {
                    Color = SkiaSharp.SKColor.Parse("#FF0000"),
                    Label = "Occupied",
                    ValueLabel = "Occupied"
                },
                new ChartEntry(this.Parking.Available_Places)
                {
                    Color = SkiaSharp.SKColor.Parse("#00FF00"),
                    Label = "Available",
                    ValueLabel = "Available"
                }
            };
            OccupyChart.Chart = new DonutChart() { Entries = entries };
        }

        private async void MakeReservBtn_Clicked(object sender, EventArgs e)
        {
            // placeId = SELECT Parking_Lot_ID FROM PlarkingLots WHERE PlarkingLots.STATE='Free';
            int placeId = _rand.Next(1, 10); // L'utilisateur n'a pas choisis de place, donc on doit lui affecter une place disponible
            await Navigation.PushAsync(new MakeReservationPage(this.Parking.Parking_Id, placeId));
        }

        private void MapBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void DetailsBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}