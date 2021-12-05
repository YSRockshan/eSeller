using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_SecurityGroupService
    {
        Biz_SecurityGroupData securityGroupData = new Biz_SecurityGroupData();

        public void CreateSecurityGroup(Biz_SecurityGroup securityGroup)
        {
            securityGroupData.Create(securityGroup);
        }

        public void UpdateSecurityGroup(Biz_SecurityGroup securityGroup)
        {
            securityGroupData.Update(securityGroup);
        }

        public void DeleteSecurityGroup(long securityGroupId)
        {
            securityGroupData.Delete(securityGroupId);
        }

        public Biz_SecurityGroup ReadSecurityGroupById(long securityGroupId)
        {
            return securityGroupData.ReadSecurityGroupById(securityGroupId);
        }

        public List<Biz_SecurityGroup> ReadAllSecurityGroup()
        {
            return securityGroupData.ReadAllSecurityGroup();
        }

        public List<Biz_SecurityGroup> ReadSecurityGroupByCode(string securityGroupCode)
        {
            return securityGroupData.ReadSecurityGroupByCode(securityGroupCode);
        }

    }
}
