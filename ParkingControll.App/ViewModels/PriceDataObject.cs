using System;

namespace ParkingControll.App.ViewModels
{
    public class PriceDataObject
    {
        public int Tolerance { get; set; }
        public decimal Value { get; set; }
        public decimal Additional { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Final { get; set; }
    }
}
