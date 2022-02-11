using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Domain.Dto.Books
{
    public class InsertBooksDto
    {
        public string Name { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }
        public int IdEditorial { get; set; }

        public int IdTypeState { get; set; }
    }
}
