using System.Runtime.Serialization;

namespace FirstMvcApp.Services;

[Serializable]
public class NotFoundException : DomainException
{
    public NotFoundException()
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
