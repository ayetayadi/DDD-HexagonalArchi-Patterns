using HexaArchi.Domain.Models;

namespace HexaArchi.Application.Ports.Driven
{
    public interface IMessagePublisher
    {
        Task PublishMessageAsync(Message message);
    }
}
