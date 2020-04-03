using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Models.Book;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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

        public BookViewModel Create(BookDataWithFile model)
        {
            var create = new BookEntity();
            create.book_id = Guid.NewGuid();
            create.name = model.name;
            create.detail = model.detail;
            create.author = model.author;
            create.publisher = model.publisher;
            create.book_category_id = model.book_category_id;
            create.number_of_page = model.number_of_page;

            create.created_at = DateTime.Now;
            create.updated_at = null;

            if (model.image != null)
            {
                foreach (var formFile in model.image)
                {
                    Directory.CreateDirectory("Resources\\Images\\" + create.book_id.ToString());
                    var folderName = Path.Combine("Resources", "Images", create.book_id.ToString());
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    
                    if (formFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(formFile.FileName);

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }

                        create.image = fileName;
                    }
                }
            }

            _context.book.Add(create);

            _context.SaveChanges();

            var return_data = new BookViewModel();

            return_data.book_id = create.book_id;
            return_data.name = create.name;
            return_data.detail = create.detail;
            return_data.author = create.author;
            return_data.publisher = create.publisher;
            return_data.book_category_id = create.book_category_id;
            return_data.number_of_page = create.number_of_page;
            return_data.image = create.image;
            return_data.created_at = create.created_at;
            return_data.updated_at = null;

            return return_data;  
        } 
        
        public BookEntity Update(Guid id, BookDataWithFile modelUpdate)
        {
            var data = _context.book.Find(id);

            data.name = modelUpdate.name;
            data.detail = modelUpdate.detail;
            data.author = modelUpdate.author;
            data.publisher = modelUpdate.publisher;
            data.book_category_id = modelUpdate.book_category_id;
            data.number_of_page = modelUpdate.number_of_page;
            data.updated_at = DateTime.Now;

            if (modelUpdate.image != null)
            {
                foreach (var formFile in modelUpdate.image)
                {
                    var folderName = Path.Combine("Resources", "Images", data.book_id.ToString());
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (formFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(formFile.FileName);
                        if (fileName != data.image)
                        {
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);

                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                formFile.CopyTo(stream);
                            }

                            // delete old file
                            if (File.Exists(pathToSave + "/" + data.image))
                            {
                                File.Delete(pathToSave + "/" + data.image);
                            }

                            data.image = fileName;
                        }
                    }
                }
            }
            
            _context.SaveChanges();

            return data;
        }

        public BookEntity Delete(Guid book_id)
        {
            var find_item = _context.book.Find(book_id);
            if (find_item == null)
            {
                throw new Exception("Item not found");
            }

            _context.book.Remove(find_item);

            _context.SaveChanges();

            // delete file
            var folderName = Path.Combine("Resources", "Images", find_item.book_id.ToString());
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            // delete all file in folder
            string[] files = Directory.GetFiles(pathToSave, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                File.Delete(file);
            }
            // delete folder
            if (Directory.Exists(pathToSave))
            {
                Directory.Delete(pathToSave);
            }

            return find_item;
        }  
    }
}
