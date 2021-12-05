using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesForecastDetailsService
    {
        Biz_SalesForecastDetailsData salesForecastDetailData = new Biz_SalesForecastDetailsData();

        public void CrateSalesForecastDetail(Biz_SalesForecastDetail salesForecastDetail)
        {
            salesForecastDetailData.Crate(salesForecastDetail);
        }

        public void UpdateSalesForecastDetail(Biz_SalesForecastDetail salesForecastDetail)
        {
            salesForecastDetailData.Update(salesForecastDetail);
        }

        public void DeleteSalesForecastingDetail(long salesForecastDetailId)
        {
            salesForecastDetailData.Delete(salesForecastDetailId);
        }

        public Biz_SalesForecastDetail ReadSalesForecastDetailbyId(long salesForecastDetailId)
        {
            return salesForecastDetailData.ReadsalesForecastDetailbyId(salesForecastDetailId);
        }

        public List<Biz_SalesForecastDetail> ReadAllSalesForecastDetail()
        {
            return salesForecastDetailData.ReadAllSalesForecastDetail();
        }

        public List<Biz_Product> ReadUnMappedtProduct(long salesForecastId)
        {
            return salesForecastDetailData.ReadUnMappedtProduct(salesForecastId);
        }

        public List<Biz_SalesForecastDetail> ReadMappedSalesForecastDetail(long salesForecastId)
        {
            return salesForecastDetailData.ReadMappedSalesForecastDetail(salesForecastId);
        }

    }
}
