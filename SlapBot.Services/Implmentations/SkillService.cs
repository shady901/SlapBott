using SlapBott.Data.Models;
using SlapBott.Data.Repos;
using System;
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

        public Skill GetSkillById(int Id)
        {
            return _skillRepo.GetSkillById(Id);
        }
    }
}
