using Domain.General;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contactbook.API.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]/[action]", Name = "[controller]_[action]")]
    public abstract class BaseController<TRepository, TEntity> : ControllerBase
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly TRepository _repository;
        private readonly ILogger<BaseController<TRepository, TEntity>> _logger;

        protected BaseController(TRepository repository, ILogger<BaseController<TRepository, TEntity>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<TEntity>>>> GetAll([FromQuery] Paging paging)
        {
            try
            {
                var result = await _repository.GetAsync(paging, null, null);
                if (result == null)
                {
                    return StatusCode(404);
                }

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                    $"Error");
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<TEntity>>> Get([FromQuery] string id)
        {
            try
            {
                var result = await _repository.GetById(id);
                if (result == null)
                {
                    return StatusCode(404);
                }

                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                        $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                        $"Error");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<ApiResponse<TEntity>>> Add([FromBody] TEntity user)
        {
            try
            {
                var result = await _repository.AddAsync(user);

                if (result == null)
                {
                    return StatusCode(404);
                }

                return StatusCode(202, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                         $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                         $"Error");
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<ApiResponse<TEntity>>> Update([FromBody] TEntity entity, [FromQuery] string id)
        {
            try
            {
                var result = await _repository.UpdateAsync(entity, id);
                if (result == null)
                {
                    return StatusCode(400);
                }
                return StatusCode(200, result);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                         $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                         $"Error");
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse<TEntity>>> Delete([FromQuery] string id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                if (result)
                {
                    return StatusCode(200);
                }

                return StatusCode(400, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                     $"{ControllerContext.RouteData.Values["controller"].ToString()} - {ControllerContext.RouteData.Values["action"].ToString()}" +
                     $"Error");
                return StatusCode(500, ex);
            }
        }
    }
}