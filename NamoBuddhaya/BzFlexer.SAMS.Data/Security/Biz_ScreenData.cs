using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Security;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_ScreenData
    {
        public void Create(Biz_Screen screen)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Screens.AddObject(screen);
                _context.SaveChanges();
            }
        }
        public void Update(Biz_Screen screen)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Screens", screen);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, screen);
                }
                _context.SaveChanges();
            }
        }
        public void Delete(long screenId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var screenList =
                      (from Screen in _context.Biz_Screens where Screen.Id == screenId select Screen).ToList();
                foreach (Biz_Screen screen in screenList)
                {
                    _context.DeleteObject(screen);
                }
                _context.SaveChanges();
            }
        }
        public Biz_Screen ReadScreenByScreenID(long screenId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var screenList =
                      (from Screen in _context.Biz_Screens where Screen.Id == screenId select Screen).ToList();
                foreach (Biz_Screen screen in screenList)
                {
                    return screen;
                }
                return null;
            }
        }
        public List<Biz_Screen> ReadScreenByModuleCode(long moduleId)
        {
            List<Biz_Screen> ScreenList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ScreenList =
                    (from Screen in _context.Biz_Screens where Screen.Id == moduleId select Screen).ToList();
            }
            return ScreenList;
        }
        public List<Biz_Screen> ReadScreenByModuleCodeAndProFile(long moduleId, string proFile)
        {
            List<Biz_Screen> screenList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                screenList =
                    (from Screen in _context.Biz_Screens where Screen.Id == moduleId && Screen.ProgramFile_Name == proFile select Screen).ToList();
            }
            return screenList;
        }
        public List<Biz_Screen> ReadAllScreen()
        {
            List<Biz_Screen> screenList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                screenList =
                    (from Screen in _context.Biz_Screens select Screen).ToList();
            }
            return screenList;
        }
        public List<Biz_Screen> ReadAllScreenByModuleId(long moduleId)
        {
            List<Biz_Screen> ScreenList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                ScreenList =
                    (from Screen in _context.Biz_Screens where Screen.IdBizModule == moduleId select Screen).ToList();
            }
            return ScreenList;
        }
        //used sec grp scrn service
        public List<Biz_Screen> ReadNavigationMenuByUserIdModuleIdAndCompanyId(long moduleId, long loginUserStakeholderId, long currentBranchId)
        {
            List<Biz_Screen> resultsList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                //Get Security groups of the given stakeholder

                List<long> secSholderGroups = (from sg in _context.Biz_StakeholderSecurityGroups
                                               where sg.IdStakeholder == loginUserStakeholderId && sg.IdStatus == 1
                                               select sg.IdSecurityGroup).ToList();

                List<long> screensBySecGroupCompanyModule =
                                           (from scr in _context.Biz_SecurityGroupScreens
                                            where secSholderGroups.Contains(scr.IdSecurityGroup)
                                            select scr.IdScreen).ToList();

                //Get Screen details for given screensId
                List<Biz_Screen> stakeholderScreens = (from scr in _context.Biz_Screens
                                                       where
                                                       scr.IdBizModule == moduleId &&
                                                       screensBySecGroupCompanyModule.Contains(scr.Id)
                                                       orderby scr.Sequence_No
                                                       select scr).ToList();

                List<Biz_Screen> menuScreens = (from scr in _context.Biz_Screens
                                                where scr.IdBizModule == moduleId && scr.ProgramFile_Name == null
                                                select scr).ToList();

                List<Biz_Screen> allScreens = (from s in menuScreens.Union(stakeholderScreens) orderby s.IdParentScreen, s.Sequence_No select s).ToList();
                resultsList = allScreens;
            }

            return resultsList;
        }
        public List<Biz_Screen> ReadUnmappedScreen(long securityGroupId, long moduleId)
        {
            List<Biz_SecurityGroupScreen> securityGroupScreenBySecurityGroupIdAndModuleId = new List<Biz_SecurityGroupScreen>();
            List<Biz_Screen> ScreenList = new List<Biz_Screen>();
            List<Biz_Screen> unMappedScreenList = new List<Biz_Screen>();

            securityGroupScreenBySecurityGroupIdAndModuleId =new Biz_SecurityGroupScreenData().ReadAccessibleScreenBySecurityGroupIdAndModuleId(securityGroupId, moduleId);
            ScreenList = this.ReadAllScreenByModuleId(moduleId);
            unMappedScreenList = (from screen in ScreenList
                                  where
                                      !(from securityGroupScreen in securityGroupScreenBySecurityGroupIdAndModuleId
                                        select securityGroupScreen.IdScreen).Contains(screen.Id)
                                  select screen).ToList();

            return unMappedScreenList;
        }
    }
}
