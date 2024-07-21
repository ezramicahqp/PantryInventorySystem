using InventoryBusiness;
using PantryModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryInventoryUI
{
    public class UIOptions
    {
        InventoryFeatures inventoryFeatures = new InventoryFeatures();
        public void Display()
        {
            Console.WriteLine("Displaying items in the pantry. . .\n");
            Console.WriteLine("-----------------------------------");

            foreach (var shelf in inventoryFeatures.InventoryDisplay())
            {
                Console.WriteLine(shelf.ItemName);
                Console.WriteLine(shelf.ItemType);
                if (shelf.Quantity == 0)
                {
                    inventoryFeatures.InventoryDelete(shelf.Quantity);
                }
                else
                {
                    Console.WriteLine(shelf.Quantity + "\n");
                } 
            }

        }

        public void AddItem(string ItemName, string ItemType, int Quantity)
        {
            Console.WriteLine("You're about to add an item. . .\n");
            Console.WriteLine("-----------------------------------");


            Console.Write("Item name: ");
            ItemName = Console.ReadLine();
            Console.Write("Item type: ");
            ItemType = Console.ReadLine();
            Console.Write("Item quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());

            inventoryFeatures.InventoryAdd(ItemName, ItemType, Quantity);

        }

        public void GetItem(string ItemName, int Quantity)
        {
            Console.WriteLine("You're about to get an item. . .\n");
            Console.WriteLine("-----------------------------------");

            Console.Write("Item name: ");
            ItemName = Console.ReadLine();
            Console.Write("Item quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());


            int retrievedQuantity = inventoryFeatures.InventoryGet(ItemName, Quantity);

            if (retrievedQuantity > 0)
            {
                Console.WriteLine($"{retrievedQuantity} units of {ItemName} have been retrieved from the shelf.");
            } else if(retrievedQuantity < 0) 
            {
                Console.WriteLine($"Unable to retrieve {Quantity} units of {ItemName} from the shelf.");
            }
        }

    }
}
