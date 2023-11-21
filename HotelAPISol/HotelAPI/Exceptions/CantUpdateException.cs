using System.Runtime.Serialization;

namespace HotelAPI.Exceptions
{
    [Serializable]
    internal class CantUpdateException : Exception
    {
        public CantUpdateException()
        {
        }

        public CantUpdateException(string? message) : base(message)
        {
        }

        public CantUpdateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CantUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}