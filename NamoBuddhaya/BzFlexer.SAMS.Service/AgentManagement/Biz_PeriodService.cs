using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_PeriodService
    {
        Biz_PeriodData periodData = new Biz_PeriodData();
        public List<Biz_Period> ReadAllPeriod()
        {
            return periodData.ReadAllPeriod();
        }

        public Biz_Period ReadPeriodById(long periodId)
        {
            return periodData.ReadPeriodById(periodId);
        }

    }
}
