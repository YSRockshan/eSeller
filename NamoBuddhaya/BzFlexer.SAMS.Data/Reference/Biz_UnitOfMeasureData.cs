using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_UnitOfMeasureData
    {
        public void Create(Biz_UnitOfMeasure unitOfMeasure)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_UnitOfMeasures.AddObject(unitOfMeasure);
                _context.SaveChanges();
            }
        }


        public void Update(Biz_UnitOfMeasure unitOfMeasure)
        {
            EntityKey key = null;
            object original = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_UnitOfMeasures", unitOfMeasure);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, unitOfMeasure);
                }
                _context.SaveChanges();
            }
        }


        public void Delete(long unitOfMeasureId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var UnitOfMeasureList = from UnitOfMeasure in _context.Biz_UnitOfMeasures
                                        where UnitOfMeasure.Id == unitOfMeasureId
                                        select UnitOfMeasure;
                foreach (Biz_UnitOfMeasure unitOfMeasure in UnitOfMeasureList)
                {
                    _context.Biz_UnitOfMeasures.DeleteObject(unitOfMeasure);
                }
                _context.SaveChanges();
            }
        }


        public Biz_UnitOfMeasure ReadUnitOfMeasureById(long unitOfMeasureId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var UnitOfMeasureList = from UnitOfMeasure in _context.Biz_UnitOfMeasures
                                        where UnitOfMeasure.Id == unitOfMeasureId
                                        select UnitOfMeasure;
                foreach (Biz_UnitOfMeasure unitOfMeasure in UnitOfMeasureList)
                {
                    return unitOfMeasure;
                }
                return null;
            }
        }


        public List<Biz_UnitOfMeasure> ReadAllUnitOfMeasure()
        {
            List<Biz_UnitOfMeasure> unitOfMeasureList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                unitOfMeasureList = (from UnitOfMeasure in _context.Biz_UnitOfMeasures select UnitOfMeasure).ToList();
            }
            return unitOfMeasureList;
        }

        public List<Biz_UnitOfMeasure> ReadUnitOfMeasureByUnitOfMeasureTypeId(long unitOfMeasureTypeId)
        {
            List<Biz_UnitOfMeasure> UnitOfMeasureList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                UnitOfMeasureList = (from UnitOfMeasure in _context.Biz_UnitOfMeasures
                                     where UnitOfMeasure.IdUnitOfMeasureType == unitOfMeasureTypeId
                                     select UnitOfMeasure).ToList();
            }
            return UnitOfMeasureList;
        }

        public List<Biz_UnitOfMeasure> ReadUnitofMesureByUOMCodeAndType(long unitOfMeasureTypeId, string unitofMeasureCode)
        {
            List<Biz_UnitOfMeasure> UnitOfMeasureList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                UnitOfMeasureList = (from UnitOfMeasure in _context.Biz_UnitOfMeasures
                                     where UnitOfMeasure.Id == unitOfMeasureTypeId && UnitOfMeasure.Code == unitofMeasureCode
                                     select UnitOfMeasure).ToList();
            }
            return UnitOfMeasureList;
        }


    }
}
