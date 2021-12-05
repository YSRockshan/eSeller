using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_InvoicesData
    {
        public Boolean Create(Biz_Invoice invoice)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Invoices.AddObject(invoice);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Boolean Update(Biz_Invoice invoice)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Invoices", invoice);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, invoice);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long invoiceId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var invoiceList = from Invoice in _context.Biz_Invoices
                                  where Invoice.Id == invoiceId
                                  select Invoice;

                foreach (Biz_Invoice invoice in invoiceList)
                {
                    _context.DeleteObject(invoice);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Biz_Invoice ReadInvoiceById(long invoiceId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var invoiceList = from Invoice in _context.Biz_Invoices
                                  where Invoice.Id == invoiceId
                                  select Invoice;

                foreach (Biz_Invoice invoice in invoiceList)
                {
                    return invoice;
                }
                return null;
            }
        }

        public List<Biz_Invoice> ReadAllInvoices()
        {
            List<Biz_Invoice> invoiceList = null;
            List<Biz_Invoice> invoices = new List<Biz_Invoice>();

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                invoiceList =
                    (from Invoice in _context.Biz_Invoices orderby Invoice.Total_Value descending
                     select Invoice ).ToList();

                foreach (Biz_Invoice invoice in invoiceList)
                {
                    invoice.Biz_SalesTargets = new Biz_SalesTargetsData().ReadSalesTargetById(Convert.ToInt16(invoice.IdSalesTarget));
                    invoice.Biz_InventoryItems = new Biz_InventoryItemsData().ReadInventoryItemById(Convert.ToInt16(invoice.IdItem));
                    invoice.Biz_BranchProducts = new Biz_BranchProductsData().ReadBranchProductById(Convert.ToInt16(invoice.IdBranchProduct));
                    invoice.Biz_BranchPriceBooks = new Biz_BranchesPriceBookData().ReadByBranchPriceBookId(Convert.ToInt16(invoice.IdBranchPriceBook));
                    invoice.Biz_BranchPriceBooks.Biz_PriceBooks = new Biz_PriceBookData().ReadPriceBookById(Convert.ToInt16(invoice.Biz_BranchPriceBooks.IdPriceBook));
                    invoice.Biz_BranchProducts.Biz_Products = new Biz_GeneralProductsData().ReadProductsById(Convert.ToInt16(invoice.Biz_BranchProducts.IdProduct));
                    invoice.Biz_UnitOfMeasures =
                        new Biz_UnitOfMeasureData().ReadUnitOfMeasureById(Convert.ToInt16(invoice.IdUnitOfMeasure));
                    invoice.Biz_Branches = new Biz_BranchesData().ReadBranchById(Convert.ToInt16(invoice.IdBranch));
                    invoice.Biz_SalesTransactions =
                        new Biz_SalesTransactionsData().ReadSalesTransactionById(Convert.ToInt16(invoice.IdSalesTransaction));

                    invoices.Add(invoice);
                }
            }
            return invoices;
        }

    }
}
