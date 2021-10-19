using InterviewEvaluation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluation.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        void AddCandidate(Candidate candidate);
        void UpdateCandidate(int id, Candidate candidate);
        void DeleteCandidate(int id);
    }
}
