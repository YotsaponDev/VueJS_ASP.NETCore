using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Server.Models.Book
{
    public interface IBook
    {
        List<BookEntity> GetAll();
        BookEntity GetById(Guid id);
        BookViewModel Create(BookDataWithFile model);
        BookEntity Update(Guid id, BookDataWithFile modelUpdate);
        BookEntity Delete(Guid id);
    }
}
