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
    public partial class Biz_SalesBudgetDetailData
    {
        public void Create(Biz_SalesBudgetDetail salesBudgetDetail)
        {
            try
            {
                using (BizFlexerDBContext _context = new BizFlexerDBContext())
                {
                    _context.Biz_SalesBudgetDetails.AddObject(salesBudgetDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception err)
            {

            }

        }


        public void Update(Biz_SalesBudgetDetail salesBudgetDetail)
        {
            EntityKey key = null;
            Object original = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesBudgetDetails", salesBudgetDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesBudgetDetail);
                }
                _context.SaveChanges();
            }
        }


        public void Delete(long salesBudgetDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesBudgetDetailList = from SalesBudgetDetail in _context.Biz_SalesBudgetDetails
                                            where SalesBudgetDetail.Id == salesBudgetDetailId
                                            select SalesBudgetDetail;
                foreach (Biz_SalesBudgetDetail salesBudgetDetail in salesBudgetDetailList)
                {
                    _context.DeleteObject(salesBudgetDetail);
                }
                _context.SaveChanges();
            }
        }


        public Biz_SalesBudgetDetail ReadSalesBudgetDetailbyId(long salesBudgetDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {

                var salesBudgetDetailList = from SalesBudgetDetail in _context.Biz_SalesBudgetDetails
                                            where SalesBudgetDetail.Id == salesBudgetDetailId
                                            select SalesBudgetDetail;
                foreach (Biz_SalesBudgetDetail salesBudgetDetail in salesBudgetDetailList)
                {
                    return salesBudgetDetail;
                }
                return null;
            }
        }


        public List<Biz_SalesBudgetDetail> ReadAllSalesBudgetDetail()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = null;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesBudgetDetailList =
                    (from salesBudgetDetail in _context.Biz_SalesBudgetDetails select salesBudgetDetail).ToList();
            }
            return salesBudgetDetailList;
        }
        public List<Biz_SalesBudgetDetail> ReadSalesBudgetDetailbyBranchBudget(long branchId, long salesBudgetId)
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = null;
            List<Biz_SalesBudgetDetail> salesBudgetDetails = new List<Biz_SalesBudgetDetail>();

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesBudgetDetailList =
                    (from SalesBudgetDetail in _context.Biz_SalesBudgetDetails where SalesBudgetDetail.IdBranch == branchId && SalesBudgetDetail.IdSalesBudget == salesBudgetId select SalesBudgetDetail).ToList();

                foreach (Biz_SalesBudgetDetail salesBudgetDetail in salesBudgetDetailList)
                {
                    salesBudgetDetail.Biz_Products =
                        new Biz_GeneralProductsData().ReadProductsById(Convert.ToInt16(salesBudgetDetail.IdProduct));
                    salesBudgetDetails.Add(salesBudgetDetail);
                }
                return salesBudgetDetails;
            }
        }
        public List<Biz_Product> ReadUnmappedProductBybranchIdsalesBudgetId(long branchId, long salesBudgetId)
        {
            List<Biz_Product> products = new List<Biz_Product>();
            products = new Biz_GeneralProductsData().ReadAllProduct();

            List<Biz_BranchProduct> productListBranch = new List<Biz_BranchProduct>();
            productListBranch = new Biz_BranchProductsData().ReadAllBranchProduct();

            List<long> productListBranchId = new List<long>();
            productListBranchId = (from id in productListBranch select id.IdProduct).ToList();


            List<Biz_SalesBudgetDetail> productListMapped = new List<Biz_SalesBudgetDetail>();
            productListMapped = this.ReadAllSalesBudgetDetail();

            List<long> productListMappedId = new List<long>();
            productListMappedId = (from id in productListMapped select id.IdProduct).ToList();

            List<long> productLisunmappedId = new List<long>();
            productLisunmappedId = productListBranchId.Except(productListMappedId).ToList();

            products = (from productss in new Biz_GeneralProductsData().ReadAllProduct()
                        where
                            productLisunmappedId.Contains(productss.Id)
                        select productss).ToList();
            return products;
        }

    }
}
