using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesTransactionService
    {
        Biz_SalesTransactionsData salesTransactionData = new Biz_SalesTransactionsData();

       public long CreateSalesTransaction(Biz_SalesTransaction salesTransaction)
        {
            if (salesTransaction != null)
            {
                return salesTransactionData.Create(salesTransaction);
            }
            return 0;
        }

        public Boolean UpdateSalesTransaction(Biz_SalesTransaction salesTransaction)
        {
            Boolean isSuccess = false;
            if (salesTransaction != null)
            {
                isSuccess = salesTransactionData.Update(salesTransaction);
            }
            return isSuccess;
        }


        public Boolean DeleteSalesTransactions(long salesTransactionId)
        {
            Boolean isSuccess = false;
            if (salesTransactionId != 0)
            {
                isSuccess = salesTransactionData.Delete(salesTransactionId);
            }
            return isSuccess;
        }


        public Biz_SalesTransaction ReadSalesTransactionById(long salesTransactionId)
        {
            return salesTransactionData.ReadSalesTransactionById(salesTransactionId);
        }


        public List<Biz_SalesTransaction> ReadAllSalesTransactions()
        {
            return salesTransactionData.ReadAllSalesTransactions();
        }

        public Biz_SalesTransaction ReadSalesTransactionByInvoiceNo(string invoiceNo)
        {
            return salesTransactionData.ReadSalesTransactionByInvoiceNo(invoiceNo);
        }

    }
}
