using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SalesTargetsData
    {
        public Boolean Create(Biz_SalesTarget salesTarget)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesTargets.AddObject(salesTarget);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_SalesTarget salesTarget)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesTargets", salesTarget);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesTarget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long salesTargetId)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTargetList = from SalesTarget in _context.Biz_SalesTargets
                                      where SalesTarget.Id == salesTargetId
                                      select SalesTarget;

                foreach (Biz_SalesTarget salesTarget in salesTargetList)
                {
                    _context.DeleteObject(salesTarget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

         public Biz_SalesTarget ReadSalesTargetById(long salesTargetId)
        {
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesTargetList = from SalesTarget in _context.Biz_SalesTargets
                                      where SalesTarget.Id == salesTargetId
                                      select SalesTarget;

                foreach (Biz_SalesTarget salesTarget in salesTargetList)
                {
                    return salesTarget;
                }
                return null;
            }
        }

        public List<Biz_SalesTarget> ReadAllSalesTargets()
        {
            List<Biz_SalesTarget> salesTargetList = null;
            List<Biz_SalesTarget> salesTargets = new List<Biz_SalesTarget>();

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesTargetList =
                    (from SalesTarget in _context.Biz_SalesTargets
                     select SalesTarget).ToList();
                foreach (Biz_SalesTarget salesTarget in salesTargetList)
                {
                    salesTarget.Biz_SalesBudgets =
                        new Biz_SalesBudgetsData().ReadSalesBudgetById(Convert.ToInt16(salesTarget.IdSalesBudget));
                    salesTarget.Biz_Periods = new Biz_PeriodData().ReadPeriodById(Convert.ToInt16(salesTarget.IdPeriod));
                    salesTarget.Biz_SalesForecasts = new Biz_SalesForecastsData().ReadSalesForecastById(Convert.ToInt16(salesTarget.Biz_SalesBudgets.IdSalesForecast));
                    salesTargets.Add(salesTarget);
                }
            }
            return salesTargets;
        }

        public List<Biz_SalesTarget> ReadSalesTargetByCode(string salesTargetCode)
        {
            List<Biz_SalesTarget> salesTargetList = null;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesTargetList = (from SalesTarget in _context.Biz_SalesTargets
                                   where SalesTarget.Code == salesTargetCode
                                   select SalesTarget).ToList();
            }
            return salesTargetList;
        }
    }
}
