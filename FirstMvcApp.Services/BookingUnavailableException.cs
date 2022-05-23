using System.Runtime.Serialization;

namespace FirstMvcApp.Services
{
    [Serializable]
    public class BookingUnavailableException : DomainException
    {
        public BookingUnavailableException()
        {
        }

        public BookingUnavailableException(string? message) : base(message)
        {
        }

        public BookingUnavailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BookingUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}