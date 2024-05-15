using LibarySystem;

namespace LibarySystem.Exceptions_Validations;

class MenuSelectionError : Exception
{
    public MenuSelectionError(string message) : base(message)
    {
    }
}
