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
        int input = MenuOneSelection("Welcome to the Library!");
        switch (input )
        {
            case 0: //Exit
                break;
            case 1: //Login
                string userName1 = MenuUserLogin("Please enter your login username:"); 
                ScreenTwo(userName1);
                break;
            case 2: //Create Account
                string userName2 = MenuUserCreation("Please enter a new username:");
                ScreenTwo(userName2);
                break;
                
        };

    }

      public static void ScreenTwo(string userName) {
        
        switch ( MenuTwoSelection(string.Format("Welcome Back {0} to the library.", userName)))
        {
            case 0: //Logout & Exit
               //LogoutUser();
               //ScreenOne();
                break;
            case 1: 
                MenuBookCreation();
                break;
            case 2: //Search by Name,Author,Barcode,Genre
                break;
            case 3: //View Selected Cart for Checkout
                break;
            case 4: //Checkin Books
                break;
            case 5: //Checkin Books
                break;
            case 6: //Checkin Books
                break;
                        
        };

    }
     

    public static int MenuOneSelection(string message) {
            
           /*if(int.TryParse(message, out int goodSelection) == true){
                Console.WriteLine("here Again " +goodSelection);
                return goodSelection;
                
            }
            */
            Console.WriteLine(@"
            {0}
            Menu Option  
             0 - Exit
             1 - Login
             2 - Create Account
             ", message );
           string stringSelection = Console.ReadLine();
           int intSelection;
           if( int.TryParse(stringSelection, out intSelection) == false){
                //throw new MenuSelectionError(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
               MenuOneSelection(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
            } else if (intSelection < 0 || intSelection > 2) {
               MenuOneSelection(string.Format("Your entry {0} is not a valid option number. Please enter valid option 0, 1, or 2", intSelection));
            }
            //return  MenuOneSelection(string.Format("{0}", intSelection));
            return intSelection;
    }

    /*
    public static int MenuOneSelection() {
            
            
            Console.WriteLine(@"
            {0}
            Menu Option  
             0 - Exit
             1 - Login
             2 - Create Account
             ", message );
           string stringSelection = Console.ReadLine();
           int intSelection;
           if( int.TryParse(stringSelection, out intSelection) == false){
                //throw new MenuSelectionError(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
                Console.WriteLine("error entry");
               MenuOneSelection();
            } else if (intSelection < 0 || intSelection > 2) {
                      Console.WriteLine("error options");
               MenuOneSelection();
            }
            return intSelection;

    }
    */

     public static int MenuTwoSelection(string message) {
            
            Console.WriteLine(@"
            {0}
            Menu Option   
            0 - Logout & Exit
            1 - Submit a Recommended Book
            2 - View Currently Checked out Books
            3 - Search by Name, Author, Barcode, Genre
            4 - View Selected Cart for Checkout
            5 - Checkin Books
             ", message );
            string stringSelection = Console.ReadLine();
            int intSelection;

            if( int.TryParse(stringSelection, out intSelection) == false){
               MenuTwoSelection(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
            } else if (intSelection < 0 || intSelection > 6) {
               MenuTwoSelection(string.Format("Your entry {0} is not a valid option number. Please enter valid options 0 to 5", stringSelection));
            } 

            return intSelection;
            
    }

     public static string MenuUserCreation(string message) {

            Console.WriteLine("{0}", message);
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                MenuUserCreation("Username cannot be blank. Please enter another username: ");
            }else if(UserController.UserExists(userInput))
            {
                MenuUserCreation(string.Format("Username {0} already exists. Please try another username:", userInput));
            } else { 
                UserController.CreateUser(userInput);
            }

            return userInput;
     }

      public static string MenuUserLogin(string message) {
            Console.WriteLine("{0}", message );
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                MenuUserLogin("Username cannot be blank. Please enter another username: ");
            }else if(!UserController.UserExists(userInput))
            {
                MenuUserLogin(string.Format("Username {0} does not exist. Please try another username:", userInput));
             } else { 
                //Console.WriteLine("here hi:{0}", userInput );
                UserController.ReturnUser(userInput);
            }
            return userInput;
     }

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
            }*/



     }

}

