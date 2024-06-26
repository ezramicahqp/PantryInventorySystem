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
            List<Shelves> items = inventoryData.GetShelves();
            return items;
        }

        public void InventoryAdd(Shelves shelves)
        {
            inventoryData.AddItem(shelves);
        }

    }
}
