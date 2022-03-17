using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using MiLibrary.Domain.Dto.Authors;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder 
        public AuthorsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<ConsultAuthorsDto> GetAllAuthors()
        {
            var authors = _unitOfWork.AuthorsRepository.GetAll();


            List<ConsultAuthorsDto> list = authors.Select(x => new ConsultAuthorsDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
            }).ToList();



            return list;
        }

        public async Task<bool> InsertAuthorAsync(InsertAuthorsDto data)
        {
            AuthorsEntity dates = new AuthorsEntity()
            {

                Name = data.Name,
                LastName = data.LastName
            };

            _unitOfWork.AuthorsRepository.Insert(dates);
            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> UpdateAuthorAsync(AuthorsDto data)
        {
            bool result = false;

            AuthorsEntity authors = _unitOfWork.AuthorsRepository.FirstOrDefault(x => x.Id == data.Id);
            if (authors != null)
            {
                authors.Name = data.Name;
                authors.LastName=data.LastName;

                _unitOfWork.AuthorsRepository.Update(authors);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        public async Task<ResponseDto> DeleteAuthorAsync(int id)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.AuthorsRepository.Delete(id);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente El Autor";
            else
                response.Message = "Hubo un error al eliminar El Author, por favor vuelva a intentalo";

            return response;
        }
        #endregion
    }
}
