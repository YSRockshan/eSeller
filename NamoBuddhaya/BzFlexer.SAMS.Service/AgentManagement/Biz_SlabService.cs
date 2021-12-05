using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SlabService
    {
        Biz_SlabsData _slabData = new Biz_SlabsData();

        public Boolean CreateSlab(Biz_Slab slab)
        {
            Boolean isSuccess = false;
            if (slab != null)
            {
                isSuccess = _slabData.Create(slab);
            }
            return isSuccess;
        }

        public Boolean UpdateSlab(Biz_Slab slab)
        {
            Boolean isSuccess = false;
            if (slab != null)
            {
                isSuccess = _slabData.Update(slab);
            }
            return isSuccess;
        }

        public Boolean DeleteSlab(long slabId)
        {
            Boolean isSuccess = false;
            if (slabId != 0)
            {
                isSuccess = _slabData.Delete(slabId);
            }
            return isSuccess;
        }

        public Biz_Slab ReadSlabById(long slabId)
        {
            return _slabData.ReadSlabById(slabId);
        }

        public List<Biz_Slab> ReadAllSlabs()
        {
            return _slabData.ReadAllSlabs();
        }

        public List<Biz_Slab> ReadSlabByCode(string slabCode)
        {
            return _slabData.ReadSlabByCode(slabCode);
        }

    }
}
