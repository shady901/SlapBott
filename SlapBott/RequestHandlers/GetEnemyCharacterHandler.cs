using MediatR;
using SlapBott.Data.Contracts;
using SlapBott.Requests;
using SlapBott.Services.Implmentations;

namespace SlapBott.RequestHandlers
{
    public class GetEnemyCharacterHandler<T>(EnemyService enemyService) : IRequestHandler<RequestGetEnemyCharacter<T>, T> where T : Target
    {
        private readonly EnemyService _enemyService = enemyService;
        public async Task<T> Handle(RequestGetEnemyCharacter<T> request, CancellationToken cancellationToken)
        {
          return await Task.Run(() => { return _enemyService.GetEnemyTargetByID<T>(request.enemyId); });
        }
    }
}
