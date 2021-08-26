using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Football_League.Interfaces;
using Football_League.Models;

namespace Football_League.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedMatchController : ControllerBase
    {
        public readonly IMatchManager MatchManager;

        public PlayedMatchController(IMatchManager _MatchManager)
        {
            MatchManager = _MatchManager;
        }

        [HttpGet]
        [Route("api/[controller]/getMatch/{id}")]
        public IActionResult getMatch(String id)
        {
            try
            {
                var result = MatchManager.getMatch(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("api/[controller]/getAllMatches")]
        public ActionResult<PlayedMatch> getAllMatches()
        {
            try
            {
                List<PlayedMatch> playedMatches = new List<PlayedMatch>();
                playedMatches = MatchManager.getAllMatches();
                return Ok(playedMatches);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("api/[controller]/getStandings")]
        public ActionResult<TeamStandings> getStandings()
        {
            try
            {
                List<TeamStandings> standings = new List<TeamStandings>();
                standings = MatchManager.getStandings();
                return Ok(standings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/createMatch/{home}/{away}")]
        public IActionResult createMatch(String home, String away, String matchResult, String winner)
        {
            try
            {
                return Ok(MatchManager.createMatch(home, away, matchResult, winner));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/updateMatchResult/{id}/{matchResult}/{winner}")]

        public IActionResult updateMatchResult(String id, string matchResult, string winner)
        {
            try
            {
                return Ok(MatchManager.updateMatchResult(id, matchResult, winner));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("api/[controller]/deleteMatch/{id}")]
        public IActionResult deleteMatch(String id)
        {
            try
            {
                return Ok(MatchManager.deleteMatch(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
