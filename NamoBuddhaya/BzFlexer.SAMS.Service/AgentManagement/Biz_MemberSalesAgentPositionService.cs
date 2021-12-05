using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_MemberSalesAgentPositionService
    {
        Biz_MemberSalesAgentPositionsData _memberSalesAgentPositionData = new Biz_MemberSalesAgentPositionsData();

        

        public Boolean CreateMemberSalesAgentPosition(Biz_MemberSalesAgentPosition memberSalesAgentPosition)
        {
            Boolean isSuccess = false;
            if (memberSalesAgentPosition != null)
            {
                isSuccess = _memberSalesAgentPositionData.Create(memberSalesAgentPosition);
            }
            return isSuccess;
        }


        public Boolean ModifyMemberSalesAgentPosition(Biz_MemberSalesAgentPosition memberSalesAgentPosition)
        {
            Boolean isSuccess = false;
            if (memberSalesAgentPosition != null)
            {
                isSuccess = _memberSalesAgentPositionData.Update(memberSalesAgentPosition);
            }
            return isSuccess;
        }


        public Boolean DeleteMemberSalesAgentPosition(long memberSalesAgentPositionId)
        {
            Boolean isSuccess = false;
            if (memberSalesAgentPositionId != 0)
            {
                isSuccess = _memberSalesAgentPositionData.Delete(memberSalesAgentPositionId);
            }
            return isSuccess;
        }


        public Biz_MemberSalesAgentPosition GetMemberSalesAgentPositionById(long memberSalesAgentPositionId)
        {
            return _memberSalesAgentPositionData.GetMemberSalesAgentPositionById(memberSalesAgentPositionId);
        }


        public List<Biz_MemberSalesAgentPosition> GetAllMemberSalesAgentPositions()
        {
            return _memberSalesAgentPositionData.GetAllMemberSalesAgentPositions();
        }

        public List<Biz_BranchSalesAgent> UnMappedSalesAgents(long branchId)
        {
            return _memberSalesAgentPositionData.UnMappedSalesAgents(branchId);
        }

        public List<Biz_BranchSalesAgent> UnMappedSalesAgents(long branchId, long SalesAgentPositionId)
        {
            return _memberSalesAgentPositionData.UnMappedSalesAgents(branchId, SalesAgentPositionId);
        }

        public List<Biz_MemberSalesAgentPosition> MappedSalesAgents(long branchId, long SalesAgentPositionId)
        {
            return _memberSalesAgentPositionData.MappedSalesAgents(branchId, SalesAgentPositionId);
        }

    }
}
