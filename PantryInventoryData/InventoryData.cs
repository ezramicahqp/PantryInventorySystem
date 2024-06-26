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

        public List<Shelves> GetShelves()
        {
            shelves = sqlDBInventoryData.GetShelves();
            return shelves;
        }

        public int AddItem(Shelves shelves)
        {
            return sqlDBInventoryData.AddItem(shelves.ItemName, shelves.ItemType, shelves.Quantity);
        }
    }
}
