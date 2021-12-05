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
    public class Biz_SalesBudgetDetailsService
    {
        Biz_SalesBudgetDetailData _salesBudgetDetailData = new Biz_SalesBudgetDetailData();

        public void CreateSalesBudgetDetail(Biz_SalesBudgetDetail salesBudgetDetail)
        {
            _salesBudgetDetailData.Create(salesBudgetDetail);
        }

        public void UpdateSalesBudgetDetail(Biz_SalesBudgetDetail salesBudgetDetail)
        {
            _salesBudgetDetailData.Update(salesBudgetDetail);
        }

        public void DeleteSalesBudgetDetails(long salesBudgetDetailId)
        {
            _salesBudgetDetailData.Delete(salesBudgetDetailId);
        }

        public Biz_SalesBudgetDetail ReadSalesBudgetDetailbyId(long salesBudgetDetailId)
        {
            return _salesBudgetDetailData.ReadSalesBudgetDetailbyId(salesBudgetDetailId);
        }

        public List<Biz_SalesBudgetDetail> ReadAllSalesBudgetDetail()
        {
            return _salesBudgetDetailData.ReadAllSalesBudgetDetail();
        }

        public List<Biz_SalesBudgetDetail> ReadSalesBudgetDetailbyBranchBudget(long branchId, long salesBudgetId)
        {
            return _salesBudgetDetailData.ReadSalesBudgetDetailbyBranchBudget(branchId, salesBudgetId);
        }

        public List<Biz_Product> ReadUnmappedProductBybranchIdsalesBudgetId(long branchId, long salesBudgetId)
        {
            return _salesBudgetDetailData.ReadUnmappedProductBybranchIdsalesBudgetId(branchId, salesBudgetId);
        }

    }
}
