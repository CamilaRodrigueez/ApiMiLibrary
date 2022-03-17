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
            var books = _unitOfWork.BooksRepository.GetAll(p => p.AuthorbooksEntity.AuthorsEntity,
                                                        p => p.EditorialEntity,
                                                        p => p.TypeStateEntity
                                                        ).ToList();

            
            List<ConsultBooksDto> list = books.Select(x => new ConsultBooksDto
            {
                Id = x.Id,
                Title = x.Title,
                Gender = x.Gender,
                Pages = x.Pages,
                Synopsis = x.Synopsis,
                Editorial = x.EditorialEntity.Name,
                TypeState = x.TypeStateEntity.TypeState,
                Direction = x.EditorialEntity.Direction,
                NameAuthor=x.AuthorbooksEntity.AuthorsEntity.Name,
                IdEditorial = x.IdEditorial,
                IdAuthor = x.AuthorbooksEntity.IdAuthor,
                IdTypeState = x.IdTypeState,

            }).ToList();

            return list;
        }

        public ConsultBooksDto GetBook(int idBook)
        {
            var books = _unitOfWork.BooksRepository.First(x => x.Id == idBook,
                                                        p => p.AuthorbooksEntity.AuthorsEntity,
                                                        p => p.EditorialEntity,
                                                        p => p.TypeStateEntity);


            ConsultBooksDto booksDto = new ConsultBooksDto()
            {
                Id = books.Id,
                Title = books.Title,
                Gender = books.Gender,
                Pages= books.Pages,
                Synopsis = books.Synopsis,
                Editorial = books.EditorialEntity.Name,
                Direction = books.EditorialEntity.Direction,
                TypeState = books.TypeStateEntity.TypeState,
                NameAuthor = books.AuthorbooksEntity.AuthorsEntity.Name,
                IdEditorial=books.IdEditorial,
                IdAuthor=books.AuthorbooksEntity.IdAuthor,
                IdTypeState=books.IdTypeState,
            };

            return booksDto;
        }

        public List<TypeStateDto> GetAllTypeState()
        {
            var typeState = _unitOfWork.TypeStateRepository.GetAll();

            List<TypeStateDto> list = typeState.Select(x => new TypeStateDto
            { 
                IdTypeState=x.IdTypeState,
                TypeState=x.TypeState,

            }).ToList();

            return list;
        }
        public async Task<bool> InsertBooksAsync(InsertBooksDto data)
        {
            AuthorbooksEntity authorbooksEntity = new AuthorbooksEntity()
            {
                IdAuthor = data.IdAuthor,
                BooksEntity = new BooksEntity()
                {

                    Title = data.Title,
                    Gender = data.Gender,
                    Pages = data.Pages,
                    Synopsis=data.Synopsis,
                    IdEditorial = data.IdEditorial,
                    IdTypeState = data.IdTypeState,
                }
            };

            _unitOfWork.AuthorbooksRepository.Insert(authorbooksEntity);
            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> UpdateBooksAsync(BooksDto data)
        {
            bool result = false;

            BooksEntity books = _unitOfWork.BooksRepository.FirstOrDefault(x => x.Id == data.Id,
                                                                             x => x.AuthorbooksEntity);
                                                                                  
            if (books != null)
            {
                books.AuthorbooksEntity.IdAuthor = data.IdAuthor;
                books.Title = data.Title;
                books.Gender = data.Gender;
                books.Pages = data.Pages;
                books.Synopsis = data.Synopsis;
                books.IdEditorial = data.IdEditorial;
                books.IdTypeState = data.IdTypeState;
               


                _unitOfWork.BooksRepository.Update(books);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        public async Task<ResponseDto> DeleteBooksAsync(int id)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.BooksRepository.Delete(id);
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
