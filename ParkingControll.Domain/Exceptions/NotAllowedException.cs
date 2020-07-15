using ParkingControll.Domain.Enums;

namespace ParkingControll.Domain.Exceptions
{
    public class NotAllowedException : BusinessException
    {
        public NotAllowedException(string msg = "Não permitido") : base(ErrorCodes.NotAllowed, msg)
        {
        }
    }
}
