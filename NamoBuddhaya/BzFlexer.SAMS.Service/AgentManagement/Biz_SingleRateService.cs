using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SingleRateService
    {
        Biz_SingleRatesData singleRateData = new Biz_SingleRatesData();


        public Boolean CreateSingleRate(Biz_SingleRate singleRate)
        {
            Boolean isSuccess = false;
            if (singleRate != null)
            {
                isSuccess = singleRateData.Create(singleRate);
            }
            return isSuccess;
        }


        public Boolean UpdateSingleRate(Biz_SingleRate singleRate)
        {
            Boolean isSuccess = false;
            if (singleRate != null)
            {
                isSuccess = singleRateData.Update(singleRate);
            }
            return isSuccess;
        }


        public Boolean DeleteRate(long singleRateId)
        {
            Boolean isSuccess = false;
            if (singleRateId != 0)
            {
                isSuccess = singleRateData.Delete(singleRateId);
            }
            return isSuccess;
        }


        public Biz_SingleRate ReadSingleRateById(long singleRateId)
        {
            return singleRateData.ReadSingleRateById(singleRateId);
        }


        public List<Biz_SingleRate> ReadAllSingleRates()
        {
            return singleRateData.ReadAllSingleRates();
        }

        public Biz_SingleRate ReadSingleRateByCommissionId(long commissionId)
        {
            return singleRateData.ReadSingleRateByCommissionId(commissionId);
        }

    }
}
