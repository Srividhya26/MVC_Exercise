using BookDAL.Access;
using BookDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBL.Logics
{
    public class AuthorBL
    {
        private readonly AuthorDAL _authorDAL;

        public AuthorBL(AuthorDAL author)
        {
            this._authorDAL = author;
        }

        public void AddAuthor(Author author)
        {
            _authorDAL.AddAuthor(author);
        }

        public void UpdateAuthor(Author author,int id)
        {
            _authorDAL.UpdateAuthor(author,id);
        }

        public void DeleteAuthor(int id)
        {
            _authorDAL.DeleteAuthor(id);
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorDAL.GetAllAuthor();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _authorDAL.GetAuthorById(id);
        }
    }
}
