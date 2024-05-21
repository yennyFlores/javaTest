namespace LibarySystem.Model;

public class Book {
    
     public string name {get; set;}
     public string author {get; set;}
     public string genre {get; set;}

    public Book () {}

    public Book(string _name, string _author, string _genre){
        name = _name;
        author = _author;
        genre = _genre;
    }
    
}