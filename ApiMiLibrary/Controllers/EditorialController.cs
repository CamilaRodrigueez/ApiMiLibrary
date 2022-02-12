using ApiMiLibrary.Handlers;
using Common.Utils.Enums;
using Common.Utils.Resorces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiLibrary.Domain.Dto.EditorialDto;
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
    public class EditorialController : ControllerBase
    {
        #region Attributes
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Builder
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion

        #region Methods
      
        /// <summary>
        /// Insertar nuevo Editorial
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertEditorial")]
        [CustomPermissionFilter(Enums.Permission.InsertarEditorial)]
        public async Task<IActionResult> InsertEditorial(InsertEditorialDto dates)
        {
            IActionResult response;

            bool result = await _editorialServices.InsertEditorialAsync(dates);
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
        /// Actualizar Editorial
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateEditorial")]
        [CustomPermissionFilter(Enums.Permission.ActualizarEditorial)]
        public async Task<IActionResult> UpdateEditorial(EditorialDto data)
        {
            IActionResult response;

            bool result = await _editorialServices.UpdateEditorialAsync(data);
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
        /// Eliminar un Editorial
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteEditorial")]
        [CustomPermissionFilter(Enums.Permission.EliminarEditorial)]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            IActionResult response;
            ResponseDto result = await _editorialServices.DeleteEditorialAsync(id);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }
        #endregion
    }
}
