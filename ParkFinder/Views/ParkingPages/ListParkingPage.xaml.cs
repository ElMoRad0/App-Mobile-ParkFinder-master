using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

using ParkFinder.Models;
using ParkFinder.Views.ParkingInfo;

namespace ParkFinder.Views.ListParking
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListParkingPage : ContentPage
    {
        public ListParkingPage()
        {
            //var list = new string[] {
            //    "Bonjour",
            //    "Ok"
            //};
            var list = new ParkingModel[]
            {
                new ParkingModel()
                {
                    Parking_Id=1,
                    Name = "Parking 1",
                    Adresse = "Agdal.....",
                    Available_Places = 0,
                    Capacity = 20,
                    Img_URL = "https://media.antwerpen.be/media/6/F/FYTWBljUWWgVPdIVRm4YIBiR/1536225033589.jpg",
                    Price = 10
                },
                new ParkingModel()
                {
                    Parking_Id=2,
                    Name = "Parking 2",
                    Adresse = "Casablanca, Maarif",
                    Available_Places = 29,
                    Capacity = 30,
                    Img_URL = "https://www.locationdesvacances.com/wp-content/uploads/2017/11/parking-759x500.jpg",
                    Price = 20
                },
                new ParkingModel()
                {
                    Parking_Id=2,
                    Name = "Parking 2",
                    Adresse = "Casablanca",
                    Available_Places = 1,
                    Capacity = 30,
                    Img_URL = "https://www.locationdesvacances.com/wp-content/uploads/2017/11/parking-759x500.jpg",
                    Price = 20
                }
            };
            ParkingModel.ComputeParkingsStuff(list);
            InitializeComponent();
            ParkingsListView.BindingContext = this;
            ParkingsListView.ItemsSource = list;
            //Task.Delay(2000);
            //UpdateMap();
        }
        List<Place> placesList = new List<Place>();

        private async void UpdateMap()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ListParkingPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("ParkFinder.Views.Places.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Places>(text);

                foreach (var place in resultObject.results)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.name,
                        Address = place.vicinity,
                        Location = place.geometry.location,
                        Position = new Position(place.geometry.location.lat, place.geometry.location.lng),
                        Icon = place.icon,
                       //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                        //OpenNow = GetOpenHours(place?.opening_hours?.open_now)
                    });
                }

                //MyMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(47.6370891183, -122.123736172), Distance.FromKilometers(100)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }

        private async void ParkingsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(sender == null) { return; }
            var listView = (ListView)sender;

            var selectedParking = (ParkingModel)listView.SelectedItem;
            await Navigation.PushAsync(new ParkingInfoPage(selectedParking, 0));
        }
    }
}