using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Core.Models;
using Employee_Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        ISkillRepository SkillRepository;
        public SkillController(ISkillRepository _SkillRepository)
        {
            SkillRepository = _SkillRepository;
        }

        [HttpGet, Route("showSkill")]
        public IEnumerable<Skill> showSkill()
        {
            var Skill = SkillRepository.showSkill();
            if (Skill == null)
            {
                return null;
            }
            return Skill.ToList();
        }
    }
}