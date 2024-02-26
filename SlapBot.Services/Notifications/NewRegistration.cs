

namespace SlapBott.Services.Notifactions
{
    using MediatR;
    public class NewRegistration: INotification
    {
        public string Name { get; set; }
    }
}
