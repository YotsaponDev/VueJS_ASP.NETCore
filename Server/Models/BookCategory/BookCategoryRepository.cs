using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Models.BookCategory;
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
    public class BookCategoryRepository : IBookCategory
    {
        private DataContext _context;

        private IConfiguration configuration;

        public BookCategoryRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<BookCategoryEntity> GetAll()
        {
            return _context.book_category.ToList();
        }

        public BookCategoryEntity GetById(Guid id)
        {
            return _context.book_category.Find(id);
        }

        public BookCategoryEntity Create(BookCategoryEntity model)
        {
            _context.book_category.Add(model);
            _context.SaveChanges();

            return model;  
        } 
        
        public BookCategoryEntity Update(Guid id, BookCategoryEntity modelUpdate)
        {
            var data = _context.book_category.Find(id);

            modelUpdate.book_category_id = data.book_category_id;
            modelUpdate.created_at = data.created_at;

            data.code = modelUpdate.code;
            data.name = modelUpdate.name;
            data.updated_at = modelUpdate.updated_at;

            _context.SaveChanges();

            return modelUpdate;
        }

        public BookCategoryEntity Delete(Guid book_category_id)
        {
            var book_category = new BookCategoryEntity()
            {
                book_category_id = book_category_id
            };

            var data = _context.book_category.Remove(book_category);

            _context.SaveChanges();

            return book_category;
        }  
    }
}
