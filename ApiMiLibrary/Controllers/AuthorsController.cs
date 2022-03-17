using ApiMiLibrary.Handlers;
using Common.Utils.Enums;
using Common.Utils.Resorces;
using Infraestructure.Entity.Models.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiLibrary.Domain.Dto.Authors;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMiLibrary.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AuthorsController : ControllerBase
    {
        #region Attributes
        private readonly IAuthorsServices _authorsServices;
        #endregion

        #region Builder
        public AuthorsController(IAuthorsServices authorsServices)
        {
            _authorsServices = authorsServices;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Obtener Listado de Autores
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [CustomPermissionFilter(Enums.Permission.ConsultarAutores)]
        [HttpGet]
        [Route("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            List<ConsultAuthorsDto> list = _authorsServices.GetAllAuthors();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }

        /// <summary>
        /// Insertar nuevo Autor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertAuthor")]
        [CustomPermissionFilter(Enums.Permission.CrearAutores)]
        public async Task<IActionResult> InsertAuthor(InsertAuthorsDto dates)
        {
            IActionResult response;

            bool result = await _authorsServices.InsertAuthorAsync(dates);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Actualizar Datos de un Autor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateAuthor")]
        [CustomPermissionFilter(Enums.Permission.ActualizarAutores)]
        public async Task<IActionResult> UpdateAuthor(AuthorsDto data)
        {
            IActionResult response;

            bool result = await _authorsServices.UpdateAuthorAsync(data);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Eliminar un Autor
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteAuthor")]
        [CustomPermissionFilter(Enums.Permission.EliminarAutores)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            IActionResult response;
            ResponseDto result = await _authorsServices.DeleteAuthorAsync(id);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }
        #endregion
    }
}
