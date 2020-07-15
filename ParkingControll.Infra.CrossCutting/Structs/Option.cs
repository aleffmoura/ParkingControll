using System;

namespace ParkingControll.Infra.CrossCutting.Structs
{
    public struct Option<TFailure, TSuccess> : IDisposable
    {
        public TFailure Failure { get; set; }
        public TSuccess Success { get; set; }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        internal Option(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Success = default;
        }

        internal Option(TSuccess success)
        {
            IsFailure = false;
            Failure = default;
            Success = success;
        }

        public static implicit operator Option<TFailure, TSuccess>(TFailure failure)
            => new Option<TFailure, TSuccess>(failure);

        public static implicit operator Option<TFailure, TSuccess>(TSuccess success)
            => new Option<TFailure, TSuccess>(success);

        public static Option<TFailure, TSuccess> Of(TSuccess success) => success;
        public static Option<TFailure, TSuccess> Of(TFailure obj) => obj;

        public void Dispose()
        {
            Success = default;
            Failure = default;
        }
    }
}
