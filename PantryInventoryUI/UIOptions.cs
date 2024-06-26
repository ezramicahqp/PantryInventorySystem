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
                Console.WriteLine(shelf.Quantity + "\n");
            }

        }

        public void AddItem(string ItemName, string ItemType, int Quantity)
        {
            Console.WriteLine("You're about to get an item. . .\n");
            Console.WriteLine("-----------------------------------");


            Console.Write("Item name: ");
            ItemName = Console.ReadLine();
            Console.Write("Item type: ");
            ItemType = Console.ReadLine();
            Console.Write("Item quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());

            Shelves shelves = new Shelves
            {
                ItemName = ItemName,
                ItemType = ItemType,
                Quantity = (byte)Quantity
            };

 
            inventoryFeatures.InventoryAdd(shelves);
            
        }
       
    }
}
