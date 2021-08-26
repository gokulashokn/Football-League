using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Football_League.Interfaces;

namespace Football_League.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public readonly ITeamManager teamManager;

        public TeamController(ITeamManager _teamManager) {
            teamManager = _teamManager;
        }

        [HttpGet]
        [Route("api/[controller]/getTeam/{id}")]
        public IActionResult getTeam(String id)
        {
            try
            {
                var result = teamManager.getTeam(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/createTeam/{teamname}/{managername}")]
        public IActionResult createTeam(String teamname, String managername)
        {
            try
            {
                return Ok(teamManager.createTeam(teamname, managername));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/updateTeamManager/{id}/{mgrName}")]
        
        public IActionResult updateTeamManager(String id, string mgrName)
        {
            try
            {
                return Ok(teamManager.updateTeamManager(id, mgrName));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/deleteTeam/{id}")]
        public IActionResult deleteTeam(String id)
        {
            try
            {
                return Ok(teamManager.deleteTeam(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
