using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System.Collections.Generic;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_PeriodData
    {// data sale target is using_________long?
        public Biz_Period ReadPeriodById(long? periodId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var periodList = from Period in _context.Biz_Periods where Period.Id == periodId select Period;
                foreach (Biz_Period period in periodList)
                {
                    return period;
                }
                return null;
            }
        }
        public List<Biz_Period> ReadAllPeriod()
        {
            List<Biz_Period> periodList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                periodList = (from Period in _context.Biz_Periods select Period).ToList();
            }
            return periodList;
        }
    }
}
