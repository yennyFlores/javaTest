using LibarySystem.Model;
using LibarySystem.DataAccess;
using LibarySystem.ADO;
using System.Data.SqlClient;
namespace LibarySystem.Controller;

public class BookController
{
    /* public static void CreateBook(string name, string author, string genre ){
          Book newBook = new Book(name, author, genre );  
          Console.WriteLine($"Your Recommended Book {newBook.title} was submitted sucessfully!");
          BookStorage.StoreBook(newBook);

     }
     */

  public static List<Book> BookSearch(string userSearch ){
          Console.WriteLine($"Searching ...");
               string cmdText =
                    @"SELECT rank() over(order by title desc) as _index, barcode, title, author, genre FROM books " + userSearch;
          List<Book> returnBookSearch = new List<Book>();
          using SqlConnection connection = new SqlConnection(ADOconnect.ConnectionString());
          connection.Open();
          using SqlCommand cmd = new SqlCommand(cmdText, connection);
          using SqlDataReader reader = cmd.ExecuteReader();
          while(reader.Read()){
               //Console.WriteLine("pass");
               Book book = new Book( Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), reader.GetString(2), reader.GetString(3), reader.GetString(4));
               returnBookSearch.Add(book);
          }
          return returnBookSearch;
     }
}