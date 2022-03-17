using ApiMiLibrary.Handlers;
using Common.Utils.Enums;
using Common.Utils.Resorces;
using Infraestructure.Entity.Models.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UsersController : ControllerBase
    {
        #region Attribute
        private readonly IUserServices _userServices;
        #endregion

        #region Builder
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion
        /// <summary>
        /// Obtener Listado de Usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [CustomPermissionFilter(Enums.Permission.ConsultarUsuarios)]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<UserDto> result = _userServices.GetAllUsers();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }
       
        


     
    }
}
