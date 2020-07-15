using ParkingControll.Domain.Enums;

namespace ParkingControll.Domain.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string message = "Registry not found") : base(ErrorCodes.NotFound, message) { }
    }
}
