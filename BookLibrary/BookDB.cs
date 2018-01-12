using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    static class BookDB
    {
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


    }
}
