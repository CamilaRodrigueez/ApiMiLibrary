using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using MyLibrary.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services
{
    public class BooksServices : IBooksServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public BooksServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ConsultBooksDto> GetAllBooks()
        {
            var books = _unitOfWork.BooksRepository.GetAll(p => p.TypeStateEntity,
                                                        p => p.EditorialEntity
                                                        ).ToList();

            List<ConsultBooksDto> list = books.Select(x => new ConsultBooksDto
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                IdEditorial = x.IdEditorial,
                IdTypeState = x.IdTypeState,
                Editorial = x.EditorialEntity.Name,
                TypeState = x.TypeStateEntity.TypeState,
                Direction = x.EditorialEntity.Direction,

            }).ToList();



            return list;
        }

        public ConsultBooksDto GetBook(int idBook)
        {
            var books = _unitOfWork.BooksRepository.First(x => x.Id == idBook,
                                                        p => p.TypeStateEntity,
                                                        p => p.EditorialEntity);


            ConsultBooksDto booksDto = new ConsultBooksDto()
            {
                Id = books.Id,
                Name = books.Name,
                Gender = books.Gender,
                IdEditorial = books.IdEditorial,
                IdTypeState = books.IdTypeState,
                Editorial = books.EditorialEntity.Name,
                TypeState = books.TypeStateEntity.TypeState,
                Direction = books.EditorialEntity.Direction,
            };

            return booksDto;
        }

        public List<TypeStateEntity> GetAllTypeState() => _unitOfWork.TypeStateRepository.GetAll().ToList();
        public async Task<bool> InsertBooksAsync(InsertBooksDto data)
        {
            BooksEntity dates = new BooksEntity()
            {

                Name = data.Name,
                Gender = data.Gender,
                IdEditorial = data.IdEditorial,
                IdTypeState = data.IdTypeState,
            };

            _unitOfWork.BooksRepository.Insert(dates);
            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> UpdateBooksAsync(BooksDto data)
        {
            bool result = false;

            BooksEntity booksEntity = _unitOfWork.BooksRepository.FirstOrDefault(x => x.Id == data.Id);
            if (booksEntity != null)
            {
                booksEntity.Name = data.Name;
                booksEntity.Gender = data.Gender;
                booksEntity.IdEditorial = data.IdEditorial;
                booksEntity.IdTypeState = data.IdTypeState;


                _unitOfWork.BooksRepository.Update(booksEntity);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        public async Task<ResponseDto> DeleteBooksAsync(int idbook)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(idbook);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente El libro";
            else
                response.Message = "Hubo un error al eliminar El libro, por favor vuelva a intentalo";

            return response;
        }
        #endregion
    }
}
