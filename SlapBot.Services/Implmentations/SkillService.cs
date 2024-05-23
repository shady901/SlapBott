using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using SlapBott.Services.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Services.Implmentations
{
    public class SkillService
    {
        private SkillRepo? _skillRepo { get; set; }

        public SkillService(SkillRepo repo)
        {
            _skillRepo = repo;
          
        }
        public ICollection<SkillDto> GetSkillCollectionByIds(ICollection<int> list)
        {
        
            ICollection<SkillDto>? collectionDto = new List<SkillDto>();
            foreach (var skill in _skillRepo.GetSkillCollectionByIdlist(list))
            {
                collectionDto.Add(new SkillDto().FromSkill(skill));
            }
            return collectionDto;
                   
        }
        public Skill GetSkillById(int Id)
        {
            return _skillRepo.GetSkillById(Id);
        }
    }
}
