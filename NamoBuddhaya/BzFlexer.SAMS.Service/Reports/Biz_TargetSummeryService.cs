using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reports
{
   public class Biz_TargetSummeryService
    {
        public List<Biz_SalesTargetDetail> ReadAllSalesTargetDetail()
        {
            List<Biz_SalesTargetDetail> salesTargetDetails = new List<Biz_SalesTargetDetail>();
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetails = new Biz_SalesTargetDetailsService().ReadAllSalesTargetDetails();
            foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetails)
            {
                salesTargetDetail.Biz_InventoryItems = new Biz_InventoryItemService().ReadInventoryItemById(salesTargetDetail.IdInventoryItem);
                salesTargetDetail.Biz_Branches = new Biz_BranchService().ReadBranchById(Convert.ToInt16(salesTargetDetail.IdBranch));
                salesTargetDetail.Biz_UnitOfMeasures =
                    new Biz_UnitOfMeasureService().ReadUnitOfMeasureById(Convert.ToInt16(salesTargetDetail.Id));
                salesTargetDetail.Biz_SalesTargets = new Biz_SalesTargetService().ReadSalesTargetById(salesTargetDetail.IdSalesTarget);
                salesTargetDetailList.Add(salesTargetDetail);
            }
            return salesTargetDetailList;
        }
    }
}
