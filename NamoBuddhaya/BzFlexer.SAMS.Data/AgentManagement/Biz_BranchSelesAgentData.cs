using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_BranchSelesAgentData
    {
        public Boolean Create(Biz_BranchSalesAgent branchSelesAgent)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_BranchSalesAgents.AddObject(branchSelesAgent);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_BranchSalesAgent branchSelesAgent)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_BranchSalesAgents", branchSelesAgent);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, branchSelesAgent);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long branchSelesAgentId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var branchSelesAgentList = from Biz_BranchSelesAgent in _context.Biz_BranchSalesAgents
                                           where Biz_BranchSelesAgent.Id == branchSelesAgentId
                                         select Biz_BranchSelesAgent;

                foreach (Biz_BranchSalesAgent branchSelesAgent in branchSelesAgentList)
                {
                    _context.DeleteObject(branchSelesAgent);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public List<Biz_Stakeholder> ReadAllSalesPerson()
        {
            List<Biz_BranchSalesAgent> branchSelesAgents = new List<Biz_BranchSalesAgent>();
            branchSelesAgents = this.ReadAllBranchSelesAgents();

            List<long> branchSalesAgentSHId = new List<long>();
            branchSalesAgentSHId = (from id in branchSelesAgents select id.IdStakeholder).ToList();

            List<Biz_Stakeholder> branchStakeholder = new List<Biz_Stakeholder>();
            branchStakeholder = (from stakeholder in new Biz_EmployeeDetailData().ReadAllEmplyeeDetail()
                                 where branchSalesAgentSHId.Contains(stakeholder.Id)
                                 select stakeholder).ToList();

            return branchStakeholder;
        }

        public Biz_BranchSalesAgent ReadBranchSelesAgentById(long branchSelesAgentId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var branchSelesAgentList = from Biz_BranchSelesAgent in _context.Biz_BranchSalesAgents
                                         where Biz_BranchSelesAgent.Id == branchSelesAgentId
                                         select Biz_BranchSelesAgent;

                foreach (Biz_BranchSalesAgent branchSelesAgent in branchSelesAgentList)
                {
                    return branchSelesAgent;
                }
                return null;
            }
        }

        public List<Biz_BranchSalesAgent> ReadAllBranchSelesAgents()
        {
            List<Biz_BranchSalesAgent> branchSelesAgentList = null;
            List<Biz_BranchSalesAgent> branchSelesAgents = new List<Biz_BranchSalesAgent>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                branchSelesAgentList =
                    (from Biz_BranchSelesAgent in _context.Biz_BranchSalesAgents
                     select Biz_BranchSelesAgent).ToList();
                foreach (Biz_BranchSalesAgent branchSelesAgent in branchSelesAgentList)
                {
                    branchSelesAgent.Biz_Stakeholders =
                        new Biz_EmployeeDetailData().ReadEmployeeDetailsById(branchSelesAgent.Id);
                    branchSelesAgents.Add(branchSelesAgent);
                }
            }
            return branchSelesAgents;
        }

        public List<Biz_BranchSalesAgent> ReadSalesAgentByBranchId(long branchId)
        {
            List<Biz_BranchSalesAgent> branchSelesRepList = null;
            List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {

                branchSelesRepList = (from BranchSelesRep in _context.Biz_BranchSalesAgents
                                      where BranchSelesRep.IdBranch == branchId
                                      select BranchSelesRep).ToList();

                foreach (Biz_BranchSalesAgent branchSelesRep in branchSelesRepList)
                {
                    branchSelesRep.Biz_Stakeholders =
                        new Biz_EmployeeDetailData().ReadEmployeeDetailById(Convert.ToInt16(branchSelesRep.IdStakeholder));
                    branchSelesRep.Biz_Branches = new Biz_BranchesData().ReadBranchById(branchSelesRep.IdBranch);
                    branchSelesReps.Add(branchSelesRep);
                }
                return branchSelesReps;
            }
        }

        public List<Biz_Stakeholder> ReadBranchSalesAgentsByBranchWise(long branchId)
        {
            List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();
            branchSelesReps = this.ReadSalesAgentByBranchId(branchId);

            List<long> branchSalesRepId = new List<long>();
            branchSalesRepId = new List<long>(from id in branchSelesReps select id.IdStakeholder).ToList();

            List<Biz_Stakeholder> branchStakeholder = new List<Biz_Stakeholder>();
            branchStakeholder = (from stakeholder in new Biz_EmployeeDetailData().ReadAllEmplyeeDetail()
                                 where branchSalesRepId.Contains(stakeholder.Id)
                                 select stakeholder).ToList();

            return branchStakeholder;
        }

        public List<Biz_StakeholderTypeStakeholder> ReadAllSalesAgents()
        {
            //List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();
            //branchSelesReps = this.ReadAllBranchSelesAgents();

            //List<long> branchSalesAgentShId = new List<long>();
            //branchSalesAgentShId = (from id in branchSelesReps select id.IdStakeholder).ToList();

            //List<Biz_Stakeholder> branchStakeholder = new List<Biz_Stakeholder>();
            //branchStakeholder = (from stakeholder in new Biz_EmployeeDetailData().ReadAllEmplyeeDetail()
            //                     where branchSalesAgentShId.Contains(stakeholder.Id)
            //                     select stakeholder).ToList();

            //return branchStakeholder;
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();

            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderList = null;
            stakeholderTypeStakeholderList = new Biz_StakeholderTypesStakeholderData().ReadAllStakeholderTypeStakeholders();

            List<Biz_StakeholderType> stakeholderTypes = new List<Biz_StakeholderType>();
            stakeholderTypes = new Biz_StakeholderTypeData().ReadStakeholderTypeByCode("SRP");

            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderLists = new List<Biz_StakeholderTypeStakeholder>();
            stakeholderTypeStakeholderLists = (from stakeholderTypeStakeholder in stakeholderTypeStakeholderList
                                               where (from
                                                          stakeholderType
                                                          in
                                                          stakeholderTypes
                                                      select stakeholderType.Id).Contains(
                                                          stakeholderTypeStakeholder.IdStakeholderType)
                                               select stakeholderTypeStakeholder).ToList();

            foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholderLists)
            {
                stakeholderTypeStakeholder.Biz_Stakeholders =
                    new Biz_EmployeeDetailData().ReadEmployeeDetailById(stakeholderTypeStakeholder.IdStakeholder);
                stakeholderTypeStakeholder.Biz_StakeholderTypes =
                    new Biz_StakeholderTypeData().ReadStakeholderTypeById(stakeholderTypeStakeholder.IdStakeholderType);
                stakeholderTypeStakeholder.Biz_Stakeholders.Biz_Branches = new Biz_BranchesData().ReadBranchById(stakeholderTypeStakeholder.Biz_Stakeholders.IdCurrentBranch);
                stakeholderTypeStakeholders.Add(stakeholderTypeStakeholder);
            }
            return stakeholderTypeStakeholders;
        }

    }
}
