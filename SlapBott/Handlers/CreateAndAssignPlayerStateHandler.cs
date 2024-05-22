using MediatR;
using SlapBott.Notifications;
using SlapBott.Services.Implmentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlapBott.Services.Dtos;

namespace SlapBott.Handlers
{
    public class CreateAndAssignPlayerStateHandler(IMediator mediator, CombatStateService combatStateService) : INotificationHandler<CreateAndAssignPlayerStateNotification>
    {
        private IMediator _mediator = mediator;
        private CombatStateService _combatStateService = combatStateService;
        public Task Handle(CreateAndAssignPlayerStateNotification notification, CancellationToken cancellationToken)
        {
            _combatStateService.SavePlayerCombatState(new PlayerCharacterCombatStateDto() { ParticipantId = notification.CharID, CombatStateId = notification.StateID });
            return Task.CompletedTask;
        }
    }
}
