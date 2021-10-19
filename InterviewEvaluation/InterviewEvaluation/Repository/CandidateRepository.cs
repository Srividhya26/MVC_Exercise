using Dapper;
using InterviewEvaluation.Interfaces;
using InterviewEvaluation.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace InterviewEvaluation.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IConfiguration _configuration;

        public CandidateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Create Candidate
        public void AddCandidate(Candidate candidate)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Add_candidate";

            DynamicParameters parameters = new();

            parameters.Add("Name", candidate.Candidate_Name);
            parameters.Add("ReferralName", candidate.Referral_Name);
            parameters.Add("CurrentLastEmployer", candidate.Last_Employer);
            parameters.Add("CurrentLastDesignation", candidate.Last_Designation);
            parameters.Add("TotalExperience", candidate.Total_Experience);
            parameters.Add("NoticePeriod", candidate.Notice_Period);
            parameters.Add("Sources", candidate.Sources);
            parameters.Add("HealthCondition", candidate.Health_Condition);
            parameters.Add("Designation", candidate.Last_Designation);
            parameters.Add("Resume", candidate.Resume);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);
        }

        //Delete Candidate
        public void DeleteCandidate(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Delete_Candidate";

            DynamicParameters parameters = new();

            parameters.Add("@Id", id);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);

        }

        //Update Candidate
        public void UpdateCandidate(int id, Candidate candidate)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Update_Candidate";

            DynamicParameters parameters = new();

            parameters.Add("Name", candidate.Candidate_Name);
            parameters.Add("ReferralName", candidate.Referral_Name);
            parameters.Add("CurrentLastEmployer", candidate.Last_Employer);
            parameters.Add("CurrentLastDesignation", candidate.Last_Designation);
            parameters.Add("TotalExperience", candidate.Total_Experience);
            parameters.Add("NoticePeriod", candidate.Notice_Period);
            parameters.Add("Sources", candidate.Sources);
            parameters.Add("HealthCondition", candidate.Health_Condition);
            parameters.Add("Designation", candidate.Last_Designation);
            parameters.Add("Resume", candidate.Resume);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);
        }

        //Get all Candidates
        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Get_AllCandidates";

            var listOfCandidates = await Task.FromResult(dbConnection.Query<Candidate>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfCandidates;
        }

        //Get Candidate By ID
        public async Task<Candidate> GetCandidateById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Get_Candidate_by_ID";

            DynamicParameters parameters = new();

            parameters.Add("@Id", id);

            return await Task.FromResult(dbConnection.Query<Candidate>(sp, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault());
        }

       
    }
}
