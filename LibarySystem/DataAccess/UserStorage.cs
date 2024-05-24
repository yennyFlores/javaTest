using LibarySystem.Model;
using System.Text.Json;
namespace LibarySystem.DataAccess;

public class UserStorage 
{
 
    public static string filePath = "UsersFile.json";
    


    public static void StoreUser(User user)
    {   
       
        if(File.Exists(filePath))
        {
            
            string existingUsersJson = File.ReadAllText(filePath);

            //Once you get the string from the file, THEN you can deserialize it.
            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);
            

            //Once we deserialize our exisitng JSON text from the file into a new List<User> object
            //We will then simply add it to the list, using the Add() method
            existingUsersList.Add(user);

            //Here we will serialize our list of users, into a JSON text string
            string jsonExistingUsersListString = JsonSerializer.Serialize(existingUsersList);

            //Now we will store our jsonUsersString to our file
            File.WriteAllText(filePath, jsonExistingUsersListString);

        }
        else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
        {
            //Creating a blank list to use later
            List<User> initialUsersList = new List<User>();

            //Adding our user to our list, PRIOR to serializing it
            initialUsersList.Add(user);

            //Here we will serialize our list of users, into a JSON text string
            string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);

            //Now we will store our jsonUsersString to our file
            File.WriteAllText(filePath, jsonUsersListString);
        }

    }


    public static User FindUser(string usernameToFind)
    {
        //User object to store a user if they are found or NULL if they are not
        User foundUser = new User();

        try{

            //First, read the string back from our .json file
            string existingUsersJson = File.ReadAllText(filePath);

            //Then, we need to serialize the string back into a List of User objects
            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

            //Then, we need to check if there is a user object with the given username 
            //that came in as an argument when the method was called inside of our list
            //To do this we are going to use a LINQ method to query our collection called FirstOrDefault()
            //Inside the parenthesis is a lambda method or anonymous function 
            //Lambda expressions have the same basic syntax ((parameters) => expression_or_statement_block)

            //This => is called the lambda operator - so it is not actually functioning as any sort of 
            //comparator 

            //To the left of the => (lambda operator) is the input to our anonymous function or method
            //To the right, is the code that will be executed or evaluated against when the lambda runs
            foundUser = existingUsersList.FirstOrDefault(user => user.userName == usernameToFind);

            //The above lambda function is essentially iterating through and querying the list for us, 
            //as if we were doing the foreach loop below
            // foreach (User user in existingUsersList){
            //     if(user.userName == usernameToFind)
            //     {
            //         return user;
            //     }
            // }

            //If it exists, return that user
            

            //If it doesn't... do something else 


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
      
        return foundUser;

    }

}
