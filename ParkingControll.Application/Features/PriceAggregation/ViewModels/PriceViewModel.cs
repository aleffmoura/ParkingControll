using System;

namespace ParkingControll.Application.Features.PriceAggregation.ViewModels
{
    public class PriceViewModel
    {
        public int Tolerance { get; set; }
        public int Value { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Final { get; set; }
        public decimal Additional { get; set; }
    }
}
