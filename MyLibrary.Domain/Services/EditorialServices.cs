using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using MiLibrary.Domain.Dto.EditorialDto;
using MiLibrary.Domain.Services.Interface;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder 
        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<EditorialDto> GetAllEditorial()
        {
            var books = _unitOfWork.EditorialRepository.GetAll();
                                                        
                                                      


            List<EditorialDto> list = books.Select(x => new EditorialDto
            {
                Id = x.Id,
                Name = x.Name,
                Direction = x.Direction,

            }).ToList();

            return list;
        }
        public async Task<bool> InsertEditorialAsync(InsertEditorialDto data)
        {
            EditorialEntity dates = new EditorialEntity()
            {

                Name = data.Name,
                Direction = data.Direction
            };

            _unitOfWork.EditorialRepository.Insert(dates);
            return await _unitOfWork.Save() > 0;
        }
        public async Task<bool> UpdateEditorialAsync(EditorialDto data)
        {
            bool result = false;

            EditorialEntity editorial = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.Id == data.Id);
            if (editorial != null)
            {
                editorial.Name = data.Name;
                editorial.Direction = data.Direction;

                _unitOfWork.EditorialRepository.Update(editorial);
                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        public async Task<ResponseDto> DeleteEditorialAsync(int id)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.EditorialRepository.Delete(id);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente El Editorial";
            else
                response.Message = "Hubo un error al eliminar El Editorial, por favor vuelva a intentalo";

            return response;
        }

        #endregion

    }
}
