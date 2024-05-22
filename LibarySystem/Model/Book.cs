namespace LibarySystem.Model;

public class Book {
    
     public string title {get; set;}
     public string author {get; set;}
     public string genre {get; set;}

    public Book () {}

    public Book(string _title, string _author, string _genre){
        title = _title;
        author = _author;
        genre = _genre;
    }
    
}