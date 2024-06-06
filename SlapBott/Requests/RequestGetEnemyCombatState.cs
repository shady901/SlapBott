using MediatR;
using SlapBott.Services.Dtos;

namespace SlapBott.Requests
{
    public class RequestGetEnemyCombatState(int Id) : IRequest<EnemyCombatStateDto>
    {
       public int StateId = Id;
    }
}