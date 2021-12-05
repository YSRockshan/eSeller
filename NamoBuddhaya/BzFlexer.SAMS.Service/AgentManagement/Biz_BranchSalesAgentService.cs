using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.AgentManagement;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_BranchSalesAgentService
    {
        Biz_BranchSelesAgentData branchSelesAgentData = new Biz_BranchSelesAgentData();

        public Boolean CreateBranchSelesAgent(Biz_BranchSalesAgent branchSelesAgent)
        {
            Boolean isSuccess = false;
            if (branchSelesAgent != null)
            {
                isSuccess = branchSelesAgentData.Create(branchSelesAgent);
            }
            return isSuccess;
        }


        public Boolean UpdateBranchSelesAgent(Biz_BranchSalesAgent branchSelesAgent)
        {
            Boolean isSuccess = false;
            if (branchSelesAgent != null)
            {
                isSuccess = branchSelesAgentData.Update(branchSelesAgent);
            }
            return isSuccess;
        }
        
        public Boolean DeleteBranchSelesAgent(long branchSelesAgentId)
        {
            Boolean isSuccess = false;
            if (branchSelesAgentId != 0)
            {
                isSuccess = branchSelesAgentData.Delete(branchSelesAgentId);
            }
            return isSuccess;
        }

        public List<Biz_BranchSalesAgent> ReadAllBranchSelesAgents()
        {
            return branchSelesAgentData.ReadAllBranchSelesAgents();
        }

        public Biz_BranchSalesAgent ReadBranchSelesAgentById(long branchSelesAgentId)
        {
            return branchSelesAgentData.ReadBranchSelesAgentById(branchSelesAgentId);
        }

     
       
        public List<Biz_BranchSalesAgent> ReadSalesAgentByBranchId(long branchId)
        {
            return branchSelesAgentData.ReadSalesAgentByBranchId(branchId);
        }

        public List<Biz_Stakeholder> ReadAllSalesPerson()
        {
            return branchSelesAgentData.ReadAllSalesPerson();
        }




        //To be Changed
        Biz_EmployeeDetailData employeeDetailData = new Biz_EmployeeDetailData();
        public List<Biz_Stakeholder> ReadBranchSalesAgentsByBranchWise(long branchId)
        {
            return branchSelesAgentData.ReadBranchSalesAgentsByBranchWise(branchId);
        }

        public List<Biz_StakeholderTypeStakeholder> ReadAllSalesAgents()
        {
            return branchSelesAgentData.ReadAllSalesAgents();
        }

     
    }
}
