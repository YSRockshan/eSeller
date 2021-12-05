using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SlabDetailService
    {
        Biz_SlabDetailsData slabDetailData = new Biz_SlabDetailsData();


        public Boolean CreateSlabDetail(Biz_SlabDetail slabDetail)
        {
            Boolean isSuccess = false;
            if (slabDetail != null)
            {
                isSuccess = slabDetailData.Create(slabDetail);
            }
            return isSuccess;
        }


        public Boolean UpdateSlabDetail(Biz_SlabDetail slabDetail)
        {
            Boolean isSuccess = false;
            if (slabDetail != null)
            {
                isSuccess = slabDetailData.Update(slabDetail);
            }
            return isSuccess;
        }

        public Boolean DeleteSlabDetail(long slabDetailId)
        {
            Boolean isSuccess = false;
            if (slabDetailId != 0)
            {
                isSuccess = slabDetailData.Delete(slabDetailId);
            }
            return isSuccess;
        }

        public Boolean DeleteSlabDetailBySlabId(long slabId)
        {
            Boolean isSuccess = false;
            if (slabId != 0)
            {
                isSuccess = slabDetailData.DeleteSlabDetailBySlabId(slabId);
            }
            return isSuccess;
        }

        public Biz_SlabDetail ReadSlabDetailById(long slabDetailId)
        {
            return slabDetailData.ReadSlabDetailById(slabDetailId);
        }

        public List<Biz_SlabDetail> ReadAllSlabDetails()
        {
            return slabDetailData.ReadAllSlabDetails();
        }

        public List<Biz_SlabDetail> ReadSlabDetailBySlabId(long slabId)
        {
            return slabDetailData.ReadSlabDetailBySlabId(slabId);
        }

    }
}
