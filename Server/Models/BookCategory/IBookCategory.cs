using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Server.Models.BookCategory
{
    public interface IBookCategory
    {
        List<BookCategoryEntity> GetAll();
        BookCategoryEntity GetById(Guid id);
        BookCategoryEntity Create(BookCategoryEntity model);
        BookCategoryEntity Update(Guid id, BookCategoryEntity modelUpdate);
        BookCategoryEntity Delete(Guid id);
    }
}
