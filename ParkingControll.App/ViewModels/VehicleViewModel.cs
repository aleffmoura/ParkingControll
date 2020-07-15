using System;

namespace ParkingControll.App.ViewModels
{
    public class VehicleViewModel
    {
        public string Plate { get; set; }
        public DateTime CameIn { get; set; }
        public DateTime? Exited { get; set; }
        public string TotalTimeInParking { get; set; }
        public string TotalTimePaid { get; set; }
        public decimal Price { get; set; }
        public string AmountPaid { get; set; }
    }
}
