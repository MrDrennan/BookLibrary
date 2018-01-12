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
    }
}
