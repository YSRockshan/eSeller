using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Security;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_SystemModulesData
    {
        public void Create(Biz_SystemModule systemModule)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SystemModules.AddObject(systemModule);
                _context.SaveChanges();
            }
        }

        public void Update(Biz_SystemModule systemModule)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SystemModules", systemModule);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, systemModule);
                }
                _context.SaveChanges();
            }

        }

        public void Delete(long systemModuleId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SystemModuleList = from SystemModule in _context.Biz_SystemModules
                                       where SystemModule.Id == systemModuleId
                                       select SystemModule;
                foreach (Biz_SystemModule systemModule in SystemModuleList)
                {
                    _context.DeleteObject(systemModule);
                }
                _context.SaveChanges();
            }
        }

        public Biz_SystemModule ReadSystemModuleById(long systemModuleId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SystemModuleList = from SystemModule in _context.Biz_SystemModules
                                       where SystemModule.Id == systemModuleId
                                       select SystemModule;
                foreach (Biz_SystemModule systemModule in SystemModuleList)
                {
                    return systemModule;
                }
                return null;
            }
        }

        public List<Biz_SystemModule> ReadAllSystemModule()
        {
            List<Biz_SystemModule> SystemModuleList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                SystemModuleList = (from SystemModule in _context.Biz_SystemModules select SystemModule).ToList();
            }
            return SystemModuleList;
        }


        public Biz_SystemModule ReadSystemModuleByCode(string systemModuleCode)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SystemModuleList = from SystemModule in _context.Biz_SystemModules
                                       where SystemModule.SystemModule_Code == systemModuleCode
                                       select SystemModule;
                foreach (Biz_SystemModule systemModule in SystemModuleList)
                {
                    return systemModule;
                }
                return null;
            }
        }
    }
}
