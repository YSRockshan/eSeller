using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_InvoiceService
    {
        Biz_InvoicesData _invoiceData = new Biz_InvoicesData();

        
        public Boolean CreateInvoice(Biz_Invoice invoice)
        {
            Boolean isSuccess = false;
            if (invoice != null)
            {
                isSuccess = _invoiceData.Create(invoice);
            }
            return isSuccess;
        }

       
        public Boolean UpdateInvoice(Biz_Invoice invoice)
        {
            Boolean isSuccess = false;
            if (invoice != null)
            {
                isSuccess = _invoiceData.Update(invoice);
            }
            return isSuccess;
        }

        public Boolean DeleteInvoice(long invoiceId)
        {
            Boolean isSuccess = false;
            if (invoiceId != 0)
            {
                isSuccess = _invoiceData.Delete(invoiceId);
            }
            return isSuccess;
        }

        public Biz_Invoice ReadInvoiceById(long invoiceId)
        {
            return _invoiceData.ReadInvoiceById(invoiceId);
        }

        public List<Biz_Invoice> ReadAllInvoices()
        {
            return _invoiceData.ReadAllInvoices();
        }

    }
}
