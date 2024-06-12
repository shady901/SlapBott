using MediatR;
using SlapBott.Data.Enums;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Items;

namespace SlapBott.Requests
{
    internal class RequestGenerateNewItem(ItemParameterBuilder itemParameterBuilder) : IRequest<Gear>
    {
       public ItemParameterBuilder ItemParameterBuilder { get; set; } = itemParameterBuilder;
    }
}