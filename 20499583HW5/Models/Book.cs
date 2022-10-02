using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20499583HW5.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public String Name { get; set; }
        public String PageCount { get; set; }
        public int Point { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Author>Authors { get; set; }
        public Types Types { get; set; }
        public IEnumerable<Types> Typess { get; set; }
        public Borrows Borrow { get; set; }

        public IEnumerable<Borrows> Borrows  { get; set; }


    }
}