using LibarySystem.Model;
using LibarySystem.DataAccess;
namespace LibarySystem.Controller;


public class UserController
{
    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);  

        Console.WriteLine($"User Profile {newUser.userName} created sucessfully!");
        UserStorage.StoreUser(newUser);
    }

    
    public static bool UserExists(string userName)
    {
        return false;
    }

    

}
