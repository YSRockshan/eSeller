using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_StakeholderTypeStakeholderService
    {
        Biz_StakeholderTypesStakeholderData stakeholderTypeStakeholderData = new Biz_StakeholderTypesStakeholderData();


        public Boolean CreateStakeholderTypeStakeholder(Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder)
        {
            Boolean isSuccess = false;
            if (stakeholderTypeStakeholder != null)
            {
                isSuccess = stakeholderTypeStakeholderData.Create(stakeholderTypeStakeholder);
            }
            return isSuccess;
        }


        public Boolean ModifyStakeholderTypeStakeholder(Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder)
        {
            Boolean isSuccess = false;
            if (stakeholderTypeStakeholder != null)
            {
                isSuccess = stakeholderTypeStakeholderData.Update(stakeholderTypeStakeholder);
            }
            return isSuccess;
        }


        public Boolean DeleteStakeholderTypeStakeholder(long stakeholderTypeStakeholderId)
        {
            Boolean isSuccess = false;
            if (stakeholderTypeStakeholderId != 0)
            {
                isSuccess = stakeholderTypeStakeholderData.Delete(stakeholderTypeStakeholderId);
            }
            return isSuccess;
        }


        public Biz_StakeholderTypeStakeholder ReadStakeholderTypeStakeholderById(long stakeholderTypeStakeholderId)
        {
            return stakeholderTypeStakeholderData.ReadStakeholderTypeStakeholderById(stakeholderTypeStakeholderId);
        }


        public List<Biz_StakeholderTypeStakeholder> ReadAllStakeholderTypeStakeholders()
        {
            return stakeholderTypeStakeholderData.ReadAllStakeholderTypeStakeholders();
        }

        public List<Biz_StakeholderTypeStakeholder> ReadMappedStakeholderTypeStakeholder(long stakeholderTypeId)
        {
            return stakeholderTypeStakeholderData.ReadMappedStakeholderTypeStakeholder(stakeholderTypeId);
        }

        public List<Biz_Stakeholder> ReadUnmappedStakeholderByStakeholderTypetId(long stakeholderTypeId)
        {
            return stakeholderTypeStakeholderData.ReadUnmappedStakeholderByStakeholderTypetId(stakeholderTypeId);
        }

        public Biz_StakeholderTypeStakeholder ReadStakeholderTypeStakeholderByIdAndStkType(long stakeholderId, long stakeholderTypeId)
        {
            return stakeholderTypeStakeholderData.ReadStakeholderTypeStakeholderByIdAndStkType(stakeholderId, stakeholderTypeId);
        }

    }
}
