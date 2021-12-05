using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reports
{
    public class Biz_ForecastSummeryService
    {
        public List<Biz_SalesForecastDetail> GetAllSalesForecastDetail()
        {
            List<Biz_SalesForecastDetail> salesForecastDetails = new List<Biz_SalesForecastDetail>();
            List<Biz_SalesForecastDetail> salesForecastDetailList = new List<Biz_SalesForecastDetail>();
            salesForecastDetails = new Biz_SalesForecastDetailsService().ReadAllSalesForecastDetail();
            foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetails)
            {
                salesForecastDetail.Biz_Products = new Biz_GeneralProductService().ReadProductById(salesForecastDetail.IdProduct);
                salesForecastDetail.Biz_UnitOfMeasures = new Biz_UnitOfMeasureService().ReadUnitOfMeasureById(Convert.ToInt16(salesForecastDetail.IdUnitOfMeasure));
                salesForecastDetailList.Add(salesForecastDetail);
            }
            return salesForecastDetailList;
        }
    }
}
