using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reports
{
    public class Biz_SalesSummeryService
    {
        Biz_SalesSummeryData salesSummeryData = new Biz_SalesSummeryData();

        public List<Biz_Invoice> ReadAllSalesSummary()
        {
            return salesSummeryData.GetAllSalesSummary();
        }
    }
}
