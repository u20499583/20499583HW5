using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using _20499583HW5.Models;

namespace _20499583HW5.Services
{
    public class service
    {
        private static service instance;
        private String connectionString;

        public static service getInstance()
        {
            if (instance == null)
            {
                instance = new service();
            }
            return instance;
        }
        public int getCount()
        {
            List<BookBorrowsVM> borrows = new List<BookBorrowsVM>();
            int count = 0;
            foreach (BookBorrowsVM bookborrows in borrows )
            {
                
                count += 1;

            }
            return count;
        }
        public service()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        //GET AUTHORS FROM DATABASE
        public List<Author> getAuthors()
        {
            List<Author> authordata = new List<Author>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select * from authors", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Author author = new Author
                            {
                                AuthorID = Convert.ToInt32(reader["authorId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"])

                            };
                            authordata.Add(author);
                        }
                    }
                }
            }
            return authordata;
        }

        //GET BOOKS FROM DATABASE
        public List<Book> getBook()
        {
            List<Book> bookdata = new List<Book>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select * from books", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int authorID = (int)reader["authorId"];
                            int typeID = (int)reader["typeId"];
                            Book book = new Book
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToString(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                Author = getAuthorById(authorID),
                                Types = getTypeById(typeID)
                            };
                            bookdata.Add(book);
                        }
                    }
                }
            }

            return bookdata;
        }

        public List<BookBorrowsVM> getBorrowsOfBook(int bookID)
        {
            List<BookBorrowsVM> books = new List<BookBorrowsVM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from borrows where bookId = " + bookID, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = Convert.ToInt32(rdr["borrowId"]);
                            int studentID = Convert.ToInt32(rdr["studentId"]);
                            int bookId = Convert.ToInt32(rdr["bookId"]);
                            BookBorrowsVM bookBorrows = new BookBorrowsVM
                            {
                                BorrowID = getBorrowsById(id),
                                BorrowedBy= getStudentById(studentID),
                                BookId= getBookById(bookId),
                                TakenDate= (Borrows)(rdr["takenDate"]),
                                BroughtDate=(Borrows)(rdr["broughtDate"])

                            };
                            books.Add(bookBorrows);
                        }
                    }
                }
                connection.Close();
            }
            return books;
        }
        ////GET BORROWS FROM DATABASE
        public List<Borrows> getBorrows(){
            List<Borrows> borrowsdata = new List<Borrows>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select * from borrows", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentID = (int)reader["studentId"];
                            int bookID = (int)reader["bookId"];
                            Borrows borrows = new Borrows
                            {
                                BorrowID = Convert.ToInt32(reader["borrowId"]),
                                StudentID = getStudentById(studentID),
                                BookID = getBookById(bookID),
                                TakenDate = Convert.ToDateTime(reader["takenDate"]),
                                BroughtDate = Convert.ToDateTime(reader["broughtDate"]),
                                BookStaus= reader["broughtDate"]==DBNull.Value ? "Out":"Avaliable"
                                
                            };
                            borrowsdata.Add(borrows);
                        }
                    }
                }
            }
            return borrowsdata;
        }

            
            
        
        ////GET STUDENTS FROM DATABASE
        public List<Student> getStudentss()
        {
            List<Student> studentsdata = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("Select * from borrows", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentID = (int)reader["studentId"];
                            int bookID = (int)reader["bookId"];
                            Student student = new Student
                            {
                                StudentID = Convert.ToInt32(reader["studentId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),
                                BirthDate = Convert.ToString(reader["birthdate"]),
                                Gender = Convert.ToString(reader["gender"]),
                                Class = Convert.ToString(reader["class"]),
                                Point = Convert.ToInt32(reader["point"])
                            };
                            studentsdata.Add(student);
                        }
                    }
                }
            }

            return studentsdata;
        }
        ///////GET TYPES FROM DATABASE
        /////////////////////////////////////////METHODS///////////////////////////////////////////////////////
        public Author getAuthorById(int ID)
        {
            Author author = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from authors where authorId = " + ID, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            author = new Author
                            {
                                AuthorID = Convert.ToInt32(reader["authorId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"])

                            };
                        }
                    }
                }
                connection.Close();
            }
            return author;
        }

        public Borrows getBorrowsById(int ID)
        {
            Borrows borrows = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select * from borrows where borrowId = " + ID, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            borrows = new Borrows
                            {
                                BorrowID = Convert.ToInt32(reader["borrowId"]),
                               StudentID=(Student)(reader["studentId"]),
                               BookID= (Book)(reader["bookId"]),
                               TakenDate=Convert.ToDateTime(reader["takenDate"]),
                               BroughtDate=Convert.ToDateTime(reader["broughtDate"])

                            };
                            
                        }
                    }
                }
                connection.Close();
            }
            return borrows;
        }
        public Types getTypeById(int ID)//This methods fetches the Type by its ID from the Library database
        {
            Types types = null;
            using (SqlConnection connection = new SqlConnection(connectionString))//create a connection to the database
            {
                connection.Open();//open the connection
                using (SqlCommand command = new SqlCommand("select * from types where typeId = " + ID, connection))//Select everything from the type table whose Id matches the current ID
                {
                    using (SqlDataReader reader = command.ExecuteReader())//read the data
                    {
                        while (reader.Read())
                        {
                            types = new Types
                            {
                                TypeID = Convert.ToInt32(reader["typeId"]),
                                Name = Convert.ToString(reader["name"])

                            };
                        }
                    }
                }
                connection.Close();//then close connection
            }
            return types;//and return the types that were read
        }

        public Student getStudentById(int ID)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(connectionString))//create a connection to the database
            {
                connection.Open();//open the connection
                using (SqlCommand command = new SqlCommand("select * from students where studentId = " + ID, connection))//Select everything from the type table whose Id matches the current ID
                {
                    using (SqlDataReader reader = command.ExecuteReader())//read the data
                    {
                        while (reader.Read())
                        {
                            student = new Student
                            {
                                StudentID = Convert.ToInt32(reader["studentId"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),
                                BirthDate = Convert.ToString(reader["birthdate"]),
                                Gender = Convert.ToString(reader["gender"]),
                                Class = Convert.ToString(reader["class"]),
                                Point = Convert.ToInt32(reader["point"])

                            };
                        }
                    }
                }
                connection.Close();//then close connection
            }
            return student;

        }

        public Book getBookById(int ID)
        {
            Book book = null;
            using (SqlConnection connection = new SqlConnection(connectionString))//create a connection to the database
            {
                connection.Open();//open the connection
                using (SqlCommand command = new SqlCommand("select * from students where studentId = " + ID, connection))//Select everything from the type table whose Id matches the current ID
                {
                    using (SqlDataReader reader = command.ExecuteReader())//read the data
                    {
                        while (reader.Read())
                        {
                            book = new Book
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToString(reader["surname"]),
                                Point = Convert.ToInt32(reader["point"]),
                                Author = (Author)reader["authorId"],
                                Types = (Types)reader["typeId"]

                            };
                        }
                    }
                }
                connection.Close();//then close connection
            }
            return book;

        }
        public void BorrowBook()
        {

        }

        public void ReturnBook()
        {

        }


    }
}
