using LibarySystem; //mispelled library 

namespace LibarySystem.Exceptions_Validations;

class MenuSelectionError : Exception
{
    public MenuSelectionError(string message) : base(message)
    {
        // return Menu.StartMenu();
         
    }
}
