namespace LibarySystem.Model;

public class User
{
   
    public Guid userId {get; private set;}
    public string userName {get; private set;}

    public User() {}

    //This constructor takes two arguments
    public User(string _userName){
        userId = Guid.NewGuid();
        userName = _userName;
    }


}