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
    public class RatingController : ControllerBase
    {
        IRatingRepository RatingRepository;
        public RatingController(IRatingRepository _RatingRepository)
        {
            RatingRepository = _RatingRepository;
        }

        [HttpGet, Route("showRating")]
        public List<Rating> showRating()
        {
            var Rating = RatingRepository.showRating();
            if (Rating == null)
            {
                return null;
            }
            return Rating.ToList();
        }
    }
}