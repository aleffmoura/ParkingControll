﻿using System;

namespace ParkingControll.Application.Features.Vehicles.ViewModels
{
    public class VehicleViewModel
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public DateTime CameIn { get; set; }
        public DateTime? Exited { get; set; }
        public string TotalTimeInParking { get; set; }
        public string TotalTimePaid { get; set; }
        public string AmountPaid { get; set; }
    }
}
