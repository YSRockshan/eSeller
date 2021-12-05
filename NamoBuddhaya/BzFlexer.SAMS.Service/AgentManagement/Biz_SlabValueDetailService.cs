using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SlabValueDetailService
    {
        Biz_SlabValueDetailsData _slabValueDetailData = new Biz_SlabValueDetailsData();

        public Boolean CreateSlabValueDetail(Biz_SlabValueDetail slabValueDetail)
        {
            Boolean isSuccess = false;
            if (slabValueDetail != null)
            {
                isSuccess = _slabValueDetailData.Create(slabValueDetail);
            }
            return isSuccess;
        }

        public Boolean UpdateSlabValueDetail(Biz_SlabValueDetail slabValueDetail)
        {
            Boolean isSuccess = false;
            if (slabValueDetail != null)
            {
                isSuccess = _slabValueDetailData.Update(slabValueDetail);
            }
            return isSuccess;
        }

        public Boolean DeleteSlabValueDetail(long slabValueDetailId)
        {
            Boolean isSuccess = false;
            if (slabValueDetailId != 0)
            {
                isSuccess = _slabValueDetailData.Delete(slabValueDetailId);
            }
            return isSuccess;
        }

        public Biz_SlabValueDetail ReadSlabValueDetailById(long slabValueDetailId)
        {
            return _slabValueDetailData.ReadSlabValueDetailById(slabValueDetailId);
        }

        public List<Biz_SlabValueDetail> ReadAllSlabValueDetails()
        {
            return _slabValueDetailData.ReadAllSlabValueDetails();
        }

    }
}
