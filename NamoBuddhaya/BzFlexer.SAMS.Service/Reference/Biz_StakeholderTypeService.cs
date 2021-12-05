using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_StakeholderTypeService
    {
        Biz_StakeholderTypeData stakeholderTypeData = new Biz_StakeholderTypeData();

        public void CreateStakeholderType(Biz_StakeholderType stakeholderType)
        {
            if (stakeholderType != null)
            {
                stakeholderTypeData.Create(stakeholderType);
            }
        }

        public void UpdateStakeholderType(Biz_StakeholderType stakeholderType)
        {
            if (stakeholderType != null)
            {
                stakeholderTypeData.Update(stakeholderType);
            }
        }

        public void DeleteStakeholderTypes(long stakeholderTypeId)
        {
            if (stakeholderTypeId != 0)
            {
                stakeholderTypeData.Delete(stakeholderTypeId);
            }
        }

        public Biz_StakeholderType ReadStakeholderTypeById(long stakeholderTypeId)
        {
            return stakeholderTypeData.ReadStakeholderTypeById(stakeholderTypeId);
        }

        public List<Biz_StakeholderType> ReadAllStakeholderType()
        {
            return stakeholderTypeData.ReadAllStakeholderType();
        }

        public List<Biz_StakeholderType> ReadStakeholderTypeByCode(string stakeholderTypeCode)
        {
            return stakeholderTypeData.ReadStakeholderTypeByCode(stakeholderTypeCode);
        }

    }
}
