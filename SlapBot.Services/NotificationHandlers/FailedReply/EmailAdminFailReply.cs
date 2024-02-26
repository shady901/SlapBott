


namespace SlapBott.Services.NotificationHandlers.FailedReply
{
    using MediatR;
    using Microsoft.Extensions.Logging;
    using SlapBott.Services.Notifactions;

    public class EmailAdminFailReply : INotificationHandler<FailedReply>
    {
        private readonly ILogger _logger;

        public EmailAdminFailReply(ILogger logger) 
        {
            _logger = logger;
        }

        public Task Handle(FailedReply notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
