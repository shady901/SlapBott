using MediatR;
using SlapBott.Data.Enums;
using SlapBott.Data.Models;
using SlapBott.ItemProject.Builders;
using SlapBott.ItemProject.Items;
using SlapBott.Requests;
using SlapBott.Services.Dtos;

namespace SlapBott.RequestHandlers
{
    public class ConvertToEquipmentFromLootTableItemHandler(IMediator mediator) : IRequestHandler<RequestConvertToEquipmentFromLootTableItemDto, EquipmentDto>
    {
        private IMediator _mediator = mediator;

      
        public async Task<EquipmentDto> Handle(RequestConvertToEquipmentFromLootTableItemDto request, CancellationToken cancellationToken)
        {

           await ConvertLootTableItemToEquipment(request.LootTableItemDto);

           return (new EquipmentDto());
        }
        private async Task<EquipmentDto> ConvertLootTableItemToEquipment(LootTableItemDto lootTableItem)
        {
            var equipmentDto = new EquipmentDto();

            // Check if the item type is not Gear
            if (lootTableItem.ItemType != ItemType.Gear)
            {
                equipmentDto.Count = lootTableItem.Quantity;
                if (lootTableItem.ItemType != ItemType.Consumable)
                {
                    equipmentDto.Material =  _mediator.Send(new RequestGetMaterialOrConsumableFromItemId<MaterialDto>(lootTableItem.ItemId)).Result;

                }
                else
                {
                    equipmentDto.Consumable =  _mediator.Send(new RequestGetMaterialOrConsumableFromItemId<ConsumableDto>(lootTableItem.ItemId)).Result;
                }
            }
            if (lootTableItem.ItemType == ItemType.Gear)
            {
                Gear gear = getItem(lootTableItem);
                if (gear != null&& gear is Weapon weapon)
                {
                    equipmentDto.WeaponType = weapon.WeaponType;
                    equipmentDto.Seed = weapon.Seed;
                    equipmentDto.DroppedLevel = weapon.DroppedLevel;
                    equipmentDto.Count = 1;
                    equipmentDto.EquipType = weapon.EquipType;                    
                }
                else if (gear is Armor armor)
                {
                    equipmentDto.ArmorType = armor.ArmorType;
                    equipmentDto.Seed = armor.Seed;
                    equipmentDto.DroppedLevel = armor.DroppedLevel;
                    equipmentDto.Count = 1;
                    equipmentDto.EquipType = armor.EquipType;
                }
            }

            return equipmentDto;
        }

       

        private Gear getItem(LootTableItemDto lootTableItem)
        {
            ItemParameterBuilder itemParamBuilder = new();
            itemParamBuilder.WithItemRarety(lootTableItem.GearRarety);
            return _mediator.Send(new RequestGenerateNewItem(itemParamBuilder)).Result;
        }

    }
}
