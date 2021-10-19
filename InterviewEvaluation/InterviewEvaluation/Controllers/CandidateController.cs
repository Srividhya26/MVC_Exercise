using InterviewEvaluation.Interfaces;
using InterviewEvaluation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluation.Controllers
{
    //[Authorize(Roles = "HR")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }

        //GetAllCandidates
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            try
            {
                var listOfCandidates = await _candidateRepository.GetAllCandidates();
                return Ok(listOfCandidates);
            }
            catch (Exception e)
            {
                return StatusCode(statusCode: 500, e.Message);
            }

        }

        //GetCandidateByID 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            try
            {
                var candidate = await _candidateRepository.GetCandidateById(id);

                if (candidate == null)
                    return NotFound();
                else
                    return Ok(candidate);
            }
            catch (Exception e)
            {
                return StatusCode(statusCode: 500, e.Message);
            }
        }

        //Create
        [HttpPost]
        public void CreateCandidate([FromBody] Candidate candidate)
        {
            try
            {
                _candidateRepository.AddCandidate(candidate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Update
        [HttpPut("{id}")]
        public void UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            try
            {
                var result = _candidateRepository.GetCandidateById(id);

                if (result != null)
                    _candidateRepository.UpdateCandidate(id, candidate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public void DeleteCandidate(int id)
        {
            try
            {
                var result = _candidateRepository.GetCandidateById(id);

                if (result != null)
                    _candidateRepository.DeleteCandidate(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
