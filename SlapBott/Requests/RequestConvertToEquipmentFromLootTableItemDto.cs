using Discord.Net;
using MediatR;
using SlapBott.Data.Models;
using SlapBott.Services;
using SlapBott.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Requests
{
    public class RequestConvertToEquipmentFromLootTableItemDto(LootTableItemDto lootTableItemDto): IRequest<EquipmentDto>
    {
        public LootTableItemDto LootTableItemDto { get; set; } = lootTableItemDto;

    }
}
