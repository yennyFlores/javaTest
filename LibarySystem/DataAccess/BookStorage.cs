using LibarySystem.Model;
using LibarySystem.Exceptions_Validations;
using System.Text.Json;
namespace LibarySystem.DataAccess;

public class BookStorage 
{
    public static string filePath = "BooksFile.json";

    public static void StoreBook(Book book)
    {   
       
        if(File.Exists(filePath))
        {
            string existingBooksJson = File.ReadAllText(filePath);
            List<Book> existingBooksList = JsonSerializer.Deserialize<List<Book>>(existingBooksJson);
            existingBooksList.Add(book);
            string jsonexistingBooksJsonString = JsonSerializer.Serialize(existingBooksList);
            File.WriteAllText(filePath, jsonexistingBooksJsonString);

        }
        else if (!File.Exists(filePath)) 
        {
            List<Book> intialBookList = new List<Book>();
            intialBookList.Add(book);    
            string jsonBookListString = JsonSerializer.Serialize(intialBookList);
            File.WriteAllText(filePath, jsonBookListString);
        }

    }
}