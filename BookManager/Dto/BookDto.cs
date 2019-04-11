using BookManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Dto
{
    public class BookDto : SimpleBookDto
    {
        public Genre Genre { get; set; }
    }
}
