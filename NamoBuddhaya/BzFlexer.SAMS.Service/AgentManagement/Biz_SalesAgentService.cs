using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesAgentService
    {
        Biz_SalesAgentData _salesAgentData = new Biz_SalesAgentData();

        public Boolean CreateSalesRep(Biz_SalesAgent salesRep)
        {
            Boolean isSuccess = false;
            if (salesRep != null)
            {
                isSuccess = _salesAgentData.Create(salesRep);
            }
            return isSuccess;
        }

       
        public Boolean UpdateSalesAgent(Biz_SalesAgent salesRep)
        {
            Boolean isSuccess = false;
            if (salesRep != null)
            {
                isSuccess = _salesAgentData.Update(salesRep);
            }
            return isSuccess;
        }


        public Boolean DeleteSalesAgent(long salesRepId)
        {
            Boolean isSuccess = false;
            if (salesRepId != 0)
            {
                isSuccess = _salesAgentData.Delete(salesRepId);
            }
            return isSuccess;
        }


        public Biz_SalesAgent ReadSalesAgentById(long salesRepId)
        {
            return _salesAgentData.ReadSalesAgentById(salesRepId);
        }


        public List<Biz_SalesAgent> ReadAllSalesAgents()
        {
            return _salesAgentData.ReadAllSalesAgents();
        }

    }
}
