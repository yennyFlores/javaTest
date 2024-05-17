namespace LibarySystem.Model;

public class Book {
    
     string name {get; set;}
     string author {get; set;}
     string genre {get; set;}
     int barcode {get; set;}

    public Book () {}

    public Book(string _name, string _author, string _genre, int _barcode){
        name = _name;
        author = _author;
        genre = _genre;
        barcode = _barcode;
    }
    
}