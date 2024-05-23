using LibarySystem.Model;
using LibarySystem.DataAccess;
using LibarySystem.ADO;
using System.Data.SqlClient;
namespace LibarySystem.Controller;


public class BookController
{
  public static List<Book> cart = new List<Book>();
  public static string lastuser = "";
   
  public static List<Book> BookSearch(string userSearch ){
          Console.WriteLine($"Searching ...");
               string cmdText =
                    @"SELECT rank() over(order by title desc) as _index, barcode, title, author, genre FROM books " + userSearch;
          List<Book> returnBookSearch = new List<Book>();
          using SqlConnection connection = new SqlConnection(ADOconnect.ConnectionString());
          connection.Open();
          using SqlCommand cmd = new SqlCommand(cmdText, connection);
          using SqlDataReader reader = cmd.ExecuteReader();
          while(reader.Read()){
               //Console.WriteLine("pass");
               Book book = new Book( Convert.ToInt32(reader[0].ToString()), Convert.ToInt32(reader[1].ToString()), reader.GetString(2), reader.GetString(3), reader.GetString(4));
               returnBookSearch.Add(book);
          }
          return returnBookSearch;
     }

     public static void SetCart(Book bookcart, string username  ){
          if(lastuser == ""){
               lastuser = username;
               cart.Add(bookcart);
          } else if (lastuser == username){
              cart.Add(bookcart);
          } else if (lastuser != username) {
               lastuser=username;
               cart.Clear();
               cart.Add(bookcart);
          }
     }

     public static List<Book> GetCart(){
         return cart;
     }

     public static void ClearCart(){
         cart.Clear();
     }


     public static void Checkout(){
          Console.WriteLine($"Checking out ...");
               
          Guid userGuid = UserController.GetCurrentGuid();
          string cmdText = @"SELECT b.barcode, b.title, b.author FROM checkoutStatus c join books b on b.barcode = c.barcode where checkedout_status = 'OUT' ";
          using SqlConnection connection = new SqlConnection(ADOconnect.ConnectionString());
          connection.Open();
          using SqlCommand cmd = new SqlCommand(cmdText, connection);
          using SqlDataReader reader = cmd.ExecuteReader();
          List<int> NOTsafeToCheckout = new List<int>(); 
          while(reader.Read()){
               Console.WriteLine("Book: " + reader.GetString(1) + " " + reader.GetString(2) + "is already checked out. Sorry!" );
               NOTsafeToCheckout.Add(Convert.ToInt32(reader[0].ToString()));
          }
         
          foreach (Book book in cart){
               
               if(NOTsafeToCheckout.Count == 0){
                    Console.WriteLine("All books are available for checkout.");
                    string cmdInsert = @"INSERT INTO checkoutStatus (barcode, userguid, checkedout_status, duedate, control_ts) VALUES (@barcode, @userguid, @checkedout_status, @duedate, DEFAULT) " ;
                    using SqlCommand cmd2 = new SqlCommand(cmdInsert, connection);
                    cmd2.Parameters.AddWithValue("@barcode", book.barcode);
                    cmd2.Parameters.AddWithValue("@userguid",userGuid );
                    cmd2.Parameters.AddWithValue("@checkedout_status", "OUT");
                    cmd2.Parameters.AddWithValue("@duedate", DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
           
                    cmd2.ExecuteNonQuery();

                    Console.WriteLine("Checkout Completed for " + book.title +" " +book.author);
                    

               } else {
                         //Console.WriteLine(book.barcode);
                         if(!NOTsafeToCheckout.Exists(item => item == book.barcode)){
                              
                              string cmdInsert = @"INSERT INTO checkoutStatus (barcode, userguid, checkedout_status, duedate, control_ts) VALUES (@barcode, @userguid, @checkedout_status, @duedate, DEFAULT) " ;
                              using SqlCommand cmd3 = new SqlCommand(cmdInsert, connection);
                              cmd3.Parameters.AddWithValue("@barcode", book.barcode);
                              cmd3.Parameters.AddWithValue("@userguid",userGuid );
                              cmd3.Parameters.AddWithValue("@checkedout_status", "OUT");
                              cmd3.Parameters.AddWithValue("@duedate", DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
                    
                              cmd3.ExecuteNonQuery();
                              
                              Console.WriteLine("Checkout Completed for " + book.title +" " +book.author);
                             
                             
                               
                    }
               }
          }


          ClearCart();

     }

      public static string QueryCheckedOutBooks(){
           Guid userGuid = UserController.GetCurrentGuid();
          string cmdText =
               string.Format(@"SELECT  b.title, b.author, c.checkedout_status, c.duedate  FROM checkoutStatus c join books b on b.barcode = c.barcode where checkedout_status = 'OUT' and userguid = '{0}' ", userGuid);
          string returnUserChecked = "";
          
          using SqlConnection connection = new SqlConnection(ADOconnect.ConnectionString());
          connection.Open();
          using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
          using SqlDataReader reader4 = cmd4.ExecuteReader();
          while(reader4.Read()){
               returnUserChecked += "Checked Out: " + reader4.GetString(0) + " "+ reader4.GetString(1) + " " + reader4.GetString(2) + " "+ "Due Date: " + reader4.GetString(3);
          }
          return returnUserChecked;
     }

/*
     public static string QueryCheckedInBooks(){
           Guid userGuid = UserController.GetCurrentGuid();
          string cmdText =
               string.Format(@"SELECT  b.title, b.author, c.checkedout_status, c.duedate  FROM checkoutStatus c join books b on b.barcode = c.barcode where checkedout_status = 'OUT' and userguid = '{0}' ", userGuid);
          string returnUserChecked = "";
          
          using SqlConnection connection = new SqlConnection(ADOconnect.ConnectionString());
          connection.Open();
          using SqlCommand cmd4 = new SqlCommand(cmdText, connection);
          using SqlDataReader reader4 = cmd4.ExecuteReader();
          while(reader4.Read()){
               returnUserChecked += "Checked Out: " + reader4.GetString(0) + " "+ reader4.GetString(1) + " " + reader4.GetString(2) + " "+ "Due Date: " + reader4.GetString(3);
          }
          return returnUserChecked;
     }
     */
}