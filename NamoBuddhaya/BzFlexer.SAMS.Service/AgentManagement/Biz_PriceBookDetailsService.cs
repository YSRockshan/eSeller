using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_PriceBookDetailsService
    {
        Biz_PriceBookDetailsData priceBookDetailData = new Biz_PriceBookDetailsData();

        public Boolean CreatePriceBookDetail(Biz_PriceBookDetail priceBookDetail)
        {
            Boolean isSuccess = false;
            if (priceBookDetail != null)
            {
                isSuccess = priceBookDetailData.Create(priceBookDetail);
            }
            return isSuccess;
        }

        public Boolean UpdatePriceBookDetail(Biz_PriceBookDetail priceBookDetail)
        {
            Boolean isSuccess = false;
            if (priceBookDetail != null)
            {
                isSuccess = priceBookDetailData.Update(priceBookDetail);
            }
            return isSuccess;
        }

        public Boolean DeletePriceBookDetail(long priceBookDetailId)
        {
            Boolean isSuccess = false;
            if (priceBookDetailId != 0)
            {
                isSuccess = priceBookDetailData.Delete(priceBookDetailId);
            }
            return isSuccess;
        }

        public Biz_PriceBookDetail ReadPriceBookDetailById(long priceBookDetailId)
        {
            return priceBookDetailData.ReadPriceBookDetailById(priceBookDetailId);
        }

       public List<Biz_PriceBookDetail> ReadAllPriceBookDetails()
        {
            return priceBookDetailData.ReadAllPriceBookDetails();
        }

    }
}
