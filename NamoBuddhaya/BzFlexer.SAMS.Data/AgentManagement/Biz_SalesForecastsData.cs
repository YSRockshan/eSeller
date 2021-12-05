using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SalesForecastsData
    {
        public void Create(Biz_SalesForecast salesForecast)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesForecasts.AddObject(salesForecast);
                _context.SaveChanges();
            }
        }

       public void Update(Biz_SalesForecast salesForecast)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesForecasts", salesForecast);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesForecast);
                }
                _context.SaveChanges();
            }
        }

        public void Delete(long salesForecastId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesForecastList = (from salesForecast in _context.Biz_SalesForecasts
                                         where salesForecast.Id == salesForecastId
                                         select salesForecast).ToList();
                foreach (Biz_SalesForecast salesForecast in salesForecastList)
                {
                    _context.DeleteObject(salesForecast);
                }
                _context.SaveChanges();
            }
        }

        public Biz_SalesForecast ReadSalesForecastById(long salesForecastId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesForecastList = (from SalesForecast in _context.Biz_SalesForecasts
                                         where SalesForecast.Id == salesForecastId
                                         select SalesForecast).ToList();
                foreach (Biz_SalesForecast salesForecast in salesForecastList)
                {
                    return salesForecast;
                }
                return null;
            }
        }
        public List<Biz_SalesForecast> ReadAllSalesForecast()
        {
            List<Biz_SalesForecast> salesForecastList = null;
            List<Biz_SalesForecast> salesForecasts = new List<Biz_SalesForecast>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesForecastList =
                   (from SalesForecast in _context.Biz_SalesForecasts select SalesForecast).ToList();

                foreach (Biz_SalesForecast salesForecast in salesForecastList)
                {
                    try
                    {
                        salesForecast.Biz_Periods = new Biz_PeriodData().ReadPeriodById(salesForecast.IdPeriod);
                    }
                    catch (Exception)
                    {
                    }
                    salesForecasts.Add(salesForecast);
                }
            }
            return salesForecasts;
        }
        public List<Biz_SalesForecast> ReadSalesForecastByCode(string salesForecastCode)
        {
            List<Biz_SalesForecast> salesForecastList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesForecastList = (from SalesForecast in _context.Biz_SalesForecasts
                                     where SalesForecast.Code == salesForecastCode
                                     select SalesForecast).ToList();
            }
            return salesForecastList;
        }
    }
}
