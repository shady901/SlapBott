using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlapBott.Data.Repos
{
    public class SkillRepo
    {
        private SlapbottDbContext _dbContext { get; set; }

        public SkillRepo(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }

        public Skill? GetSkillById(int id) 
        {
            if (id <=0)
            {
                return null;
            }
            return _dbContext.Skills.Where(x => x.Id == id).First();
        }
        public Skill? GetSkillByName(string name)
        {
            if (name == string.Empty)
            {
                return null;
            }
            return _dbContext.Skills.Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).First();
        }


        public ICollection<Skill>? GetSkillCollectionByIdlist(ICollection<int> list)
        {
            if (list.Count >0)
            {
                return _dbContext.Skills.Where(x=> list.Contains(x.Id)).ToList();
            }
            return null;
           
        }

    }
}
