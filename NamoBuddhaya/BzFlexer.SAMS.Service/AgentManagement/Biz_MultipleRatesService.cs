using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_MultipleRatesService
    {
        Biz_MultipleRateData _multipleRateData = new Biz_MultipleRateData();


        public Boolean CreateMultipleRate(Biz_MultipleRate multipleRate)
        {
            Boolean isSuccess = false;
            if (multipleRate != null)
            {
                isSuccess = _multipleRateData.Create(multipleRate);
            }
            return isSuccess;
        }


        public Boolean UpdateMultipleRate(Biz_MultipleRate multipleRate)
        {
            Boolean isSuccess = false;
            if (multipleRate != null)
            {
                isSuccess = _multipleRateData.Update(multipleRate);
            }
            return isSuccess;
        }


        public Boolean DeleteMultipleRate(long multipleRateId)
        {
            Boolean isSuccess = false;
            if (multipleRateId != 0)
            {
                isSuccess = _multipleRateData.Delete(multipleRateId);
            }
            return isSuccess;
        }


        public Biz_MultipleRate ReadMultipleRateById(long multipleRateId)
        {
            return _multipleRateData.ReadMultipleRateById(multipleRateId);
        }


        public List<Biz_MultipleRate> ReadAllMultipleRates()
        {
            return _multipleRateData.ReadAllMultipleRates();
        }


        public Biz_MultipleRate ReadMultipleRateByCommssionId(long commissionId)
        {
            return _multipleRateData.ReadMultipleRateByCommssionId(commissionId);
        }

    }
}
