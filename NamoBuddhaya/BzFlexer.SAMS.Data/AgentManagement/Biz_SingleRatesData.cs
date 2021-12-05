using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SingleRatesData
    {
        public Boolean Create(Biz_SingleRate singleRate)
        {
            Boolean isSuccess = false;
               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SingleRates.AddObject(singleRate);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_SingleRate singleRate)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SingleRates", singleRate);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, singleRate);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long singleRateId)
        {
            Boolean isSuccess = false;
               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var singleRateList = from SingleRate in _context.Biz_SingleRates
                                     where SingleRate.Id == singleRateId
                                     select SingleRate;

                foreach (Biz_SingleRate singleRate in singleRateList)
                {
                    _context.DeleteObject(singleRate);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_SingleRate ReadSingleRateById(long singleRateId)
        {
               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var singleRateList = from SingleRate in _context.Biz_SingleRates
                                     where SingleRate.Id == singleRateId
                                     select SingleRate;

                foreach (Biz_SingleRate singleRate in singleRateList)
                {
                    return singleRate;
                }
                return null;
            }
        }


        public List<Biz_SingleRate> ReadAllSingleRates()
        {
            List<Biz_SingleRate> singleRateList = null;

               using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                singleRateList =
                    (from SingleRate in _context.Biz_SingleRates
                     select SingleRate).ToList();
            }
            return singleRateList;
        }
        public Biz_SingleRate ReadSingleRateByCommissionId(long commissionId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var singleRateList = from SingleRate in _context.Biz_SingleRates
                                     where SingleRate.IdCommssion == commissionId && SingleRate.Status.Trim() == "A"
                                     select SingleRate;

                foreach (Biz_SingleRate singleRate in singleRateList)
                {
                    return singleRate;
                }
                return null;
            }
        }
    }
}
