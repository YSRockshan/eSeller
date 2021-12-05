using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_MemberCommssionDetailsData
    {
        public Boolean Create(Biz_MemberCommssionDetail memberCommssionDetail)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_MemberCommssionDetails.AddObject(memberCommssionDetail);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_MemberCommssionDetail memberCommssionDetail)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_MemberCommssionDetails", memberCommssionDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, memberCommssionDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long memberCommssionDetailId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberCommssionDetailList = from MemberCommssionDetail in _context.Biz_MemberCommssionDetails
                                                where MemberCommssionDetail.Id == memberCommssionDetailId
                                                select MemberCommssionDetail;

                foreach (Biz_MemberCommssionDetail memberCommssionDetail in memberCommssionDetailList)
                {
                    _context.DeleteObject(memberCommssionDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_MemberCommssionDetail ReadMemberCommssionDetailById(long memberCommssionDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberCommssionDetailList = from MemberCommssionDetail in _context.Biz_MemberCommssionDetails
                                                where MemberCommssionDetail.Id == memberCommssionDetailId
                                                select MemberCommssionDetail;

                foreach (Biz_MemberCommssionDetail memberCommssionDetail in memberCommssionDetailList)
                {
                    return memberCommssionDetail;
                }
                return null;
            }
        }


        public List<Biz_MemberCommssionDetail> ReadAllMemberCommssionDetails()
        {
            List<Biz_MemberCommssionDetail> memberCommssionDetailList = null;
            List<Biz_MemberCommssionDetail> memberCommssionDetails = new List<Biz_MemberCommssionDetail>();

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                memberCommssionDetailList =
                    (from MemberCommssionDetail in _context.Biz_MemberCommssionDetails
                     select MemberCommssionDetail).ToList();
                foreach (Biz_MemberCommssionDetail memberCommssionDetail in memberCommssionDetailList)
                {
                    memberCommssionDetail.Biz_Branches = new Biz_BranchesData().ReadBranchById(memberCommssionDetail.IdBranch);
                    memberCommssionDetail.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailById(memberCommssionDetail.IdSalesAgent);
                    memberCommssionDetail.Biz_SalesTransactions =
                        new Biz_SalesTransactionsData().ReadSalesTransactionById(Convert.ToInt16(memberCommssionDetail.IdSalesTransaction));
                    memberCommssionDetail.Biz_Invoices = new Biz_InvoicesData().ReadInvoiceById(memberCommssionDetail.IdInvoice);
                    memberCommssionDetail.Biz_Invoices.Biz_BranchProducts =
                        new Biz_BranchProductsData().ReadBranchProductById(Convert.ToInt16(memberCommssionDetail.Biz_Invoices.IdBranchProduct));
                    memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products =
                        new Biz_GeneralProductsData().ReadProductsById(memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.IdProduct);
                    memberCommssionDetail.Biz_Invoices.Biz_InventoryItems =
                        new Biz_InventoryItemsData().ReadInventoryItemById(memberCommssionDetail.Biz_Invoices.IdItem);
                    memberCommssionDetail.Biz_Invoices.Biz_SalesTargets =
                        new Biz_SalesTargetsData().ReadSalesTargetById(Convert.ToInt16(memberCommssionDetail.Biz_Invoices.IdSalesTarget));

                    memberCommssionDetails.Add(memberCommssionDetail);
                }
            }
            return memberCommssionDetails;
        }
        public List<Biz_Invoice> ReadInvoiceList(long productCategoryId, long subProductCatId, long productId)
        {
            List<Biz_Invoice> invoices = new List<Biz_Invoice>();
            List<long> invTransId = new List<long>();

            invoices = new Biz_InvoicesData().ReadAllInvoices();
            invoices = (from invoice in invoices where invoice.Status.Trim() == "P" select invoice).ToList();

            if (productCategoryId > 0 && subProductCatId == 0 && productId == 0)
            {
                invoices =
                (from invoice in invoices
                 where invoice.Biz_BranchProducts.IdProductCategory == productCategoryId
                 select invoice).ToList();
            }
            if (productCategoryId > 0 && subProductCatId > 0 && productId == 0)
            {
                invoices =
                (from invoice in invoices
                 where invoice.Biz_BranchProducts.IdProductCategory == productCategoryId && invoice.Biz_BranchProducts.IdSubProductCategory == subProductCatId
                 select invoice).ToList();
            }
            if (productCategoryId > 0 && subProductCatId > 0 && productId > 0)
            {
                invoices =
                (from invoice in invoices
                 where invoice.Biz_BranchProducts.IdProductCategory == productCategoryId && invoice.Biz_BranchProducts.IdSubProductCategory == subProductCatId && invoice.Biz_BranchProducts.IdProduct == productId
                 select invoice).ToList();
            }


            return invoices;
        }

    }
}
