using MediatR;
using SlapBott.Data.Models;

namespace SlapBott.Requests
{
    internal class RequestGetMaterialOrConsumableFromItemId<Tout>(int ItemId) : IRequest<Tout>
    {
        public int Id { get; set; } = ItemId;
    }
}