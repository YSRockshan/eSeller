using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesForecastService
    {
        Biz_SalesForecastsData _salesForecastData = new Biz_SalesForecastsData();
        public void CreateSalesForecast(Biz_SalesForecast salesForecast)
        {
            _salesForecastData.Create(salesForecast);
        }

        public void UpdateSalesForecast(Biz_SalesForecast salesForecast)
        {
            _salesForecastData.Update(salesForecast);
        }

        public void DeleteSalesForecast(long salesForecastId)
        {
            _salesForecastData.Delete(salesForecastId);
        }

        public List<Biz_SalesForecast> ReadAllSalesForecast()
        {
            return _salesForecastData.ReadAllSalesForecast();
        }

        public List<Biz_SalesForecast> ReadSalesForecastByCode(string salesForecastCode)
        {
            return _salesForecastData.ReadSalesForecastByCode(salesForecastCode);
        }

        public Biz_SalesForecast ReadSalesForecastById(long salesForecastId)
        {
            return _salesForecastData.ReadSalesForecastById(salesForecastId);
        }

    }
}
