using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Data.Reports
{
    public class Biz_SalesSummeryData
    {
        public List<Biz_Invoice> GetAllSalesSummary()
        {
            List<Biz_Invoice> invoices = new List<Biz_Invoice>();
            invoices = new Biz_InvoicesData().ReadAllInvoices();

            if (invoices != null)
            {
                return invoices;
            }
            else
            {
                return null;
            }

            //DataTable dt = new DataTable();
            //DataRow dr;

            //dt.Columns.Add(new DataColumn("SalesSummaryId", typeof (Int32)));
            //dt.Columns.Add(new DataColumn("Business Unit", typeof (String)));
            //dt.Columns.Add(new DataColumn("Category", typeof (String)));
            //dt.Columns.Add(new DataColumn("Product", typeof (String)));
            //dt.Columns.Add(new DataColumn("Description", typeof (String)));
            //dt.Columns.Add(new DataColumn("Currency", typeof (String)));
            //dt.Columns.Add(new DataColumn("Gross Total", typeof (Decimal)));
            //dt.Columns.Add(new DataColumn("Discount", typeof (Decimal)));
            //dt.Columns.Add(new DataColumn("Net Total", typeof (Decimal)));
            //dt.Columns.Add(new DataColumn("Tax", typeof (Decimal)));

            //return dt;

        }
    }
}
