using Infraestructure.Entity.Models.Library;
using MiLibrary.Domain.Dto.EditorialDto;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        List<EditorialEntity> GetAllEditorial();
        Task<bool> InsertEditorialAsync(InsertEditorialDto data);
        Task<bool> UpdateEditorialAsync(EditorialDto data);
        Task<ResponseDto> DeleteEditorialAsync(int id);

    }
}
