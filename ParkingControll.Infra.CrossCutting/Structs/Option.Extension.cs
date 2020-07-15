using System;

namespace ParkingControll.Infra.CrossCutting.Structs
{
    using static Helpers;
    public static class Option
    {
        public static Option<Exception, TSuccess> Run<TSuccess>(this Func<TSuccess> func)
        {
            try
            {
                return func();
            }
            catch(Exception ex)
            {
                return ex;
            }
        }

        public static Option<Exception, Unit> Run(this Action action) => Run(ToFunc(action));
        public static Option<Exception, TSuccess> Run<TSuccess>(this Exception ex) => ex;
    }
}
