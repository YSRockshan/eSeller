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
    public class Biz_BudgetSummeryService
    {
        public List<Biz_SalesBudgetDetail> ReadAllSalesBudgetDetail()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetails = new List<Biz_SalesBudgetDetail>();
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetails = new Biz_SalesBudgetDetailsService().ReadAllSalesBudgetDetail();
            foreach (Biz_SalesBudgetDetail salesBudgetDetail in salesBudgetDetails)
            {
                salesBudgetDetail.Biz_Products = new Biz_GeneralProductService().ReadProductById(salesBudgetDetail.IdProduct);
                salesBudgetDetail.Biz_Branches = new Biz_BranchService().ReadBranchById(Convert.ToInt16(salesBudgetDetail.IdBranch));
                salesBudgetDetail.Biz_UnitOfMeasures =
                    new Biz_UnitOfMeasureService().ReadUnitOfMeasureById(Convert.ToInt16(salesBudgetDetail.IdUnitOfMeasure));
                salesBudgetDetail.Biz_SalesBudgets = new Biz_SalesBudgetService().ReadSalesBudgetById(salesBudgetDetail.IdSalesBudget);
                salesBudgetDetailList.Add(salesBudgetDetail);
            }
            return salesBudgetDetailList;
        }
    }
}
