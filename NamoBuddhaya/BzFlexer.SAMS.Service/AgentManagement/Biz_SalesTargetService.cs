using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesTargetService
    {
        Biz_SalesTargetsData salesTargetsData = new Biz_SalesTargetsData();

       

        public Boolean CreateSalesTarget(Biz_SalesTarget salesTarget)
        {
            Boolean isSuccess = false;
            if (salesTarget != null)
            {
                isSuccess = salesTargetsData.Create(salesTarget);
            }
            return isSuccess;
        }


        public Boolean UpdateSalesTarget(Biz_SalesTarget salesTarget)
        {
            Boolean isSuccess = false;
            if (salesTarget != null)
            {
                isSuccess = salesTargetsData.Update(salesTarget);
            }
            return isSuccess;
        }

        public Boolean DeleteSalesTarget(long salesTargetId)
        {
            Boolean isSuccess = false;
            if (salesTargetId != 0)
            {
                isSuccess = salesTargetsData.Delete(salesTargetId);
            }
            return isSuccess;
        }

        public Biz_SalesTarget ReadSalesTargetById(long salesTargetId)
        {
            return salesTargetsData.ReadSalesTargetById(salesTargetId);
        }


        public List<Biz_SalesTarget> ReadAllSalesTargets()
        {
            return salesTargetsData.ReadAllSalesTargets();
        }

        public List<Biz_SalesTarget> ReadSalesTargetByCode(string salesTargetCode)
        {
            return salesTargetsData.ReadSalesTargetByCode(salesTargetCode);
        }

    }
}
