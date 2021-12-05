using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_MemberSalesTargetService
    {
        Biz_MemberSalesTargetData memberSalesTargetData = new Biz_MemberSalesTargetData();

        
        public Boolean CreateMemberSalesTarget(Biz_MemberSalesTarget memberSalesTarget)
        {
            Boolean isSuccess = false;
            if (memberSalesTarget != null)
            {
                isSuccess = memberSalesTargetData.Create(memberSalesTarget);
            }
            return isSuccess;
        }

       
        public Boolean UpdateMemberSalesTarget(Biz_MemberSalesTarget memberSalesTarget)
        {
            Boolean isSuccess = false;
            if (memberSalesTarget != null)
            {
                isSuccess = memberSalesTargetData.Update(memberSalesTarget);
            }
            return isSuccess;
        }


        public Boolean DeleteMemberSalesTargets(long memberSalesTargetId)
        {
            Boolean isSuccess = false;
            if (memberSalesTargetId != 0)
            {
                isSuccess = memberSalesTargetData.Delete(memberSalesTargetId);
            }
            return isSuccess;
        }


        public Biz_MemberSalesTarget ReadMemberSalesTargetById(long memberSalesTargetId)
        {
            return memberSalesTargetData.ReadMemberSalesTargetById(memberSalesTargetId);
        }


        public List<Biz_MemberSalesTarget> ReadAllMemberSalesTargets()
        {
            return memberSalesTargetData.ReadAllMemberSalesTargets();
        }

        public List<Biz_MemberSalesTarget> ReadMappedMemberSalesTarget(long branchId)
        {
            return memberSalesTargetData.ReadMappedMemberSalesTarget(branchId);
        }

        public List<Biz_MemberSalesTarget> ReadMappedMemberSalesTarget(long branchId, long salesTargetId)
        {
            return memberSalesTargetData.ReadMappedMemberSalesTarget(branchId, salesTargetId);
        }

        public List<Biz_BranchSalesAgent> ReadUnMappedMemberSalesTarget(long branchId)
        {
            return memberSalesTargetData.ReadUnMappedMemberSalesTarget(branchId);
        }

    }
}
