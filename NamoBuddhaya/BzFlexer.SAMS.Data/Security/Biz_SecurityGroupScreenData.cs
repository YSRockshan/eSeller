using System;
using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.Security
{
    public  class Biz_SecurityGroupScreenData
    {
       
        public void Create(Biz_SecurityGroupScreen securityGroupScreen)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SecurityGroupScreens.AddObject(securityGroupScreen);
                _context.SaveChanges();
            }
        }

        public void RemoveSecurityGroupScreens(long securityGroupScreenId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var securityGroupScreenList = (from SecurityGroupScreen in _context.Biz_SecurityGroupScreens
                                               where
                                                   SecurityGroupScreen.Id == securityGroupScreenId
                                               select SecurityGroupScreen).ToList();
                foreach (Biz_SecurityGroupScreen securityGroupScreen in securityGroupScreenList)
                {
                    _context.DeleteObject(securityGroupScreen);
                }
                _context.SaveChanges();
            }
        }

        public List<Biz_SecurityGroupScreen> ReadAccessibleScreenBySecurityGroupIdAndModuleId(long securityGroupId, long moduleId)
        {
            List<Biz_SecurityGroupScreen> securityGroupScreenList = null;
            List<Biz_SecurityGroupScreen> securityGroupScreens = new List<Biz_SecurityGroupScreen>();
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                securityGroupScreenList = (from SecurityGroupScreen in _context.Biz_SecurityGroupScreens
                                           where
                                               SecurityGroupScreen.IdSecurityGroup == securityGroupId &&
                                               SecurityGroupScreen.IdModule == moduleId
                                           select SecurityGroupScreen).ToList();
            }
            foreach (Biz_SecurityGroupScreen securityGroupScreen in securityGroupScreenList)
            {
                try
                {
                    securityGroupScreen.Biz_Screens = new Biz_ScreenData().ReadScreenByScreenID(securityGroupScreen.IdScreen);
                }
                catch (Exception)
                { }
                securityGroupScreens.Add(securityGroupScreen);
            }
            return securityGroupScreens;
        }

        public int CheckExistingScreens(long moduleId, long loginUserStakeholderId, string frmName, long branchId)
        {
            int resultsList = 0;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                //Get Security groups of the given stakeholder
                 List<long> secSholderGroups = (from sg in _context.Biz_StakeholderSecurityGroups
                                               where sg.IdStakeholder == loginUserStakeholderId && sg.IdStatus == 1
                                               select sg.IdSecurityGroup).ToList();

                //Get Screens for given moduleid, companyId, security groups

                List<long> screensBySecGroupCompanyModule =
                                            (from scr in _context.Biz_SecurityGroupScreens
                                             where secSholderGroups.Contains(scr.IdSecurityGroup)
                                             select scr.IdScreen).ToList();

                //Get Screen details for given screensId
                List<Biz_Screen> stakeholderScreens = (from scr in _context.Biz_Screens
                                                   where
                                                   scr.IdBizModule == moduleId &&
                                                   scr.ProgramFile_Name == frmName &&
                                                   screensBySecGroupCompanyModule.Contains(scr.Id)
                                                   orderby scr.Sequence_No
                                                   select scr).ToList();

                List<Biz_Screen> allScreens = stakeholderScreens;
                resultsList = allScreens.Count;
            }

            return resultsList;
        }
      

    }
}
