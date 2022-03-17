using Infraestructure.Entity.Models.Library;
using MiLibrary.Domain.Dto.Authors;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiLibrary.Domain.Services.Interface
{
    public interface IAuthorsServices
    {
        List<ConsultAuthorsDto> GetAllAuthors();
        Task<bool> InsertAuthorAsync(InsertAuthorsDto data);
        Task<bool> UpdateAuthorAsync(AuthorsDto data);
        Task<ResponseDto> DeleteAuthorAsync(int id);

    }
}
