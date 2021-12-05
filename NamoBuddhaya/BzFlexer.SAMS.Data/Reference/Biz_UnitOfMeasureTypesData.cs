using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public class Biz_UnitOfMeasureTypesData
    {
        public void AddUnitOfMeasureType(Biz_UnitOfMeasureType unitOfMeasureType)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_UnitOfMeasureTypes.AddObject(unitOfMeasureType);
                _context.SaveChanges();
            }
        }

        
        public void ModifyUnitOfMeasureType(Biz_UnitOfMeasureType unitOfMeasureType)
        {
            EntityKey key = null;
            object original = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_UnitOfMeasureTypes", unitOfMeasureType);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, unitOfMeasureType);
                }
                _context.SaveChanges();
            }
        }

       public void DeleteUnitOfMeasureType(long unitOfMeasureTypeId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var unitOfMeasureTypeList = from UnitOfMeasureType in _context.Biz_UnitOfMeasureTypes
                                            where UnitOfMeasureType.Id == unitOfMeasureTypeId
                                            select UnitOfMeasureType;
                foreach (Biz_UnitOfMeasureType unitOfMeasureType in unitOfMeasureTypeList)
                {
                    _context.DeleteObject(unitOfMeasureType);
                }
                _context.SaveChanges();
            }
        }

       public Biz_UnitOfMeasureType ReadUnitOfMeasureTypeById(long unitOfMeasureTypeId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var unitOfMeasureTypeList = from UnitOfMeasureType in _context.Biz_UnitOfMeasureTypes
                                            where UnitOfMeasureType.Id == unitOfMeasureTypeId
                                            select UnitOfMeasureType;
                foreach (Biz_UnitOfMeasureType unitOfMeasureType in unitOfMeasureTypeList)
                {
                    return unitOfMeasureType;
                }
            }
            return null;
        }

       public List<Biz_UnitOfMeasureType> ReadAllUnitOfMeasureType()
        {
            List<Biz_UnitOfMeasureType> unitOfMeasureTypeList = null;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                unitOfMeasureTypeList = (from UnitOfMeasureType in _context.Biz_UnitOfMeasureTypes select UnitOfMeasureType).ToList();
            }
            return unitOfMeasureTypeList;
        }

    }
}
