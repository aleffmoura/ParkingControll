using ParkingControll.Domain.Base;
using System;

namespace ParkingControll.Domain.Features.Vehicles
{
    public class Vehicle : Entity
    {
        public string Plate { get; set; }
        public DateTime CameIn { get; set; }
        public DateTime? Exited { get; set; }
        public decimal Price { get; set; }
        public string TotalTimeInParking { get; set; }
        public string TotalTimePaid { get; set; }
        public string AmountPaid { get; set; }
    }
}
