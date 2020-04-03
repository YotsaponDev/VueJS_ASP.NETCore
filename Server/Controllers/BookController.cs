using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Microsoft.Extensions.Logging;
using Core.Data;
using Todo.Models;
using Server.Models.Book;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private ILogger<BookController> _logger;

        private readonly IBook _book;

        public BookController(IBook book)
        {
            _book = book;
        }

        /// <summary>
        /// Book get all data
        /// </summary>
        /// <remarks>
        /// Book get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(List<BookViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _book.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Book get By Id
        /// </summary>
        /// <remarks>
        /// Book get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<BookViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _book.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Book get By Id
        /// </summary>
        /// <remarks>
        /// Book get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("Image")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Iamge(Guid book_id,string image_name)
        {
            try
            {
                if (book_id == null || image_name == null)
                {
                    return null;
                }
                var folderName = Path.Combine("Resources", "Images", book_id.ToString(), image_name);
                var pathImage = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var image = System.IO.File.OpenRead(pathImage);

                string[] file_type = image_name.Split('.');

                return File(image, "image/"+ file_type[file_type.Length-1]);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Book create item
        /// </summary>
        /// <remarks>
        /// Book create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="409">Conflict</response>  
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<BookViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Create([FromForm] BookDataWithFile model)
        {
            try
            {
                if (model != null)
                {
                    var x = _book.Create(model);
                    return Json(x);
                }
                else
                {
                    return Json(model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(409, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Book Update item
        /// </summary>
        /// <remarks>
        /// Book Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<BookEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update(Guid id, [FromForm] BookDataWithFile model)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _book.Update(id, model);
                    return Json(res);
                }
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Book Delete item
        /// </summary>
        /// <remarks>
        /// Book Delete item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="204">No Content</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    _book.Delete(id);
                    return StatusCode(204, "No Content");
                }
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }
    }
}
