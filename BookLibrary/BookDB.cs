using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Interacts with the Books table in the Library DB and Book objects
    /// </summary>
    static class BookDB
    {
        /// <summary>
        /// Generates a list of Book objects from all the columns from the Books table
        /// </summary>
        /// <returns>a list of Book objects in all the colums of the Books table</returns>
        public static List<Book> GetAllBooks()
        {
            SqlCommand selCmd = new SqlCommand
            {
                CommandText =
                "SELECT ISBN, Price, Title "
                + "FROM Book"
            };

            using (selCmd.Connection = DBHelper.GetConnection())
            {
                selCmd.Connection.Open();
                SqlDataReader rdr = selCmd.ExecuteReader();
                List<Book> bookList = new List<Book>();

                while (rdr.Read())
                {
                    Book currBook = new Book
                    {
                        ISBN = (string)rdr["ISBN"],
                        Price = (decimal)rdr["Price"],
                        Title = (string)rdr["Title"]
                    };

                    bookList.Add(currBook);
                }

                return bookList;
            }
        }

        /// <summary>
        /// Accepts a Book object parameter that is added to the Books table in the DB
        /// </summary>
        /// <param name="currBook">The book to be added to the books table in the DB</param>
        /// <returns>bool returns true if add operation is succesful</returns>
        public static bool Add(Book currBook)
        {
            SqlCommand addCmd = new SqlCommand
            {
                CommandText =
                "INSERT INTO Book (ISBN, Price, Title) "
                + "VALUES (@isbn, @price, @title)"
            };

            addCmd.Parameters.AddWithValue("@isbn", currBook.ISBN);
            addCmd.Parameters.AddWithValue("@price", currBook.Price);
            addCmd.Parameters.AddWithValue("@title", currBook.Title);

            using (addCmd.Connection = DBHelper.GetConnection())
            {
                addCmd.Connection.Open();
                int rowsAffected = addCmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Accepts a book object parameter that updates the book table based on
        /// the ISBN primary key
        /// </summary>
        /// <param name="currBook">Represents the book to updated in the Books table</param>
        /// <returns>bool returns true if update operation is succesful</returns>
        public static bool Update(Book currBook)
        {
            SqlCommand updateCmd = new SqlCommand
            {
                CommandText =
                "UPDATE Book "
                + "SET Price = @price, Title = @title "
                + "WHERE ISBN = @isbn"
            };

            updateCmd.Parameters.AddWithValue("@isbn", currBook.ISBN);
            updateCmd.Parameters.AddWithValue("@price", currBook.Price);
            updateCmd.Parameters.AddWithValue("@title", currBook.Title);

            using (updateCmd.Connection = DBHelper.GetConnection())
            {
                updateCmd.Connection.Open();
                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Accepts a Book object that is to be deleted from the Book table
        /// </summary>
        /// <param name="currBook">The book the will be deleted from the Book table</param>
        /// <returns>bool returns true if delete operation is succesful</returns>
        public static bool Delete(Book currBook)
        {
            SqlCommand deleteCmd = new SqlCommand
            {
                CommandText =
                "DELETE Book "
                + "WHERE ISBN = @isbn"
            };

            deleteCmd.Parameters.AddWithValue("@isbn", currBook.ISBN);

            using (deleteCmd.Connection = DBHelper.GetConnection())
            {
                deleteCmd.Connection.Open();
                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
