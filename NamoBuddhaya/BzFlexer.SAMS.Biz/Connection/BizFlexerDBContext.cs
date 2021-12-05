using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.Connection
{
   public class BizFlexerDBContext : ObjectContext
    {

        #region "Reference Module ObjectSet Variables"
        //For ObjectSet use
        private ObjectSet<Biz_Branch> _Branch;
        private ObjectSet<Biz_BranchProduct> _BranchProduct;
        private ObjectSet<Biz_Product> _Product;
        private ObjectSet<Biz_Currency> _Currency;
        private ObjectSet<Biz_Stakeholder> _Stakeholder;
        private ObjectSet<Biz_StakeholderType> _Stakeholdertype;
        private ObjectSet<Biz_InventoryItem> _inventoryItem;
        private ObjectSet<Biz_ProductCategory> _ProductCategory;
        private ObjectSet<Biz_Serial> _Serial;
        private ObjectSet<Biz_StakeholderBranch> _StakeholderBranche;
        private ObjectSet<Biz_SubProductCategory> _SubProductCategory;
        private ObjectSet<Biz_UnitOfMeasure> _UnitOfMeasure;
        private ObjectSet<Biz_UnitOfMeasureType> _UnitOfMeasureType;


        #endregion

        #region "Agent Management Module ObjectSet Variables"
        private ObjectSet<Biz_BranchPriceBook> _branchPriceBook;
        private ObjectSet<Biz_PriceBook> _priceBook;
        private ObjectSet<Biz_BranchSalesAgent> _branchSelesAgent;
        private ObjectSet<Biz_SlabValueDetail> _slabValueDetail;
        private ObjectSet<Biz_Slab> _slab;
        private ObjectSet<Biz_SlabDetail> _slabDetail;
        private ObjectSet<Biz_SingleRate> _singleRate;
        private ObjectSet<Biz_SalesTransaction> _salesTransaction;
        private ObjectSet<Biz_SalesTarget> _salesTarget;
        private ObjectSet<Biz_SalesBudget> _salesBudget;
        private ObjectSet<Biz_Period> _Period;
        private ObjectSet<Biz_SalesTargetDetail> _salesTargetDetail;
        private ObjectSet<Biz_SalesForecast> _SalesForecast;
        private ObjectSet<Biz_SalesForecastDetail> _SalesForecastDetail;
        private ObjectSet<Biz_SalesBudgetDetail> _SalesBudgetDetail;
        private ObjectSet<Biz_SalesAgent> _salesAgent;
        private ObjectSet<Biz_SalesAgentPosition> _salesAgentPosition;
        private ObjectSet<Biz_PriceBookDetail> _priceBookDetail;
        private ObjectSet<Biz_MultipleRate> _multipleRate;
        private ObjectSet<Biz_MemberSalesTarget> _memberSalesTarget;
        private ObjectSet<Biz_MemberSalesAgentPosition> _memberSalesAgentPosition;
        private ObjectSet<Biz_Commission> _commission;
        private ObjectSet<Biz_Invoice> _Invoice;
        private ObjectSet<Biz_MemberCommssionDetail> _memberCommssionDetail;

        #endregion


        #region "Security Module ObjectSet Variables"
        private ObjectSet<Biz_PasswordHistory> _PasswordHistory;
        private ObjectSet<Biz_Screen> _Screen;
        private ObjectSet<Biz_SecurityGroupScreen> _SecurityGroupScreen;
        private ObjectSet<Biz_StakeholderSecurityGroup> _StakeholderSecurityGroup;
        private ObjectSet<Biz_SecurityGroup> _SecurityGroup;
        private ObjectSet<Biz_StakeholderTypeSecurityGroup> _StakeholderTypeSecurityGroup;
        private ObjectSet<Biz_StakeholderTypeStakeholder> _stakeholderTypeStakeholder;
        private ObjectSet<Biz_SystemModule> _SystemModule;
        private ObjectSet<Biz_UserLog> _userLog;

        #endregion

        //Constructor
        public BizFlexerDBContext()
            : base("name=BizFlexerDBEntities", "BizFlexerDBEntities")
        {
            #region "General Module"
            _Currency = base.CreateObjectSet<Biz_Currency>("Biz_Currencies");
            _Branch = base.CreateObjectSet<Biz_Branch>("Biz_Branches");
            _Stakeholdertype = base.CreateObjectSet<Biz_StakeholderType>("Biz_StakeholderTypes");
            _Stakeholder = base.CreateObjectSet<Biz_Stakeholder>("Biz_Stakeholders");
            _ProductCategory = base.CreateObjectSet<Biz_ProductCategory>("Biz_ProductCategories");
            _SubProductCategory = base.CreateObjectSet<Biz_SubProductCategory>("Biz_SubProductCategories");
            _Product = base.CreateObjectSet<Biz_Product>("Biz_Products");
            _BranchProduct = base.CreateObjectSet<Biz_BranchProduct>("Biz_BranchProducts");
            
            _UnitOfMeasureType = base.CreateObjectSet<Biz_UnitOfMeasureType>("Biz_UnitOfMeasureTypes");
            _UnitOfMeasure = base.CreateObjectSet<Biz_UnitOfMeasure>("Biz_UnitOfMeasures");
            _stakeholderTypeStakeholder = CreateObjectSet<Biz_StakeholderTypeStakeholder>();
            _StakeholderBranche = CreateObjectSet<Biz_StakeholderBranch>();
            _inventoryItem = CreateObjectSet<Biz_InventoryItem>();
            _Serial = CreateObjectSet<Biz_Serial>();

            #endregion

            #region "Security Administration Module"

            _SecurityGroup = base.CreateObjectSet<Biz_SecurityGroup>("Biz_SecurityGroups");
            _SystemModule = base.CreateObjectSet<Biz_SystemModule>("Biz_SystemModules");
            _Screen = base.CreateObjectSet<Biz_Screen>("Biz_Screens");
            _SecurityGroupScreen = base.CreateObjectSet<Biz_SecurityGroupScreen>("Biz_SecurityGroupScreens");
            _StakeholderTypeSecurityGroup =
                base.CreateObjectSet<Biz_StakeholderTypeSecurityGroup>("Biz_StakeholderTypeSecurityGroups");
            _StakeholderSecurityGroup = base.CreateObjectSet<Biz_StakeholderSecurityGroup>("Biz_StakeholderSecurityGroups");
             _PasswordHistory = base.CreateObjectSet<Biz_PasswordHistory>("Biz_PasswordHistories");
            _userLog = CreateObjectSet<Biz_UserLog>();

            #endregion

            #region "Sales Agents Managements"

            _Period = base.CreateObjectSet<Biz_Period>("Biz_Periods");
            _SalesForecast = base.CreateObjectSet<Biz_SalesForecast>("Biz_SalesForecasts");
            _SalesForecastDetail = base.CreateObjectSet<Biz_SalesForecastDetail>("Biz_SalesForecastDetails");
            _salesBudget = CreateObjectSet<Biz_SalesBudget>();
            _SalesBudgetDetail = CreateObjectSet<Biz_SalesBudgetDetail>("Biz_SalesBudgetDetails");
            _salesTarget = CreateObjectSet<Biz_SalesTarget>();
            _salesTargetDetail = CreateObjectSet<Biz_SalesTargetDetail>();
            _priceBook = CreateObjectSet<Biz_PriceBook>();
            _priceBookDetail = CreateObjectSet<Biz_PriceBookDetail>();
            _branchPriceBook = CreateObjectSet<Biz_BranchPriceBook>();
            _salesAgentPosition = CreateObjectSet<Biz_SalesAgentPosition>();
            _salesAgent = CreateObjectSet<Biz_SalesAgent>();
            _branchSelesAgent = CreateObjectSet<Biz_BranchSalesAgent>();
            _Invoice = CreateObjectSet<Biz_Invoice>();
            _slab = CreateObjectSet<Biz_Slab>();
            _slabDetail = CreateObjectSet<Biz_SlabDetail>();
            _slabValueDetail = CreateObjectSet<Biz_SlabValueDetail>();
            _commission = CreateObjectSet<Biz_Commission>();
            _memberCommssionDetail = CreateObjectSet<Biz_MemberCommssionDetail>();
            _memberSalesAgentPosition = CreateObjectSet<Biz_MemberSalesAgentPosition>();
            _memberSalesTarget = CreateObjectSet<Biz_MemberSalesTarget>();
            _singleRate = CreateObjectSet<Biz_SingleRate>();
            _multipleRate = CreateObjectSet<Biz_MultipleRate>();
            _salesTransaction = CreateObjectSet<Biz_SalesTransaction>();

            #endregion


        }

        #region "Reference Module ObjectSet"
        //For Data layer access
        public ObjectSet<Biz_Branch> Biz_Branches
        {//_Branch ObjectSet variable
            get
            {
                if ((_Branch == null))
                {
                    _Branch = base.CreateObjectSet<Biz_Branch>("Biz_Branches");
                }
                return _Branch;
            }
        }
        public ObjectSet<Biz_BranchProduct> Biz_BranchProducts
        {
            get
            {
                if ((_BranchProduct == null))
                {
                    _BranchProduct = base.CreateObjectSet<Biz_BranchProduct>("Biz_BranchProducts");
                }
                return _BranchProduct;
            }
        }
        public ObjectSet<Biz_Product> Biz_Products
        {
            get
            {
                if ((_Product == null))
                {
                    _Product = base.CreateObjectSet<Biz_Product>("Biz_Products");
                }
                return _Product;
            }
        }
        public ObjectSet<Biz_Currency> Biz_Currencies
        {
            get
            {
                if ((_Currency == null))
                {
                    _Currency = base.CreateObjectSet<Biz_Currency>("Biz_Currencies");
                }
                return _Currency;
            }
        }
        public ObjectSet<Biz_Stakeholder> Biz_Stakeholders
        {
            get
            {
                if ((_Stakeholder == null))
                {
                    _Stakeholder = base.CreateObjectSet<Biz_Stakeholder>("Biz_Stakeholders");
                }
                return _Stakeholder;
            }
        }
        public ObjectSet<Biz_StakeholderType> Biz_StakeholderTypes
        {
            get
            {
                if ((_Stakeholdertype == null))
                {
                    _Stakeholdertype = base.CreateObjectSet<Biz_StakeholderType>("Biz_StakeholderTypes");
                }
                return _Stakeholdertype;
            }
        }
        public ObjectSet<Biz_InventoryItem> Biz_InventoryItems
        {
            get { return _inventoryItem ?? (_inventoryItem = CreateObjectSet<Biz_InventoryItem>()); }
        }
        public ObjectSet<Biz_ProductCategory> Biz_ProductCategories
        {
            get
            {
                if ((_ProductCategory == null))
                {
                    _ProductCategory = base.CreateObjectSet<Biz_ProductCategory>("Biz_ProductCategories");
                }
                return _ProductCategory;
            }
        }
        public ObjectSet<Biz_Serial> Biz_Serials
        {
            get { return _Serial ?? (_Serial = CreateObjectSet<Biz_Serial>()); }
        }
        public ObjectSet<Biz_StakeholderBranch> Biz_StakeholderBranches
        {
            get { return _StakeholderBranche ?? (_StakeholderBranche = CreateObjectSet<Biz_StakeholderBranch>()); }
        }
        public ObjectSet<Biz_SubProductCategory> Biz_SubProductCategories
        {
            get
            {
                if ((_SubProductCategory == null))
                {
                    _SubProductCategory = base.CreateObjectSet<Biz_SubProductCategory>("Biz_SubProductCategories");
                }
                return _SubProductCategory;
            }
        }
        public ObjectSet<Biz_UnitOfMeasure> Biz_UnitOfMeasures
        {
            get
            {
                if ((_UnitOfMeasure == null))
                {
                    _UnitOfMeasure = base.CreateObjectSet<Biz_UnitOfMeasure>("Biz_UnitOfMeasures");
                }
                return _UnitOfMeasure;
            }
        }
        public ObjectSet<Biz_UnitOfMeasureType> Biz_UnitOfMeasureTypes
        {
            get
            {
                if ((_UnitOfMeasureType == null))
                {
                    _UnitOfMeasureType = CreateObjectSet<Biz_UnitOfMeasureType>("Biz_UnitOfMeasureTypes");
                }
                return _UnitOfMeasureType;
            }
        }



        #endregion

        #region "Agent Management Module ObjectSet"
        public ObjectSet<Biz_BranchPriceBook> Biz_BranchPriceBooks
        {
            get { return _branchPriceBook ?? (_branchPriceBook = CreateObjectSet<Biz_BranchPriceBook>()); }
        }
        public ObjectSet<Biz_PriceBook> Biz_PriceBooks
        {
            get { return _priceBook ?? (_priceBook = CreateObjectSet<Biz_PriceBook>()); }
        }
        public ObjectSet<Biz_BranchSalesAgent> Biz_BranchSalesAgents
        {
            get { return _branchSelesAgent ?? (_branchSelesAgent = CreateObjectSet<Biz_BranchSalesAgent>()); }
        }
        public ObjectSet<Biz_SlabValueDetail> Biz_SlabValueDetails
        {
            get { return _slabValueDetail ?? (_slabValueDetail = CreateObjectSet<Biz_SlabValueDetail>()); }
        }
        public ObjectSet<Biz_Slab> Biz_Slabs
        {
            get { return _slab ?? (_slab = CreateObjectSet<Biz_Slab>()); }
        }
        public ObjectSet<Biz_SlabDetail> Biz_SlabDetails
        {
            get { return _slabDetail ?? (_slabDetail = CreateObjectSet<Biz_SlabDetail>()); }
        }
        public ObjectSet<Biz_SingleRate> Biz_SingleRates
        {
            get { return _singleRate ?? (_singleRate = CreateObjectSet<Biz_SingleRate>()); }
        }
        public ObjectSet<Biz_SalesTransaction> Biz_SalesTransactions
        {
            get { return _salesTransaction ?? (_salesTransaction = CreateObjectSet<Biz_SalesTransaction>()); }
        }
        public ObjectSet<Biz_SalesTarget> Biz_SalesTargets
        {
            get { return _salesTarget ?? (_salesTarget = CreateObjectSet<Biz_SalesTarget>()); }
        }
        public ObjectSet<Biz_SalesBudget> Biz_SalesBudgets
        {
            get { return _salesBudget ?? (_salesBudget = CreateObjectSet<Biz_SalesBudget>()); }
        }
        public ObjectSet<Biz_Period> Biz_Periods
        {
            get
            {
                if ((_Period == null))
                {
                    _Period = base.CreateObjectSet<Biz_Period>("Biz_Periods");
                }
                return _Period;
            }
        }
        public ObjectSet<Biz_SalesTargetDetail> Biz_SalesTargetDetails
        {
            get { return _salesTargetDetail ?? (_salesTargetDetail = CreateObjectSet<Biz_SalesTargetDetail>()); }
        }
        public ObjectSet<Biz_SalesForecast> Biz_SalesForecasts
        {
            get
            {
                if ((_SalesForecast == null))
                {
                    _SalesForecast = base.CreateObjectSet<Biz_SalesForecast>("Biz_SalesForecasts");
                }
                return _SalesForecast;
            }

        }
        public ObjectSet<Biz_SalesForecastDetail> Biz_SalesForecastDetails
        {
            get
            {
                if ((_SalesForecastDetail == null))
                {
                    _SalesForecastDetail = base.CreateObjectSet<Biz_SalesForecastDetail>("Biz_SalesForecastDetails");
                }
                return _SalesForecastDetail;
            }
        }
        public ObjectSet<Biz_SalesBudgetDetail> Biz_SalesBudgetDetails
        {
            get
            {
                if ((_SalesBudgetDetail == null))
                {
                    _SalesBudgetDetail = base.CreateObjectSet<Biz_SalesBudgetDetail>("Biz_SalesBudgetDetails");
                }
                return _SalesBudgetDetail;
            }
        }
        public ObjectSet<Biz_SalesAgent> Biz_SalesAgents
        {
            get { return _salesAgent ?? (_salesAgent = CreateObjectSet<Biz_SalesAgent>()); }
        }
        public ObjectSet<Biz_SalesAgentPosition> Biz_SalesAgentPositions
        {
            get { return _salesAgentPosition ?? (_salesAgentPosition = CreateObjectSet<Biz_SalesAgentPosition>()); }
        }
        public ObjectSet<Biz_PriceBookDetail> Biz_PriceBookDetails
        {
            get { return _priceBookDetail ?? (_priceBookDetail = CreateObjectSet<Biz_PriceBookDetail>()); }
        }
        public ObjectSet<Biz_MultipleRate> Biz_MultipleRates
        {
            get { return _multipleRate ?? (_multipleRate = CreateObjectSet<Biz_MultipleRate>()); }
        }
        public ObjectSet<Biz_MemberSalesTarget> Biz_MemberSalesTargets
        {
            get { return _memberSalesTarget ?? (_memberSalesTarget = CreateObjectSet<Biz_MemberSalesTarget>()); }
        }
        public ObjectSet<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPositions
        {
            get { return _memberSalesAgentPosition ?? (_memberSalesAgentPosition = CreateObjectSet<Biz_MemberSalesAgentPosition>()); }
        }
        public ObjectSet<Biz_Commission> Biz_Commissions
        {
            get { return _commission ?? (_commission = CreateObjectSet<Biz_Commission>()); }
        }
        public ObjectSet<Biz_Invoice> Biz_Invoices
        {
            get { return _Invoice ?? (_Invoice = CreateObjectSet<Biz_Invoice>()); }
        }
        public ObjectSet<Biz_MemberCommssionDetail> Biz_MemberCommssionDetails
        {
            get { return _memberCommssionDetail ?? (_memberCommssionDetail = CreateObjectSet<Biz_MemberCommssionDetail>()); }
        }


        #endregion

        #region "Security Module ObjectSet"
        public ObjectSet<Biz_PasswordHistory> Biz_PasswordHistories
        {
            get
            {
                if ((_PasswordHistory == null))
                {
                    _PasswordHistory = base.CreateObjectSet<Biz_PasswordHistory>("Biz_PasswordHistories");
                }
                return _PasswordHistory;
            }
        }
        public ObjectSet<Biz_Screen> Biz_Screens
        {
            get
            {
                if ((_Screen == null))
                {
                    _Screen = base.CreateObjectSet<Biz_Screen>("Biz_Screens");
                }
                return _Screen;
            }
        }
        public ObjectSet<Biz_SecurityGroupScreen> Biz_SecurityGroupScreens
        {
            get
            {
                if ((_SecurityGroupScreen == null))
                {
                    _SecurityGroupScreen = base.CreateObjectSet<Biz_SecurityGroupScreen>("Biz_SecurityGroupScreens");
                }
                return _SecurityGroupScreen;
            }
        }
        public ObjectSet<Biz_StakeholderSecurityGroup> Biz_StakeholderSecurityGroups
        {
            get
            {
                if ((_StakeholderSecurityGroup == null))
                {
                    _StakeholderSecurityGroup =
                        base.CreateObjectSet<Biz_StakeholderSecurityGroup>("Biz_StakeholderSecurityGroups");
                }
                return _StakeholderSecurityGroup;
            }
        }
        public ObjectSet<Biz_SecurityGroup> Biz_SecurityGroups
        {
            get
            {
                if ((_SecurityGroup == null))
                {
                    _SecurityGroup = base.CreateObjectSet<Biz_SecurityGroup>("Biz_SecurityGroups");
                }
                return _SecurityGroup;
            }
        }
        public ObjectSet<Biz_StakeholderTypeSecurityGroup> Biz_StakeholderTypeSecurityGroups
        {
            get
            {
                if ((_StakeholderTypeSecurityGroup == null))
                {
                    _StakeholderTypeSecurityGroup =
                        base.CreateObjectSet<Biz_StakeholderTypeSecurityGroup>("Biz_StakeholderTypeSecurityGroups");
                }
                return _StakeholderTypeSecurityGroup;
            }
        }
        public ObjectSet<Biz_StakeholderTypeStakeholder> Biz_StakeholderTypeStakeholders
        {
            get { return _stakeholderTypeStakeholder ?? (_stakeholderTypeStakeholder = CreateObjectSet<Biz_StakeholderTypeStakeholder>()); }
        }
        public ObjectSet<Biz_SystemModule> Biz_SystemModules
        {
            get
            {
                if ((_SystemModule == null))
                {
                    _SystemModule = base.CreateObjectSet<Biz_SystemModule>("Biz_SystemModules");
                }
                return _SystemModule;
            }
        }
        public ObjectSet<Biz_UserLog> Biz_UserLogs
        {
            get
            {
                if ((_userLog == null))
                {
                    _userLog = base.CreateObjectSet<Biz_UserLog>("Biz_UserLogs");
                }
                return _userLog;
            }
        }

        #endregion


    }
}