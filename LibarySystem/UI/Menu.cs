using LibarySystem.Model;
using LibarySystem.Controller;
using LibarySystem.Exceptions_Validations;

namespace LibarySystem;


class Menu
{
    static void Main(string[] args)
    {
        ScreenOne();
    } 
    
    public static void ScreenOne() {
        
        switch (MenuOneSelection() )
        {
            case 0: //Exit
                break;
            case 1: //Login
                MenuUserLogin(); 
                ScreenTwo();
                break;
            case 2: //Create Account
                MenuUserCreation();
                ScreenTwo();
                break;
                
        };

    }

      public static void ScreenTwo() {
        
        switch ( MenuTwoSelection())
        {
            case 0: //Logout & Exit
               ScreenOne();
                break;
            case 1: 
                BookSearchSelection();
                break;
            case 2: //View Currently Checkout Books
                //CheckedOutBooks();
                break;
            case 3: // Search by Book or Author [add to cart option for each login session] 
  
                break;
            case 4: //view checkout cart
                //CurrentCheckedOutCart();
                break;
            case 5: //Checkin Books
                //CheckinBooks();
                break;
                        
        };

    }
     

    public static int MenuOneSelection() {
            Console.WriteLine(@"
            Welcome to the Library!
            Menu Option  
             0 - Exit
             1 - Login
             2 - Create Account
             " );
           string stringSelection = Console.ReadLine() ?? "";
           int intSelection;
           if( int.TryParse(stringSelection, out intSelection) == false){
                //throw new MenuSelectionError(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
               Console.WriteLine("Your entry {0} is not a valid number. Please enter valid number", stringSelection);
               MenuOneSelection();
            } else if (intSelection < 0 || intSelection > 2) {
               Console.WriteLine("Your entry {0} is not a valid option number. Please enter valid option 0, 1, or 2", intSelection);
               MenuOneSelection();
            }
            return intSelection;
    }

     public static int MenuTwoSelection() {
           
            Console.WriteLine(@"
            Welcome Back {0} to the library!
            Menu Option   
            0 - Logout
            1 - Search by Title
            2 - View Selected Cart for Checkout 
            3 - View Currently Checked out Books
            4 - Checkin Books
             " , UserController.GetCurrentUserName());
            string stringSelection = Console.ReadLine() ?? "";
            int intSelection;

            if( int.TryParse(stringSelection, out intSelection) == false){
               Console.WriteLine("Your entry {0} is not a valid number. Please enter valid number", stringSelection);
               MenuTwoSelection();
            } else if (intSelection < 0 || intSelection > 4) {
               Console.WriteLine("Your entry {0} is not a valid option number. Please enter valid options 0 to 4", stringSelection);
               MenuTwoSelection();
            } 

            return intSelection;
            
    }

     public static string MenuUserCreation() {

            Console.WriteLine("Please enter a Username");
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank. Please enter another username: ");
                MenuUserCreation();
            }else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username {0} already exists. Please try another username:", userInput);
                MenuUserCreation();
            } else { 
                UserController.CreateUser(userInput);
            }

            return userInput;
     }

      public static string MenuUserLogin() {
            Console.WriteLine("Please enter your login username:" );
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank. Please enter another username: ");
                MenuUserLogin();
            }else if(!UserController.UserExists(userInput))
            {
                Console.WriteLine("Username {0} does not exist. Please try another username:", userInput);
                MenuUserLogin();
             } else { 
                UserController.ReturnUser(userInput);
            }
            return userInput;
     }

/*
     public static void MenuBookCreation() {

            Console.WriteLine("Please enter your recommened book name:");
            string bookName = Console.ReadLine() ?? "";
            bookName = bookName.Trim();

            Console.WriteLine("Please enter your recommened book author:");
            string author = Console.ReadLine() ?? "";
            author = author.Trim();

            Console.WriteLine("Please enter your recommened book genre:");
            string genre = Console.ReadLine() ?? "";
            genre = genre.Trim();

            BookController.CreateBook(bookName, author, genre);
            /*if(String.IsNullOrEmpty(bookName))
            {
                MenuUserCreation("Username cannot be blank. Please enter another username: ");
            } else if(UserController.UserExists(bookName))
            {
                MenuUserCreation(string.Format("Username {0} already exists. Please try another username:", userInput));
            } else { 
                UserController.CreateUser(userInput);
            }

     }
*/
     public static void BookSearchSelection(){
        Console.WriteLine("Please enter your book search by Title:");
        string[] inputs = Console.ReadLine().Split(' ');

        List<string> inputsCleaned = new List<String>();
        for(int i = 0; i < inputs.Length; i++){
            if(inputs[i].ToLower() != "the" && inputs[i].ToLower() != "of" && inputs[i].ToLower() != "be" && inputs[i].ToLower() != "to" && inputs[i].ToLower() != "and" && inputs[i].ToLower() != "a" && inputs[i].ToLower() != "an" && inputs[i].ToLower() != "i"  ){
          
                Console.WriteLine(inputs[i].ToLower());
                inputsCleaned.Add(inputs[i].ToLower());
            }
        }

        string whereClause = "";
        for(int i = 0; i < inputsCleaned.Count; i++){
                if (i == 0) {
                whereClause += "where title like '%" + inputsCleaned[i] + "%' ";
                } else if(i == inputsCleaned.Count-1){
                whereClause += "or title like '%" + inputsCleaned[i] + "%' ";
                } else {
                whereClause += "or title like '%" + inputsCleaned[i] + "%' ";
                }
        }
        Console.WriteLine(whereClause);
        
        List<Book> bookResultList= BookController.BookSearch(whereClause);
     
        if(bookResultList.Count > 0){
             Console.WriteLine(@"Results: Please select a book to add to cart ");
            foreach(Book book in bookResultList ){
               
                Console.WriteLine(@"" + book.index + " Title: " + book.title + " Author: " + book.author );
            }
            
            string stringSelection = Console.ReadLine() ?? "";
            int intSelection = Convert.ToInt16(stringSelection);
            
            /*
            if( int.TryParse(stringSelection, out intSelection) == false){
               Console.WriteLine("Your entry {0} is not a valid number. Please enter valid number", stringSelection);
            } else if (intSelection < 0 || intSelection > 4) {
               Console.WriteLine("Your entry {0} is not a valid option number. Please enter valid options 0 to 4", stringSelection);
            } 
            */

           
            foreach(Book book in bookResultList ){
                if(intSelection == book.index ) {
                    //Add to cart method, as a list? 
                     Console.WriteLine(@"Added to CART" + book.index + " Title: " + book.title + " Author: " + book.author + "" );
                }
               
            }
            

            


            

        } else {
            Console.WriteLine(@"Results: Sorry. No books match critera. Returning to Main Menu ");
            MenuTwoSelection();
        }
     }

}

