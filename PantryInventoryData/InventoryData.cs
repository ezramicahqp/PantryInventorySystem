using PantryModels;
using System.Reflection.Metadata.Ecma335;
using static System.Reflection.Metadata.BlobBuilder;

namespace PantryInventoryData

{
    public class InventoryData
    {
        List<Shelves> shelves;
        SqlDBInventoryData sqlDBInventoryData;

        public InventoryData()
        {
            shelves = new List<Shelves>();
            sqlDBInventoryData = new SqlDBInventoryData();

        }

        public List<Shelves> GetItemFromShelves()
        {
            shelves = sqlDBInventoryData.GetShelves();
            return shelves;
        }

        public int CheckIfItemIsOnShelves(string ItemName) 
        {
            return sqlDBInventoryData.CheckIfItemExist(ItemName);
        }

        public int AddItemOnShelves(string ItemName, string ItemType, int Quantity)
        {
            return sqlDBInventoryData.AddItem(ItemName, ItemType, Quantity);
        }

        public int UpdateItemOnShelves(string ItemName, int NewQuantity)
        {
            return sqlDBInventoryData.UpdateItem(ItemName, NewQuantity );
        }

        public int DeleteItemFromShelves(int Quantity)
        {
            return sqlDBInventoryData.DeleteItem(Quantity);
        }

    }
}
