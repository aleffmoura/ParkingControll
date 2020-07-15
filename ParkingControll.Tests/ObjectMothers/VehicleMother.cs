using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Domain.Features.Vehicles;
using System;

namespace ParkingControll.Tests.ObjectMothers
{
    public static class VehicleMother
    {
        static Guid _id = Guid.NewGuid();
        static string _plate = "abc-4552";

        public static VehicleCreateCommand CreateCommand = new VehicleCreateCommand
        {
            Plate = "abc-4553"
        };

        public static VehicleCreateCommand CreateCommandDuplicatePlate = new VehicleCreateCommand
        {
            Plate = _plate
        };

        
        public static Vehicle ValidNoExited = new Vehicle
        {
            Id = _id,
            CameIn = DateTime.Now,
            Plate = _plate,
            Price = 1,
            Removed = false
        };



        public static VehicleUpdateCommand UpdateCommand = new VehicleUpdateCommand
        {
            Plate = _plate
        };
    }
}
