using ParkingControll.Domain.Base;
using System;

namespace ParkingControll.Domain.Features.PriceAggregation
{
    public class Price : Entity
    {
        public decimal Value { get; set; }
        public decimal Additional { get; set; }
        public int Tolerance { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Final { get; set; }
    }
}
