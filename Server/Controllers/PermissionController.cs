﻿using System;
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
using Server.Models.Permission;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/Permission")]
    public class PermissionController : Controller
    {
        private ILogger<PermissionController> _logger;

        private readonly IPermission _permission;

        public PermissionController(IPermission permission)
        {
            _permission = permission;
        }

        /// <summary>
        /// Permission get all data
        /// </summary>
        /// <remarks>
        /// Permission get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(List<PermissionViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _permission.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Permission get By Id
        /// </summary>
        /// <remarks>
        /// Permission get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<PermissionViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _permission.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Permission create item
        /// </summary>
        /// <remarks>
        /// Permission create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="409">Conflict</response>  
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<PermissionViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Create([FromBody] PermissionEntity model)
        {
            try
            {
                if (model != null)
                {
                    var x = _permission.Create(model);
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
        /// Permission Update item
        /// </summary>
        /// <remarks>
        /// Permission Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<PermissionViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update(Guid id, [FromBody] PermissionEntity model)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _permission.Update(id, model);
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
        /// Permission Update item
        /// </summary>
        /// <remarks>
        /// Permission Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<PermissionViewModel>), 200)]
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
                    var res = _permission.Delete(id);
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
