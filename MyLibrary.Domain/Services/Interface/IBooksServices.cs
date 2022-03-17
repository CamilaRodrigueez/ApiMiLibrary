using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Dto.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services.Interface
{
    public interface IBooksServices
    {
        List<ConsultBooksDto> GetAllBooks();
        ConsultBooksDto GetBook(int idBook);
        List<TypeStateDto> GetAllTypeState();
        Task<bool> InsertBooksAsync(InsertBooksDto data);
        Task<bool> UpdateBooksAsync(BooksDto data);
        Task<ResponseDto> DeleteBooksAsync(int idbook);
    }
}
