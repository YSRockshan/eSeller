using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_CommissionsService
    {
        Biz_CommissionsData _commissionData = new Biz_CommissionsData();

          public Boolean CreateCommission(Biz_Commission commission)
        {
            Boolean isSuccess = false;
            if (commission != null)
            {
                isSuccess = _commissionData.Create(commission);
            }
            return isSuccess;
        }

      public Boolean UpdateCommission(Biz_Commission commission)
        {
            Boolean isSuccess = false;
            if (commission != null)
            {
                isSuccess = _commissionData.Update(commission);
            }
            return isSuccess;
        }

        public Boolean DeleteCommissions(long commissionId)
        {
            Boolean isSuccess = false;
            if (commissionId != 0)
            {
                isSuccess = _commissionData.Delete(commissionId);
            }
            return isSuccess;
        }

        public Biz_Commission ReadCommissionById(long commissionId)
        {
            return _commissionData.ReadCommissionById(commissionId);
        }

        public List<Biz_Commission> ReadAllCommissions()
        {
            return _commissionData.ReadAllCommissions();
        }

       public List<Biz_Commission> ReadCommissionByCode(string commissionCode)
        {
            return _commissionData.ReadCommissionByCode(commissionCode);
        }

    }
}
