using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public class Biz_SalesTargetDetailsData
    {
        public Boolean Create(Biz_SalesTargetDetail salesTargetDetail)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesTargetDetails.AddObject(salesTargetDetail);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_SalesTargetDetail salesTargetDetail)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesTargetDetails", salesTargetDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesTargetDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long salesTargetDetailId)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTargetDetailList = from SalesTargetDetail in _context.Biz_SalesTargetDetails
                                            where SalesTargetDetail.Id == salesTargetDetailId
                                            select SalesTargetDetail;

                foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetailList)
                {
                    _context.DeleteObject(salesTargetDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_SalesTargetDetail ReadSalesTargetDetailById(long salesTargetDetailId)
        {
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTargetDetailList = from SalesTargetDetail in _context.Biz_SalesTargetDetails
                                            where SalesTargetDetail.Id == salesTargetDetailId
                                            select SalesTargetDetail;

                foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetailList)
                {
                    return salesTargetDetail;
                }
                return null;
            }
        }


        public List<Biz_SalesTargetDetail> ReadAllSalesTargetDetails()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = null;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesTargetDetailList =
                    (from SalesTargetDetail in _context.Biz_SalesTargetDetails
                     select SalesTargetDetail).ToList();
            }
            return salesTargetDetailList;
        }
        public List<Biz_SalesTargetDetail> ReadSalesTargetByBranchAndTarget(long branchId, long salesTargetId)
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            List<Biz_SalesTargetDetail> salesTargetDetails = new List<Biz_SalesTargetDetail>();

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesTargetDetailList =
                    (from SalesTargetDetail in _context.Biz_SalesTargetDetails where SalesTargetDetail.IdBranch == branchId && SalesTargetDetail.IdSalesTarget == salesTargetId select SalesTargetDetail).ToList();

                foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetailList)
                {
                    salesTargetDetail.Biz_InventoryItems = new Biz_InventoryItemsData().ReadInventoryItemById(salesTargetDetail.IdInventoryItem);
                    //salesTargetDetail.UnitOfMeasure = new UnitOfMeasureData().GetUnitOfMeasureById(Convert.ToInt16(salesTargetDetail.UnitOfMeasureId));
                    salesTargetDetails.Add(salesTargetDetail);
                }
                return salesTargetDetails;
            }
        }
        public List<Biz_InventoryItem> ReadUnmappedItemBybranchIdsalesTargetIdAndProductId(long branchId, long salesTargetId, long productId)
        {
            List<Biz_InventoryItem> inventoryItems = new List<Biz_InventoryItem>();
            inventoryItems = new Biz_InventoryItemsData().ReadAllInventoryItems();
            Biz_BranchProduct branchProduct = new Biz_BranchProduct();
            branchProduct = new Biz_BranchProductsData().ReadBranchProductByBranchIdAndProductId(branchId, productId);

            List<Biz_InventoryItem> inventoryItemsByBranchProduct = new List<Biz_InventoryItem>();
            inventoryItemsByBranchProduct = (from inventoryItem in inventoryItems
                                             where inventoryItem.IdBranchproduct == branchProduct.Id
                                             select inventoryItem).ToList();

            List<long> ItemId = new List<long>();
            ItemId = (from id in inventoryItemsByBranchProduct select id.Id).ToList();

            List<Biz_SalesTargetDetail> ItemListMapped = new List<Biz_SalesTargetDetail>();
            ItemListMapped = this.ReadAllSalesTargetDetails();
            ItemListMapped = (from salesTargetDetail in ItemListMapped
                              where ItemId.Contains(salesTargetDetail.IdInventoryItem)
                              select salesTargetDetail).ToList();

            List<long> ItemListMappedId = new List<long>();
            ItemListMappedId = (from id in ItemListMapped select id.IdInventoryItem).ToList();

            List<long> itemListunmappedId = new List<long>();
            itemListunmappedId = ItemId.Except(ItemListMappedId).ToList();

            inventoryItems = (from invItm in new Biz_InventoryItemsData().ReadAllInventoryItems()
                              where
                                  itemListunmappedId.Contains(invItm.Id)
                              select invItm).ToList();
            return inventoryItems;

          
        }
        public List<Biz_Product> ReadProductsByBranch(long branchId)
        {
            List<Biz_Product> allProducts = new List<Biz_Product>();
            allProducts = new Biz_GeneralProductsData().ReadAllProduct();

            List<Biz_BranchProduct> allBranchProducts = new List<Biz_BranchProduct>();
            allBranchProducts = new Biz_BranchProductsData().ReadAllBranchProduct();

            List<Biz_BranchProduct> branchProductsByBranch = new List<Biz_BranchProduct>();
            branchProductsByBranch =
                (from branchProduct in allBranchProducts where branchProduct.IdBranch == branchId select branchProduct).
                    ToList();

            List<long> branchProductId = new List<long>();
            branchProductId = (from id in branchProductsByBranch select id.IdProduct).ToList();

            List<Biz_Product> products = new List<Biz_Product>();
            products = (from product in allProducts where branchProductId.Contains(product.Id) select product).ToList();

            return products;
        }

        public Biz_SalesTargetDetail ReadSalesTargetDetailByItem(long itemId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTargetDetailList = from SalesTargetDetail in _context.Biz_SalesTargetDetails
                                            where SalesTargetDetail.IdInventoryItem == itemId
                                            select SalesTargetDetail;

                foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetailList)
                {
                    return salesTargetDetail;
                }
                return null;
            }
        }
    }
}
