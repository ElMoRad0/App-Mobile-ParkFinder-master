using System;
using System.Collections.Generic;
using System.Text;

namespace ParkFinder.Models
{
    public class ParkingModel
    {
        public int Parking_Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string Img_URL { get; set; }
        public int Price { get; set; }
        public int Available_Places { get; set; }
        public int Capacity { get; set; }
        public int OccupiedPlaces { get; set; }
        public string Computed_Price { get; set; }
        public string Computed_State { get; set; }
        public string Computed_Color { get; set; }

        public void ComputeStuff(string Devise = "DH")
        {
            this.OccupiedPlaces = this.Capacity - this.Available_Places;
            this.Computed_Price = $"{this.Price} {Devise}";
            this.Computed_State = $"{OccupiedPlaces}/{this.Capacity}";
            this.Computed_Color = (Available_Places <= 0) ? "Red" : "Green";
        }
        public static void ComputeParkingsStuff(IEnumerable<ParkingModel> Parkings)
        {
            foreach (var parking in Parkings)
            {
                parking.ComputeStuff();
            }
        }
    }
}
