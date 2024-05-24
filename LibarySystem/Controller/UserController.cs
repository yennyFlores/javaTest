using LibarySystem.Model;
using LibarySystem.DataAccess;
namespace LibarySystem.Controller;


public class UserController
{

    public static User currentLoggedUser = new User();

    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);  

        Console.WriteLine($"User Profile {newUser.userName} created sucessfully!");
        SetCurrentUser(newUser);
        UserStorage.StoreUser(newUser);
    }

    
    public static bool UserExists(string userName)
    {
        if(UserStorage.FindUser(userName) != null)
        {
            return true;
        }
        return false;
    }

  
    public static User ReturnUser (string userName)
    {
        User existingUser = UserStorage.FindUser(userName);
        SetCurrentUser(existingUser);
        return existingUser;
    }

    public static void SetCurrentUser(User currentUser)
    {
         currentLoggedUser = currentUser;
    }

    public static User GetCurrentUser()
    {
        return currentLoggedUser;
    }

    public static string GetCurrentUserName()
    {
        return currentLoggedUser.userName;
    }

     public static Guid GetCurrentGuid()
    {
        return currentLoggedUser.userId;
    }

    

    

}
