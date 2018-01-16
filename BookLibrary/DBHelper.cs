using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    /// <summary>
    /// Responsible for general interactions with the Library database
    /// </summary>
    static class DBHelper
    {
        /// <summary>
        /// returns a connection to the Library database
        /// </summary>
        /// <returns>SqlConnection object for the desired database</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost;Initial Catalog=LibraryDB;Integrated Security=True");
        }
    }
}
