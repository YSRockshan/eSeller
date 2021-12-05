using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_UnitOfMeasureTypeService
    {
        Biz_UnitOfMeasureTypesData unitOfMeasureTypeData = new Biz_UnitOfMeasureTypesData();

        public void AddUnitOfMeasureType(Biz_UnitOfMeasureType unitOfMeasureType)
        {
            unitOfMeasureTypeData.AddUnitOfMeasureType(unitOfMeasureType);
        }

        public void ModifyUnitOfMeasureType(Biz_UnitOfMeasureType unitOfMeasureType)
        {
            unitOfMeasureTypeData.ModifyUnitOfMeasureType(unitOfMeasureType);
        }

        public void DeleteUnitOfMeasureType(long unitOfMeasureTypeId)
        {
            unitOfMeasureTypeData.DeleteUnitOfMeasureType(unitOfMeasureTypeId);
        }

        public Biz_UnitOfMeasureType ReadUnitOfMeasureTypeById(long unitOfMeasureTypeId)
        {
            return unitOfMeasureTypeData.ReadUnitOfMeasureTypeById(unitOfMeasureTypeId);
        }

        public List<Biz_UnitOfMeasureType> ReadAllUnitOfMeasureType()
        {
            return unitOfMeasureTypeData.ReadAllUnitOfMeasureType();
        }

    }
}
