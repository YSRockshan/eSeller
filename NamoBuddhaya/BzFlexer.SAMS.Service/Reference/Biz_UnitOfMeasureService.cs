using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_UnitOfMeasureService
    {
        Biz_UnitOfMeasureData _unitOfMeasureData = new Biz_UnitOfMeasureData();

        public void CreateUnitOfMeasure(Biz_UnitOfMeasure unitOfMeasure)
        {
            _unitOfMeasureData.Create(unitOfMeasure);
        }

        public void UpdateUnitOfMeasure(Biz_UnitOfMeasure unitOfMeasure)
        {
            _unitOfMeasureData.Update(unitOfMeasure);
        }

        public void DeleteUnitOfMeasures(long unitOfMeasureId)
        {
            _unitOfMeasureData.Delete(unitOfMeasureId);
        }

        public Biz_UnitOfMeasure ReadUnitOfMeasureById(long unitOfMeasureId)
        {
            return _unitOfMeasureData.ReadUnitOfMeasureById(unitOfMeasureId);
        }

        public List<Biz_UnitOfMeasure> ReadAllUnitOfMeasure()
        {
            return _unitOfMeasureData.ReadAllUnitOfMeasure();
        }

        public List<Biz_UnitOfMeasure> ReadUnitOfMeasureByUnitOfMeasureTypeId(long unitOfMeasureTypeId)
        {
            return _unitOfMeasureData.ReadUnitOfMeasureByUnitOfMeasureTypeId(unitOfMeasureTypeId);
        }

        public List<Biz_UnitOfMeasure> ReadUnitofMesureByUOMCodeAndType(long unitOfMeasureTypeId, string unitofMeasureCode)
        {
            return _unitOfMeasureData.ReadUnitofMesureByUOMCodeAndType(unitOfMeasureTypeId, unitofMeasureCode);
        }

    }
}
