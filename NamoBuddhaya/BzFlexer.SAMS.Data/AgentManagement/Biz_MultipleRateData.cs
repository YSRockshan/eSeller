using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public class Biz_MultipleRateData
    {
        public Boolean Create(Biz_MultipleRate multipleRate)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_MultipleRates.AddObject(multipleRate);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

      public Boolean Update(Biz_MultipleRate multipleRate)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_MultipleRates", multipleRate);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, multipleRate);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long multipleRateId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var multipleRateList = from MultipleRate in _context.Biz_MultipleRates
                                       where MultipleRate.Id == multipleRateId
                                       select MultipleRate;

                foreach (Biz_MultipleRate multipleRate in multipleRateList)
                {
                    _context.DeleteObject(multipleRate);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

         public Biz_MultipleRate ReadMultipleRateById(long multipleRateId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var multipleRateList = from MultipleRate in _context.Biz_MultipleRates
                                       where MultipleRate.Id == multipleRateId
                                       select MultipleRate;

                foreach (Biz_MultipleRate multipleRate in multipleRateList)
                {
                    return multipleRate;
                }
                return null;
            }
        }

        public List<Biz_MultipleRate> ReadAllMultipleRates()
        {
            List<Biz_MultipleRate> multipleRateList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                multipleRateList =
                    (from MultipleRate in _context.Biz_MultipleRates
                     select MultipleRate).ToList();
            }
            return multipleRateList;
        }
        public Biz_MultipleRate ReadMultipleRateByCommssionId(long commissionId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var multipleRateList = from MultipleRate in _context.Biz_MultipleRates
                                       where MultipleRate.IdCommission == commissionId && MultipleRate.Status == "A"
                                       select MultipleRate;

                foreach (Biz_MultipleRate multipleRate in multipleRateList)
                {
                    return multipleRate;
                }
                return null;
            }
        }
    }
}
