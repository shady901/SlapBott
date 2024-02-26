using MediatR;

namespace SlapBott.Services.Notifactions
{
    public class FailedReply : INotification
    {
        public string Message { get; set; }
    }
}
