using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_InventoryItemService
    {
        Biz_InventoryItemsData inventoryItemData = new Biz_InventoryItemsData();

        public Boolean CreateInventoryItem(Biz_InventoryItem inventoryItem)
        {
            Boolean isSuccess = false;
            if (inventoryItem != null)
            {
                isSuccess = inventoryItemData.Create(inventoryItem);
            }
            return isSuccess;
        }

         public Boolean UpdateInventoryItem(Biz_InventoryItem inventoryItem)
        {
            Boolean isSuccess = false;
            if (inventoryItem != null)
            {
                isSuccess = inventoryItemData.Update(inventoryItem);
            }
            return isSuccess;
        }

        public Boolean DeleteInventoryItems(long inventoryItemId)
        {
            Boolean isSuccess = false;
            if (inventoryItemId != 0)
            {
                isSuccess = inventoryItemData.Delete(inventoryItemId);
            }
            return isSuccess;
        }

         public Biz_InventoryItem ReadInventoryItemById(long inventoryItemId)
        {
            return inventoryItemData.ReadInventoryItemById(inventoryItemId);
        }

         public List<Biz_InventoryItem> ReadAllInventoryItems()
        {
            return inventoryItemData.ReadAllInventoryItems();
        }

        public List<Biz_Product> ReadProductByBranchId(long branchId)
        {
            return inventoryItemData.ReadProductByBranchId(branchId);
        }

        public List<Biz_InventoryItem> ReadInventoryItmByCode(string itmCode)
        {
            return inventoryItemData.ReadInventoryItmByCode(itmCode);
        }

    }
}
