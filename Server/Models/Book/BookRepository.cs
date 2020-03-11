using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Models.Book;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class BookRepository : IBook
    {
        private DataContext _context;

        private IConfiguration configuration;

        public BookRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<BookEntity> GetAll()
        {
            return _context.book.ToList();
        }

        public BookEntity GetById(Guid id)
        {
            return _context.book.Find(id);
        }

        public BookEntity Create(BookEntity model)
        {
            _context.book.Add(model);
            _context.SaveChanges();

            return model;  
        } 
        
        public BookEntity Update(Guid id, BookEntity modelUpdate)
        {
            var data = _context.book.Find(id);

            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public BookEntity Delete(Guid book_id)
        {
            var book = new BookEntity()
            {
                book_id = book_id
            };

            var data = _context.book.Remove(book);

            _context.SaveChanges();

            return book;
        }  
    }
}
