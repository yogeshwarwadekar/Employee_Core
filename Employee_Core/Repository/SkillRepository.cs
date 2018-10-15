using Employee_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Core.Repository
{
    public class SkillRepository:ISkillRepository
    {
        Employee_DatabaseContext db;
        public SkillRepository(Employee_DatabaseContext _db)
        {
            db = _db;
        }

        public List<Skill> showSkill()
        {
            if (db != null)
            {
                return db.Skill.ToList();
            }
            return null;
        }
    }
}
