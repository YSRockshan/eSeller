using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public class Biz_SalesTransactionsData
    {
        public long Create(Biz_SalesTransaction salesTransaction)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesTransactions.AddObject(salesTransaction);
                _context.SaveChanges();
                return salesTransaction.Id;

            }

        }


        public Boolean Update(Biz_SalesTransaction salesTransaction)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesTransactions", salesTransaction);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesTransaction);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long salesTransactionId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTransactionList = from SalesTransaction in _context.Biz_SalesTransactions
                                           where SalesTransaction.Id == salesTransactionId
                                           select SalesTransaction;

                foreach (Biz_SalesTransaction salesTransaction in salesTransactionList)
                {
                    _context.DeleteObject(salesTransaction);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_SalesTransaction ReadSalesTransactionById(long salesTransactionId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTransactionList = from SalesTransaction in _context.Biz_SalesTransactions
                                           where SalesTransaction.Id == salesTransactionId
                                           select SalesTransaction;

                foreach (Biz_SalesTransaction salesTransaction in salesTransactionList)
                {
                    return salesTransaction;
                }
                return null;
            }
        }


        public List<Biz_SalesTransaction> ReadAllSalesTransactions()
        {
            List<Biz_SalesTransaction> salesTransactionList = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesTransactionList =
                    (from SalesTransaction in _context.Biz_SalesTransactions
                     select SalesTransaction).ToList();
            }
            return salesTransactionList;
        }
        public Biz_SalesTransaction ReadSalesTransactionByInvoiceNo(string invoiceNo)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTransactionList = from SalesTransaction in _context.Biz_SalesTransactions
                                           where SalesTransaction.Invoice_No == invoiceNo
                                           select SalesTransaction;

                foreach (Biz_SalesTransaction salesTransaction in salesTransactionList)
                {
                    return salesTransaction;
                }
                return null;
            }
        }
    }
}
