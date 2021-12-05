using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_SalesBudgetService
    {
        Biz_SalesBudgetsData _salesBudgetData = new Biz_SalesBudgetsData();

        public Boolean CreateSalesBudget(Biz_SalesBudget salesBudget)
        {
            Boolean isSuccess = false;
            if (salesBudget != null)
            {
                isSuccess = _salesBudgetData.Create(salesBudget);
            }
            return isSuccess;
        }


        public Boolean UpdateSalesBudget(Biz_SalesBudget salesBudget)
        {
            Boolean isSuccess = false;
            if (salesBudget != null)
            {
                isSuccess = _salesBudgetData.Update(salesBudget);
            }
            return isSuccess;
        }


        public Boolean DeleteSalesBudgets(long salesBudgetId)
        {
            Boolean isSuccess = false;
            if (salesBudgetId != 0)
            {
                isSuccess = _salesBudgetData.Delete(salesBudgetId);
            }
            return isSuccess;
        }

        public Biz_SalesBudget ReadSalesBudgetById(long salesBudgetId)
        {
            return _salesBudgetData.ReadSalesBudgetById(salesBudgetId);
        }


        public List<Biz_SalesBudget> ReadAllSalesBudgets()
        {
            return _salesBudgetData.ReadAllSalesBudgets();

        }


        public List<Biz_SalesBudget> ReadSalesBudgetByCode(string salesBudgetCode)
        {
            return _salesBudgetData.ReadSalesBudgetByCode(salesBudgetCode);
        }

    }
}
