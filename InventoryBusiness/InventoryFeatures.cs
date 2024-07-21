using PantryInventoryData;
using PantryModels;
using System;

namespace InventoryBusiness
{
    public class InventoryFeatures
    {
        InventoryData inventoryData = new InventoryData();

        public List<Shelves> InventoryDisplay()
        {
            List<Shelves> items = inventoryData.GetItemFromShelves();
            return items;
        }

        public bool InventoryAdd(string ItemName, string ItemType, int Quantity)
        {
            inventoryData.AddItemOnShelves(ItemName, ItemType, Quantity);
            return true;
        }

        public int InventoryGet(string ItemName, int GetQuantity)
        {
            int FromShelfQuantity = inventoryData.CheckIfItemIsOnShelves(ItemName);

            if (FromShelfQuantity >= GetQuantity)
            {
                int NewQuantity = FromShelfQuantity - GetQuantity;
                inventoryData.UpdateItemOnShelves(ItemName, NewQuantity);
                return NewQuantity;
            }
            else
            {
                Console.WriteLine("Insufficient quantity on shelf.");
                return 0;
            }
        }


        public bool InventoryDelete(int Quantity)
        {
            inventoryData.DeleteItemFromShelves(Quantity);
            return true;
        }




    }
}
