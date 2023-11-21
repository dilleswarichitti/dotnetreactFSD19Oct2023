using System.Runtime.Serialization;

namespace HotelAPI.Exceptions
{
    [Serializable]
    public class NotAvailableException : Exception
    {
        string message;
        public NotAvailableException()
        {
            message = "id does not exsits";
        }
        public override string Message => message;
    }
}