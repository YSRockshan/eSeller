using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_ScreenService
    {
        Biz_ScreenData screenData = new Biz_ScreenData();

        public void CreateScreen(Biz_Screen screen)
        {
            screenData.Create(screen);
        }

        public void UpdateScreen(Biz_Screen screen)
        {
            screenData.Update(screen);
        }

        public void DeleteScreen(long screenId)
        {
            screenData.Delete(screenId);
        }

        public Biz_Screen ReadScreenByScreenID(long screenId)
        {
            return screenData.ReadScreenByScreenID(screenId);
        }

        public List<Biz_Screen> ReadScreenByModuleCode(long moduleId)
        {
            return screenData.ReadScreenByModuleCode(moduleId);
        }

        public List<Biz_Screen> ReadScreenByModuleCodeAndProFile(long moduleId, string proFile)
        {
            return screenData.ReadScreenByModuleCodeAndProFile(moduleId, proFile);
        }

        public List<Biz_Screen> ReadAllScreen()
        {
            return screenData.ReadAllScreen();
        }

        public List<Biz_Screen> ReadAllScreenByModuleId(long moduleId)
        {
            return screenData.ReadAllScreenByModuleId(moduleId);
        }

    }
}
