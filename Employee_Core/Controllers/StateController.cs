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
    public class StateController : ControllerBase
    {
        IStateRepository StateRepository;
        public StateController(IStateRepository _StateRepository)
        {
            StateRepository = _StateRepository;
        }

        [HttpGet, Route("showState")]
        public IEnumerable<State> showState()
        {
            var State = StateRepository.showState();
            if (State == null)
            {
                return null;
            }
            return State.ToList();
        }
    }
}