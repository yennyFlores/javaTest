using LibarySystem.Model;
using LibarySystem.DataAccess;
namespace LibarySystem.Controller;

public class BookController
{
     public static void CreateBook(string name, string author, string genre ){
          Book newBook = new Book(name, author, genre );  
          Console.WriteLine($"Your Recommended Book {newBook.name} was submitted sucessfully!");
          BookStorage.StoreBook(newBook);

     }
}