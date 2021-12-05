using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.Reference;
using System.Data;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_StakeholderTypeData
    {// Using Reference.Biz_EmployeeDetailData
        public Biz_StakeholderType ReadStakeholderTypesById(long stakeholderTypeId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _stakeholderTypeList = from Biz_StakeholderType in _context.Biz_StakeholderTypes where Biz_StakeholderType.Id == stakeholderTypeId select Biz_StakeholderType;
                foreach (Biz_StakeholderType stakeholderType in _stakeholderTypeList)
                {
                    return stakeholderType;
                }
                return null;
            }
        }
        public void Create(Biz_StakeholderType stakeholderType)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_StakeholderTypes.AddObject(stakeholderType);
                _context.SaveChanges();
            }
        }

        public void Update(Biz_StakeholderType stakeholderType)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_StakeholderTypes", stakeholderType);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, stakeholderType);
                }
                _context.SaveChanges();
            }
        }

        public void Delete(long stakeholderTypeId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeList = from StakeholderType in _context.Biz_StakeholderTypes where StakeholderType.Id == stakeholderTypeId select StakeholderType;

                foreach (Biz_StakeholderType stakeholderType in stakeholderTypeList)
                {
                    _context.DeleteObject(stakeholderType);
                }
                _context.SaveChanges();
            }
        }

        public Biz_StakeholderType ReadStakeholderTypeById(long stakeholderTypeId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeList = from StakeholderType in _context.Biz_StakeholderTypes where StakeholderType.Id == stakeholderTypeId select StakeholderType;
                foreach (Biz_StakeholderType stakeholderType in stakeholderTypeList)
                {
                    return stakeholderType;
                }
                return null;
            }
        }

        public List<Biz_StakeholderType> ReadAllStakeholderType()
        {
            List<Biz_StakeholderType> stakeholderTypeList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeList = (from StakeholderType in _context.Biz_StakeholderTypes select StakeholderType).ToList();
            }
            return stakeholderTypeList;
        }
        public List<Biz_StakeholderType> ReadStakeholderTypeByCode(string stakeholderTypeCode)
        {
            List<Biz_StakeholderType> stakeholderTypeList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeList = (from StakeholderType in _context.Biz_StakeholderTypes where StakeholderType.Code == stakeholderTypeCode select StakeholderType).ToList();
            }
            return stakeholderTypeList;
        }

    }
}
