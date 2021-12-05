using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_SecurityGroupScreenService
    {
        Biz_SecurityGroupScreenData securityGroupScreenData = new Biz_SecurityGroupScreenData();

        public void CreateSecurityGroupScreen(Biz_SecurityGroupScreen securityGroupScreen)
        {
            securityGroupScreenData.Create(securityGroupScreen);
        }
        public void RemoveSecurityGroupScreens(long securityGroupScreenId)
        {
            securityGroupScreenData.RemoveSecurityGroupScreens(securityGroupScreenId);
        }

        public List<Biz_SecurityGroupScreen> ReadAccessibleScreenBySecurityGroupIdAndModuleId(long securityGroupId, long moduleId)
        {
            return securityGroupScreenData.ReadAccessibleScreenBySecurityGroupIdAndModuleId(securityGroupId, moduleId);
        }
        public int CheckExistingScreens(long moduleId, long loginUserStakeholderId, string frmName, long branchId)
        {
            return securityGroupScreenData.CheckExistingScreens(moduleId, loginUserStakeholderId, frmName, branchId);
        }


        //to be changed
        Biz_ScreenData Biz_ScreenData = new Biz_ScreenData();
        public List<Biz_Screen> ReadNavigationMenu(long moduleId, long loginUserStakeholderId, long currentBranchId)
        {
            return Biz_ScreenData.ReadNavigationMenuByUserIdModuleIdAndCompanyId(moduleId, loginUserStakeholderId, currentBranchId);
        }
        public List<Biz_Screen> ReadUnmappedScreen(long securityGroupId, long moduleId)
        {
            return Biz_ScreenData.ReadUnmappedScreen(securityGroupId,  moduleId);
        }

      
        

      

    }
}
