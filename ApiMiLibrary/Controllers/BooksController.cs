using ApiMiLibrary.Handlers;
using Common.Utils.Enums;
using Common.Utils.Resorces;
using Common.Utils.Utils;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using MyLibrary.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace ApiMiLibrary.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BooksController : ControllerBase
    {
        #region Attributes
        private readonly IBooksServices _booksServices;
        #endregion
        #region Builder
        public BooksController(IBooksServices booksServices)
        {
            _booksServices = booksServices;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtener Todos los Libros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllBooks")]
        [CustomPermissionFilter(Enums.Permission.ConsultarLibros)]
        public IActionResult GetAllBooks()
        {
            List<ConsultBooksDto> list = _booksServices.GetAllBooks();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }


        /// <summary>
        /// Obtener un libro
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetBook")]
        [CustomPermissionFilter(Enums.Permission.BuscarLibro)]
        public IActionResult GetBook(int idBook)
        {
            ConsultBooksDto result = _booksServices.GetBook(idBook);
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };

            return Ok(response);
        }


        /// <summary>
        /// Obtener listado de Estados de los Libros.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [CustomPermissionFilter(Enums.Permission.ConsultarEdtadoLibro)]
        [HttpGet]
        [Route("GetAllTypeState")]
        public IActionResult GetAllTypeState()
        {
            List<TypeStateEntity> result = _booksServices.GetAllTypeState();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        

        /// <summary>
        /// Insertar nuevo libro 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertBooks")]
        [CustomPermissionFilter(Enums.Permission.InsertarNuevoLibro)]
        public async Task<IActionResult> InsertBooks(InsertBooksDto dates)
        {
            IActionResult response;

            bool result = await _booksServices.InsertBooksAsync(dates);
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
        /// Actualizar Datos de Un Libro 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateBooks")]
        [CustomPermissionFilter(Enums.Permission.ActualizarDatosLibro)]
        public async Task<IActionResult> UpdateBooks(BooksDto data)
        {
            IActionResult response;

            bool result = await _booksServices.UpdateBooksAsync(data);
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
        /// Eliminar un Libro 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteBooks")]
        [CustomPermissionFilter(Enums.Permission.EliminarLibro)]
        public async Task<IActionResult> DeleteBooks(int idbook)
        {
            IActionResult response;
            ResponseDto result = await _booksServices.DeleteBooksAsync(idbook);

            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return Ok(response);
        }



        #endregion
    }
}
