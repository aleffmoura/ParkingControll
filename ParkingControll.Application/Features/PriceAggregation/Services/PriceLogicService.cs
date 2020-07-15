using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Infra.CrossCutting.Structs;
using System;

namespace ParkingControll.Application.Features.PriceAggregation.Services
{
    public class PriceLogicService
    {
        public Option<Exception, Tuple<decimal, int, string>> AmountPaid(TimeSpan timeInParking, Price price)
        {
            try
            {
                if (timeInParking.TotalMinutes <= 30)
                    return new Tuple<decimal, int, string>(price.Value / 2, 30, timeInParking.ToString(@"hh\:mm\:ss"));

                if (timeInParking.Hours == 0)
                    return new Tuple<decimal, int, string>(price.Value, 1, timeInParking.ToString(@"hh\:mm\:ss"));

                Decimal amount = price.Value + (timeInParking.Hours == 1 ? 0 : price.Additional * timeInParking.Hours);

                int timePaid = timeInParking.Hours;

                if (timeInParking.Minutes > price.Tolerance)
                {
                    amount += price.Additional;
                    timePaid += 1;
                }

                return new Tuple<decimal, int, string>(amount, timePaid, timeInParking.ToString(@"hh\:mm\:ss")); ;

            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
