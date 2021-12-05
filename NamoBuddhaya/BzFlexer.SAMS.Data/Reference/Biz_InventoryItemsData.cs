using System;
using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.Reference;
using System.Data;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_InventoryItemsData
    {
        //Parametere long? yet to test 
        public Biz_InventoryItem ReadInventoryItemById(long? inventoryItemId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var inventoryItemList = from InventoryItem in _context.Biz_InventoryItems
                                        where InventoryItem.Id == inventoryItemId
                                        select InventoryItem;

                foreach (Biz_InventoryItem inventoryItem in inventoryItemList)
                {
                    return inventoryItem;
                }
                return null;
            }
        }

        public Boolean Create(Biz_InventoryItem inventoryItem)
        {
            Boolean isSuccess = false;
                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_InventoryItems.AddObject(inventoryItem);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Boolean Update(Biz_InventoryItem inventoryItem)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_InventoryItems", inventoryItem);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, inventoryItem);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long inventoryItemId)
        {
            Boolean isSuccess = false;
                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var inventoryItemList = from InventoryItem in _context.Biz_InventoryItems
                                        where InventoryItem.Id == inventoryItemId
                                        select InventoryItem;

                foreach (Biz_InventoryItem inventoryItem in inventoryItemList)
                {
                    _context.DeleteObject(inventoryItem);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Biz_InventoryItem ReadInventoryItemById(long inventoryItemId)
        {
                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var inventoryItemList = from InventoryItem in _context.Biz_InventoryItems
                                        where InventoryItem.Id == inventoryItemId
                                        select InventoryItem;

                foreach (Biz_InventoryItem inventoryItem in inventoryItemList)
                {
                    return inventoryItem;
                }
                return null;
            }
        }

        public List<Biz_InventoryItem> ReadAllInventoryItems()
        {
            List<Biz_InventoryItem> inventoryItemList = null;

                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                inventoryItemList =
                    (from InventoryItem in _context.Biz_InventoryItems
                     select InventoryItem).ToList();
            }
            return inventoryItemList;
        }

        public List<Biz_Product> ReadProductByBranchId(long branchId)
        {
            List<Biz_Product> AllProducts = new List<Biz_Product>();
            AllProducts = new Biz_GeneralProductsData().ReadAllProduct();

            List<Biz_BranchProduct> AllBranchProducts = new List<Biz_BranchProduct>();
            AllBranchProducts = new Biz_BranchProductsData().ReadAllBranchProduct();

            List<Biz_BranchProduct> BranchProductByBranch = new List<Biz_BranchProduct>();
            BranchProductByBranch =
                (from branchProduct in AllBranchProducts where branchProduct.IdBranch == branchId select branchProduct).
                    ToList();

            List<long> productIdBranchProduct = (from id in BranchProductByBranch select id.IdProduct).ToList();

            List<Biz_Product> BindProducts = new List<Biz_Product>();
            BindProducts =
                (from product in AllProducts where productIdBranchProduct.Contains(product.Id) select product).
                    ToList();
            return BindProducts;
        }

        public List<Biz_InventoryItem> ReadInventoryItmByCode(string itmCode)
        {
            List<Biz_InventoryItem> inventoryItemList = new List<Biz_InventoryItem>();

                using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                inventoryItemList =
                    (from InventoryItem in _context.Biz_InventoryItems
                     where InventoryItem.CodeInventoryItem == itmCode
                     select InventoryItem).ToList();
            }
            return inventoryItemList;

        }


    }
}
