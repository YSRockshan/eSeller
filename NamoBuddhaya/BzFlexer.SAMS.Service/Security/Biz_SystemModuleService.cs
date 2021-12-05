using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Security
{
    public class Biz_SystemModuleService
    {
        Biz_SystemModulesData systemModuleData = new Biz_SystemModulesData();

        public void CreateSystemModule(Biz_SystemModule systemModule)
        {
            if (systemModule != null)
            {
                systemModuleData.Create(systemModule);
            }
        }

        public void UpdateSystemModule(Biz_SystemModule systemModule)
        {
            systemModuleData.Update(systemModule);
        }

        public void DeleteSystemModule(long systemModuleId)
        {
            systemModuleData.Delete(systemModuleId);
        }

        public Biz_SystemModule ReadSystemModuleById(long systemModuleId)
        {
            return systemModuleData.ReadSystemModuleById(systemModuleId);
        }

        public List<Biz_SystemModule> ReadAllSystemModule()
        {
            return systemModuleData.ReadAllSystemModule();
        }

        public Biz_SystemModule ReadSystemModuleByCode(string systemModuleCode)
        {
            return systemModuleData.ReadSystemModuleByCode(systemModuleCode);
        }

    }
}
