using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_StakeholderSecurityGroupService
    {
        Biz_StakeholderSecurityGroupsData stakeholderSecurityGroupData = new Biz_StakeholderSecurityGroupsData();


        public void AddSecurityGroupStakeholder(Biz_StakeholderSecurityGroup stakeholderSecurityGroup)
        {
            stakeholderSecurityGroupData.Create(stakeholderSecurityGroup);
        }

        public void RemoveStakeholderSecurityGroup(long stakeholderId)
        {
            stakeholderSecurityGroupData.Delete(stakeholderId);
        }

        public List<Biz_StakeholderType> DataBindTodropDownListStakeholderTypes(long securityGroupId)
        {
            return stakeholderSecurityGroupData.DataBindTodropDownListStakeholderTypes(securityGroupId);
        }

        public List<Biz_Stakeholder> ReadUnMappedStakeholders(long securityGroupId, long stakeholderTypeId)
        {
            return stakeholderSecurityGroupData.ReadUnMappedStakeholders(securityGroupId, stakeholderTypeId);
        }

        public List<Biz_StakeholderSecurityGroup> ReadMappedStakeholders(long securityGroupId, long stakeholderTypeId)
        {
            return stakeholderSecurityGroupData.ReadMappedStakeholders(securityGroupId, stakeholderTypeId);
        }

       
    }
}
