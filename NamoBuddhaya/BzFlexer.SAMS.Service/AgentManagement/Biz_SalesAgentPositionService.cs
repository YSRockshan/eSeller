using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesAgentPositionService
    {
        Biz_SalesAgentPositionData salesAgentPositionData = new Biz_SalesAgentPositionData();

      
        public Boolean CreatesalesAgentPosition(Biz_SalesAgentPosition salesAgentPosition)
        {
            Boolean isSuccess = false;
            if (salesAgentPosition != null)
            {
                isSuccess = salesAgentPositionData.Create(salesAgentPosition);
            }
            return isSuccess;
        }

      
        public Boolean UpdatesalesAgentPosition(Biz_SalesAgentPosition salesAgentPosition)
        {
            Boolean isSuccess = false;
            if (salesAgentPosition != null)
            {
                isSuccess = salesAgentPositionData.Update(salesAgentPosition);
            }
            return isSuccess;
        }


        public Boolean DeleteSalesAgentPositions(long salesAgentPositionId)
        {
            Boolean isSuccess = false;
            if (salesAgentPositionId != 0)
            {
                isSuccess = salesAgentPositionData.Delete(salesAgentPositionId);
            }
            return isSuccess;
        }


        public Biz_SalesAgentPosition ReadSalesAgentPositionById(long salesAgentPositionId)
        {
            return salesAgentPositionData.ReadSalesAgentPositionById(salesAgentPositionId);
        }


        public List<Biz_SalesAgentPosition> ReadAllsalesAgentPositions()
        {
            return salesAgentPositionData.ReadAllsalesAgentPositions();
        }

        public List<Biz_SalesAgentPosition> ReadSalesAgentPositionByCode(string salesAgentPositionCode)
        {
            return salesAgentPositionData.ReadSalesAgentPositionByCode(salesAgentPositionCode);
        }
        
    }
}
