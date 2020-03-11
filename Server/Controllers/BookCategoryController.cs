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
using Server.Models.BookCategory;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/BookCategory")]
    public class BookCategoryController : Controller
    {
        private ILogger<BookCategoryController> _logger;

        private readonly IBookCategory _book_category;

        public BookCategoryController(IBookCategory book_category)
        {
            _book_category = book_category;
        }

        /// <summary>
        /// BookCategory get all data
        /// </summary>
        /// <remarks>
        /// BookCategory get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(List<BookCategoryViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _book_category.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// BookCategory get By Id
        /// </summary>
        /// <remarks>
        /// BookCategory get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<BookCategoryViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _book_category.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// BookCategory create item
        /// </summary>
        /// <remarks>
        /// BookCategory create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="409">Conflict</response>  
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<BookCategoryViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Create([FromBody] BookCategoryEntity model)
        {
            try
            {
                if (model != null)
                {
                    var x = _book_category.Create(model);
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
        /// BookCategory Update item
        /// </summary>
        /// <remarks>
        /// BookCategory Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<BookCategoryViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update(Guid id, [FromBody] BookCategoryEntity model)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _book_category.Update(id, model);
                    return Json(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// BookCategory Update item
        /// </summary>
        /// <remarks>
        /// BookCategory Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<BookCategoryViewModel>), 200)]
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
                    var res = _book_category.Delete(id);
                    return Json(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }
    }
}
