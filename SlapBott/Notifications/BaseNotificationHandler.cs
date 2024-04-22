using SlapBott.Data.Models;
using SlapBott.Services.Implmentations;

namespace SlapBott.Notifications
{
    internal abstract class BaseNotificationHandler(RegistrationService registeredServices)
    {
        protected Registration registration { get; set; }
        protected Task<bool> CheckRegistation(ulong UserId)
        {
            registration = registeredServices.GetUserByDiscordId(UserId);

            return Task.FromResult(registration != null);
        }

    }
}
