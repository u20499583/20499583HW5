using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20499583HW5.Models
{
    public class Borrows
    {
        public int BorrowID { get; set; }
        public Student StudentID { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Book BookID { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public DateTime ?TakenDate { get; set; }
        public DateTime? BroughtDate { get; set; }

        public String BookStaus { get; set; }

    }
}