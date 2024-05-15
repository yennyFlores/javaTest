using LibarySystem.Model;
using LibarySystem.Exceptions_Validations;
namespace LibarySystem;


class Menu
{
    static void Main(string[] args)
    {
       
        bool repeat_selection = true;
        while(repeat_selection)
        {

            Console.WriteLine(@"
            Menu Option  
             0 - Exit
             1 - Login
             2 - Create Account
             " );

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

           
           
            string stringSelection = Console.ReadLine();
            int intSelection;
            if( int.TryParse(stringSelection, out intSelection) == false){
                
                throw new MenuSelectionError(string.Format("Your entry {0} is not a valid number. Please enter valid number", stringSelection));

            }
            
           // int intSelection = Convert.ToInt16(stringSelection);
            
            
            switch (intSelection)
            {
                case 0:
                    repeat_selection = false;
                    break;
                case 1:
                    

                    break;
               // case 2:

                    
            };
        } 

    }
}

//UI
//Models
//Controllers
//Data Access Control
//Validations
//Exceptions