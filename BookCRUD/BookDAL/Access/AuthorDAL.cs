using BookDAL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL.Access
{
    public class AuthorDAL
    {
        private readonly IConfiguration _configuration;

        public AuthorDAL(IConfiguration configuration)
        {
            this._configuration = configuration; 
        }

        public void AddAuthor(Author author)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_AddAuthor";

            DynamicParameters parameter = new();

            parameter.Add("Name", author.Name);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);
        }

        public void UpdateAuthor(Author author,int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConection"));

            string sp = "Sp_UpdateAuthor";

            DynamicParameters parameter = new();

            parameter.Add("Id", id);
            parameter.Add("Name", author.Name);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);
        }

        public void DeleteAuthor(int id)
        {
            using IDbConnection dbConection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_DeleteAuthor";

            DynamicParameters parameter = new();

            parameter.Add("@id", id);

            SqlMapper.Execute(dbConection, sp, commandType: CommandType.StoredProcedure, param: parameter);
        }

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_GetAllAuthor";

            var listOfAuthor = await Task.FromResult(dbConnection.Query<Author>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfAuthor;
         }

        public async Task<Author> GetAuthorById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "Sp_GetAuthorById";

            DynamicParameters parameters = new();

            parameters.Add("id", id);

            return await Task.FromResult(dbConnection.Query<Author>(sp, commandType: CommandType.StoredProcedure).FirstOrDefault());

           
        }


    }
}
