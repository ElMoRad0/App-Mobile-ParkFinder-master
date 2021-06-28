using ParkFinder.Models;
using ParkFinder.Views.ParkingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkFinder.Views.ParkingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreMapPage : ContentPage
    {
        List<ParkingModel> Parkings;
        public ExploreMapPage()
        {
            InitializeComponent();
        }

        public ExploreMapPage(IEnumerable<ParkingModel> parkings)
        {
            InitializeComponent();
            this.Parkings = parkings.ToList();
            PopulateData();
        }

        protected override void OnAppearing()
        {
            // async call to API and Get Parkings Data
            var parkings = new ParkingModel[]
            {
                new ParkingModel()
                {
                    Parking_Id=1,
                    Name = "Parking 1",
                    Adresse = "Agdal.....",
                    Available_Places = 10,
                    Capacity = 20,
                    Img_URL = "https://media.antwerpen.be/media/6/F/FYTWBljUWWgVPdIVRm4YIBiR/1536225033589.jpg",
                    Price = 10
                },
                new ParkingModel()
                {
                    Parking_Id=2,
                    Name = "Parking 2",
                    Adresse = "Casablanca, Maarif",
                    Available_Places = 30,
                    Capacity = 30,
                    Img_URL = "https://www.locationdesvacances.com/wp-content/uploads/2017/11/parking-759x500.jpg",
                    Price = 20
                },
                new ParkingModel()
                {
                    Parking_Id=3,
                    Name = "Parking 2",
                    Adresse = "Casablanca",
                    Available_Places = 0,
                    Capacity = 31,
                    Img_URL = "https://www.locationdesvacances.com/wp-content/uploads/2017/11/parking-759x500.jpg",
                    Price = 20
                }
            };
            base.OnAppearing();
            this.Parkings = parkings.ToList();
            ParkingModel.ComputeParkingsStuff(parkings);
            PopulateData();
        }

        private void PopulateData()
        {
            for (int i = 0; i < this.Parkings.Count; i++)
            {
                parkingsLayout.Children.Add(CreateElement(this.Parkings[i]));
            }
        }

        private StackLayout CreateElement(ParkingModel Parking)
        {
            var MainSTack = new StackLayout()
            {
                ClassId = Parking.Parking_Id.ToString(),
                BackgroundColor = (Parking.Computed_Color.ToLower() == "red") ? Color.LightPink:Color.LightGreen,
                Padding = 4,
                WidthRequest = 180
            };
            var image = new Image()
            {
                Source = Parking.Img_URL,
                WidthRequest = 170,
                HeightRequest = 120
            };
            var Label1 = new Label()
            {
                Margin = new Thickness(7, 0),
                Text = Parking.Name,
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start
            };
            var Label2 = new Label()
            {
                Margin = new Thickness(7, 0),
                Text = Parking.Computed_State,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
            };
            MainSTack.Children.Add(image);
            MainSTack.Children.Add(Label1);
            MainSTack.Children.Add(Label2);
            var tap = new TapGestureRecognizer();
            tap.Tapped += TapGestureRecognizer_Tapped;
            MainSTack.GestureRecognizers.Add(tap);
            return MainSTack;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            parkingsLayout.Children.Clear();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            StackLayout Sender = (StackLayout)sender;
            var park = Parkings.Where(o => o.Parking_Id == int.Parse(Sender.ClassId)).FirstOrDefault();
            await Navigation.PushAsync(new ParkingInfoPage(park));
        }

    }
}