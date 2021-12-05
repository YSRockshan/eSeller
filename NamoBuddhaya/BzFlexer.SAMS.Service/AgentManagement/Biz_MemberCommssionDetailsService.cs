using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_MemberCommssionDetailsService
    {
        Biz_MemberCommssionDetailsData _memberCommssionDetailData = new Biz_MemberCommssionDetailsData();

       
        public Boolean CreateMemberCommssionDetail(Biz_MemberCommssionDetail memberCommssionDetail)
        {
            Boolean isSuccess = false;
            if (memberCommssionDetail != null)
            {
                isSuccess = _memberCommssionDetailData.Create(memberCommssionDetail);
            }
            return isSuccess;
        }

       
        public Boolean UpdateMemberCommssionDetail(Biz_MemberCommssionDetail memberCommssionDetail)
        {
            Boolean isSuccess = false;
            if (memberCommssionDetail != null)
            {
                isSuccess = _memberCommssionDetailData.Update(memberCommssionDetail);
            }
            return isSuccess;
        }


        public Boolean DeleteMemberCommssionDetail(long memberCommssionDetailId)
        {
            Boolean isSuccess = false;
            if (memberCommssionDetailId != 0)
            {
                isSuccess = _memberCommssionDetailData.Delete(memberCommssionDetailId);
            }
            return isSuccess;
        }


        public Biz_MemberCommssionDetail ReadMemberCommssionDetailById(long memberCommssionDetailId)
        {
            return _memberCommssionDetailData.ReadMemberCommssionDetailById(memberCommssionDetailId);
        }


        public List<Biz_MemberCommssionDetail> ReadAllMemberCommssionDetails()
        {
            return _memberCommssionDetailData.ReadAllMemberCommssionDetails();
        }

        public List<Biz_Invoice> ReadInvoiceList(long productCategoryId, long subProductCatId, long productId)
        {
            return _memberCommssionDetailData.ReadInvoiceList(productCategoryId, subProductCatId, productId);
        }

    }
}
