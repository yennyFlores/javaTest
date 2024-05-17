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
        
        switch ( MenuOneSelection("Welcome to the Library!"))
        {
            case 0:
                break;
            case 1:
                //string userName = MenuUserLogin(); 
                //ScreenTwo();
                break;
            case 2:
                string userName = MenuUserCreation();
                ScreenTwo(userName);
                break;
                
        };

    }

      public static void ScreenTwo(string userName) {
        
        switch ( MenuTwoSelection(string.Format("Welcome Back {0} to the library.", userName)))
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
                           
                   
                
        };

    }
     

    
    public static int MenuOneSelection(string message) {
            
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
            return Convert.ToInt16(stringSelection);
            
    }

     public static int MenuTwoSelection(string message) {
            
            Console.WriteLine(@"
            {0}
            Menu Option   
            0 - Logout & Exit
            1 - View Currently Checked out Books
            2 - Search by Genre
            3 - Search Top Books
            4 - Search by Name or Author or Barcode 
            5 - View Selected Cart for Checkout
            6 - Checkin Books
             ", message );
            string stringSelection = Console.ReadLine();
            int intSelection;
            if( int.TryParse(stringSelection, out intSelection) == false){
               MenuTwoSelection(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));
            } 
            if (intSelection < 0 || intSelection > 6) {
               MenuTwoSelection(string.Format("Your entry {0} is not a valid option number. Please enter valid options 0 to 6", stringSelection));
            } 
            return  Convert.ToInt16(stringSelection);;
            
    }

     public static string MenuUserCreation() {
            Console.WriteLine("Please enter a username: ");
            string userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username {0} cannot be blank, please try again.", userInput);
                MenuUserCreation();
            }/*else if(UserController.UserExists(userInput))
            {
               Console.WriteLine("Username {0} already exists, please choose another.", userInput);
                MenuUserCreation();
             }*/ else { 
                UserController.CreateUser(userInput);
            }
            return userInput;
     }

      //public static void MenuUserLogin() {

     //     MenuSelectionTwo("Congrats {0}, Welcome Back", userInput);
     //}

}

//UI
//Models
//Controllers
//Data Access Control
//Validations
//Exceptions


                          //Welcome screen
             //Menu Option  
             //0 - Exit
             //1 - Login
             //2 - Create Account

             //User Screen
           // Menu Option  
           //  0 - Logout & Exit
           //  1 - View Currently Checked out Books
           //  2 - Search by Genre
           //  3 - Search Top Books
           //  4 - Search by Name or Author or Barcode 
           //  5 - View Selected Cart for Checkout
           //  6 - Checkin Books" );