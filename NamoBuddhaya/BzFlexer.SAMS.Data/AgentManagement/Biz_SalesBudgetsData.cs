using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SalesBudgetsData
    {// data sale target is using
        public Biz_SalesBudget ReadSalesBudgetById(long salesBudgetId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesBudgetList = from SalesBudget in _context.Biz_SalesBudgets
                                      where SalesBudget.Id == salesBudgetId
                                      select SalesBudget;

                foreach (Biz_SalesBudget salesBudget in salesBudgetList)
                {
                    return salesBudget;
                }
                return null;
            }
        }

        public Boolean Create(Biz_SalesBudget salesBudget)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesBudgets.AddObject(salesBudget);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_SalesBudget salesBudget)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesBudgets", salesBudget);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesBudget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long salesBudgetId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesBudgetList = from SalesBudget in _context.Biz_SalesBudgets
                                      where SalesBudget.Id == salesBudgetId
                                      select SalesBudget;

                foreach (Biz_SalesBudget salesBudget in salesBudgetList)
                {
                    _context.DeleteObject(salesBudget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


      public List<Biz_SalesBudget> ReadAllSalesBudgets()
        {
            List<Biz_SalesBudget> salesBudgetList = null;
            List<Biz_SalesBudget> salesBudgetLists = new List<Biz_SalesBudget>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesBudgetList =
                    (from SalesBudget in _context.Biz_SalesBudgets
                     select SalesBudget).ToList();
            }
            foreach (Biz_SalesBudget salesBudget in salesBudgetList)
            {
                try
                {
                    salesBudget.Biz_SalesForecasts = new Biz_SalesForecastsData().ReadSalesForecastById(salesBudget.IdSalesForecast);
                    salesBudget.Biz_Periods = new Biz_PeriodData().ReadPeriodById(salesBudget.IdPeriod);
                }
                catch (Exception exception)
                { }
                salesBudgetLists.Add(salesBudget);
            }
            return salesBudgetLists;
        }
        public List<Biz_SalesBudget> ReadSalesBudgetByCode(string salesBudgetCode)
        {
            List<Biz_SalesBudget> salesBudgetList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesBudgetList = (from SalesBudget in _context.Biz_SalesBudgets
                                   where SalesBudget.Code == salesBudgetCode
                                   select SalesBudget).ToList();
            }
            return salesBudgetList;
        }
    }
}
