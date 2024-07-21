using InventoryBusiness;
using Microsoft.AspNetCore.Mvc;
using PantryInventoryData;

namespace PantryInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/PantryInventoryAPI")]
    public class InventoryController : Controller
    {
        InventoryFeatures inventoryFeatures;

        public InventoryController(){

            inventoryFeatures = new InventoryFeatures();
        }

        [HttpGet]
        public IEnumerable<PantryInventoryAPI.Shelves> GetItems()
        {
            var items = inventoryFeatures.InventoryDisplay();

            List<PantryInventoryAPI.Shelves> product = new List<Shelves>();

            foreach (var item in items)
            {

                product.Add(new PantryInventoryAPI.Shelves { ItemName = item.ItemName, ItemType = item.ItemType, Quantity = item.Quantity });
            }

            return product;
        }

        [HttpPost]
         public JsonResult AddItem(string ItemName, string ItemType, int Quantity)
         {
             var AddedItem = inventoryFeatures.InventoryAdd(ItemName, ItemType, Quantity);
             return new JsonResult(AddedItem);
         }

         
        [HttpPatch]
         public JsonResult UpdateItem(string itemName, int quantity)
          {
            
            var item = inventoryFeatures.InventoryGet(itemName, quantity);

            return new JsonResult(item);
         }

        [HttpDelete]
        public void DeleteItem(int quantity)
        {
            inventoryFeatures.InventoryDelete(quantity);
        }



    }
}
