namespace classesHackPratice;

class Program
{
   static void Main(string[] args)
    {
        List<Item> grocery_items = new List<Item>();
        bool repeat_selection = true;
        while(repeat_selection)
        {

            Console.WriteLine(@"
            Menu Option  
             0 - Exit
             1 - Add Inventory Item 
             2 - Update Inventory Item. Search by barcode
             3 - Delete Inventory Item. Search by barcode" );

            int intSelection = Convert.ToInt16(Console.ReadLine());

            switch (intSelection)
            {
                case 0:

                    for(int i = 0; i < grocery_items.Count(); i++)
                    {
                        Console.WriteLine(i + " "  + grocery_items[i]);
                    }; 
                    repeat_selection = false;

                    break;
                case 1:
                    
                    Console.WriteLine("Add Inventory:Enter Name of Product");
                    string item_name;
                    item_name = Console.ReadLine();
                    Console.WriteLine("Add Inventory:Enter Barcode of Product");
                    string item_barcode;
                    item_barcode = Console.ReadLine();
                    Console.WriteLine("Add Inventory:Enter Category of Product");
                    string item_category;
                    item_category = Console.ReadLine();

                    Item itemEntered = new Item(item_name, item_barcode, item_category );
                    grocery_items.Add(itemEntered);

                    break;
               // case 2:

                    
            };
        }      
    }
}


//  Console.WriteLine(@"Menu Option  
//                             0 - Exit
//                             1 - Add Inventory Item");
//                         string added_items;
//                         added_items = Console.ReadLine();
//                         if(added_items == "0")
//                         {
//                         for(int i = 0; i < grocery_items.Count(); i++)
//                          {
//                               Console.WriteLine(i + " "  + grocery_items[i]);
//                           };
