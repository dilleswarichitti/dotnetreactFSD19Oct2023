using System.Runtime.Serialization;

namespace HotelAPI.Exceptions
{
    [Serializable]
    internal class CantRemoveException : Exception
    {
        public CantRemoveException()
        {
        }

        public CantRemoveException(string? message) : base(message)
        {
        }

        public CantRemoveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CantRemoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}