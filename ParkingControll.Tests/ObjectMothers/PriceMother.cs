using ParkingControll.Domain.Features.PriceAggregation;
using System;

namespace ParkingControll.Tests.ObjectMothers
{
    public static class PriceMother
    {
        static Guid _id = Guid.NewGuid();

        public static Price Price = new Price
        {
            Id = _id,
            Additional = 1,
            Initial = DateTime.Now.AddDays(-1),
            Final = DateTime.Now.AddDays(5),
            Removed = false,
            Tolerance = 10,
            Value = 2
        };
    }
}
