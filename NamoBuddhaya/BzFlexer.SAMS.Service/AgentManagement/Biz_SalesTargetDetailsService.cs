using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesTargetDetailsService
    {
        Biz_SalesTargetDetailsData salesTargetDetailData = new Biz_SalesTargetDetailsData();

       
        public Boolean CreateSalesTargetDetail(Biz_SalesTargetDetail salesTargetDetail)
        {
            Boolean isSuccess = false;
            if (salesTargetDetail != null)
            {
                isSuccess = salesTargetDetailData.Create(salesTargetDetail);
            }
            return isSuccess;
        }

       
        public Boolean UpdateSalesTargetDetail(Biz_SalesTargetDetail salesTargetDetail)
        {
            Boolean isSuccess = false;
            if (salesTargetDetail != null)
            {
                isSuccess = salesTargetDetailData.Update(salesTargetDetail);
            }
            return isSuccess;
        }


        public Boolean DeleteSalesTargetDetails(long salesTargetDetailId)
        {
            Boolean isSuccess = false;
            if (salesTargetDetailId != 0)
            {
                isSuccess = salesTargetDetailData.Delete(salesTargetDetailId);
            }
            return isSuccess;
        }


        public Biz_SalesTargetDetail ReadSalesTargetDetailById(long salesTargetDetailId)
        {
            return salesTargetDetailData.ReadSalesTargetDetailById(salesTargetDetailId);
        }


        public List<Biz_SalesTargetDetail> ReadAllSalesTargetDetails()
        {
            return salesTargetDetailData.ReadAllSalesTargetDetails();
        }

        public List<Biz_InventoryItem> ReadUnmappedItemBybranchIdsalesTargetIdAndProductId(long branchId, long salesTargetId, long productId)
        {
            return salesTargetDetailData.ReadUnmappedItemBybranchIdsalesTargetIdAndProductId(branchId, salesTargetId, productId);
        }

        public List<Biz_SalesTargetDetail> ReadSalesTargetByBranchAndTarget(long branchId, long salesTargetId)
        {
            return salesTargetDetailData.ReadSalesTargetByBranchAndTarget(branchId, salesTargetId);
        }

        public List<Biz_Product> ReadProductsByBranch(long branchId)
        {
            return salesTargetDetailData.ReadProductsByBranch(branchId);
        }

        public Biz_SalesTargetDetail ReadSalesTargetDetailByItem(long itemId)
        {
            return salesTargetDetailData.ReadSalesTargetDetailByItem(itemId);
        }

    }
}
