using MediatR;
using SlapBott.Requests;
using SlapBott.Services.Dtos;
using SlapBott.Services.Implmentations;
using SlapBott.Services.Objects;

namespace SlapBott.RequestHandlers
{
    public class AttackBackManager(IMediator mediator,CombatManager combatManager) : IRequestHandler<RequestAttackBack, AttackResults<EnemyDto,PlayerCharacterDto>>
    {
        private IMediator _mediator = mediator;
        private CombatManager _combatManager = combatManager; 
        public async Task<AttackResults<EnemyDto,PlayerCharacterDto>> Handle(RequestAttackBack request, CancellationToken cancellationToken)
        {
            EnemyDto enemyDto = request.EnemyDto;
            PlayerCharacterDto characterDto = request.PlayerCharacterDto;
            SkillDto skillDto = await _mediator.Send(new RequestGetSkill(EnemyDto.GetRandomFromList(enemyDto.Skills)));
            var result = _combatManager.Attack(skillDto,enemyDto,characterDto);
            result.Skill = skillDto;
            result.Receiver = characterDto;
            result.Sender = enemyDto;
            return result;
        }
    }
}
