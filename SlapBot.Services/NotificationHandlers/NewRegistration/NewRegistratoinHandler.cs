

namespace SlapBott.Services.NotificationHandlers.NewRegistration
{
    using MediatR;
    using SlapBott.Services.Notifactions;

    public class NewRegistratoinHandler : INotificationHandler<NewRegistration>
    {
        public Task Handle(NewRegistration notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
