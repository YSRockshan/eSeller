using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_StakeholderBranchService
    {
        Biz_StakeholdersBranchData stakeholderBranchData = new Biz_StakeholdersBranchData();

       
        public Boolean AddStakeholderBranch(Biz_StakeholderBranch stakeholderBranch)
        {
            Boolean isSuccess = false;
            if (stakeholderBranch != null)
            {
                isSuccess = stakeholderBranchData.Add(stakeholderBranch);
            }
            return isSuccess;
        }

       
        public Boolean ModifyStakeholderBranch(Biz_StakeholderBranch stakeholderBranch)
        {
            Boolean isSuccess = false;
            if (stakeholderBranch != null)
            {
                isSuccess = stakeholderBranchData.Modify(stakeholderBranch);
            }
            return isSuccess;
        }

        public Boolean DeleteStakeholderBranch(long stakeholderBranchId)
        {
            Boolean isSuccess = false;
            if (stakeholderBranchId != 0)
            {
                isSuccess = stakeholderBranchData.Delete(stakeholderBranchId);
            }
            return isSuccess;
        }

        public Biz_StakeholderBranch ReadStakeholderBranchById(long stakeholderBranchId)
        {
            return stakeholderBranchData.ReadStakeholderBranchById(stakeholderBranchId);
        }

        public List<Biz_StakeholderBranch> ReadAllStakeholderBranchs()
        {
            return stakeholderBranchData.ReadAllStakeholderBranchs();
        }

        public void DeleteStakeholderByStakeholderAndBranch(long stakeholderId, long branchId)
        {
            stakeholderBranchData.DeleteStakeholderByStakeholderAndBranch(stakeholderId, branchId);

        }

    }
}
