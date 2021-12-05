using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_StakeholderTypeSecurityGroupService
    {
        Biz_StakeholderTypeSecurityGroupData stakeholderTypeSecurityGroupData = new Biz_StakeholderTypeSecurityGroupData();


        public void AddStakeholderTypeSecurityGroup(Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup)
        {
            stakeholderTypeSecurityGroupData.Create(stakeholderTypeSecurityGroup);
        }

        public void RemoveStakeholderTypeSecurityGroup(long stakeholderTypeId)
        {
            stakeholderTypeSecurityGroupData.Delete(stakeholderTypeId);
        }

        public List<Biz_StakeholderTypeSecurityGroup> ReadAllSecurityGroupStakeholderTypesBySecirutyGroupId(long securityGroupId)
        {
            return stakeholderTypeSecurityGroupData.ReadAllSecurityGroupStakeholderTypesBySecirutyGroupId(securityGroupId);
        }
        public List<Biz_StakeholderTypeSecurityGroup> ReadMappedSecurityGroupStakeholderType(long securityGroupId)
        {
            return stakeholderTypeSecurityGroupData.ReadMappedSecurityGroupStakeholderType(securityGroupId);
        }

        public List<Biz_StakeholderType> ReadUnMappedSecurityGroupStakeholderType(long securityGroupId)
        {
            return stakeholderTypeSecurityGroupData.ReadUnMappedSecurityGroupStakeholderType(securityGroupId);
           

        }

       

    }
}
