using LibarySystem.Model;

namespace LibarySystem.Controller;

public class UserController
{
    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);

        //Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
        //Console.WriteLine($"{newUser.userId}");
    }

    
    public static bool UserExists(string userName)
    {
        return false;
    }

    

}