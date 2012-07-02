namespace Domain.Design.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}