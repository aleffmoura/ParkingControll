﻿using ParkingControll.Domain.Enums;
using ParkingControll.Domain.Exceptions;
using System;

namespace ParkingControll.Exceptions
{
    public class ExceptionPayload
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
        public static ExceptionPayload New<T>(T exception) where T : Exception
        {
            int errorCode;

            if (exception is BusinessException businessException)
                errorCode = businessException.ErrorCode.GetHashCode();
            else
                errorCode = ErrorCodes.Unhandled.GetHashCode();

            return new ExceptionPayload
            {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
            };
        }
    }
}
