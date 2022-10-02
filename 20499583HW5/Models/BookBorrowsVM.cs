using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20499583HW5.Models
{
    public class BookBorrowsVM
    {
        public Book BookId { get; set; }
        public Borrows BorrowID { get; set; }
        public Borrows TakenDate { get; set; }

        public Borrows BroughtDate { get; set; }

        public Student BorrowedBy { get; set; }


    }
}