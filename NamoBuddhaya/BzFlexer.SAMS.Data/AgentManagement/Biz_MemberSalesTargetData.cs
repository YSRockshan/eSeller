using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_MemberSalesTargetData
    {
        public Boolean Create(Biz_MemberSalesTarget memberSalesTarget)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_MemberSalesTargets.AddObject(memberSalesTarget);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_MemberSalesTarget memberSalesTarget)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_MemberSalesTargets", memberSalesTarget);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, memberSalesTarget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long memberSalesTargetId)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberSalesTargetList = from MemberSalesTarget in _context.Biz_MemberSalesTargets
                                            where MemberSalesTarget.Id == memberSalesTargetId
                                            select MemberSalesTarget;

                foreach (Biz_MemberSalesTarget memberSalesTarget in memberSalesTargetList)
                {
                    _context.DeleteObject(memberSalesTarget);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_MemberSalesTarget ReadMemberSalesTargetById(long memberSalesTargetId)
        {
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberSalesTargetList = from MemberSalesTarget in _context.Biz_MemberSalesTargets
                                            where MemberSalesTarget.Id == memberSalesTargetId
                                            select MemberSalesTarget;

                foreach (Biz_MemberSalesTarget memberSalesTarget in memberSalesTargetList)
                {
                    return memberSalesTarget;
                }
                return null;
            }
        }


        public List<Biz_MemberSalesTarget> ReadAllMemberSalesTargets()
        {
            List<Biz_MemberSalesTarget> memberSalesTargetList = null;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                memberSalesTargetList =
                    (from MemberSalesTarget in _context.Biz_MemberSalesTargets
                     select MemberSalesTarget).ToList();
            }
            return memberSalesTargetList;
        }

        public List<Biz_MemberSalesTarget> ReadMappedMemberSalesTarget(long branchId, long salesTargetId)
        {
            List<Biz_MemberSalesTarget> memberSalesTargets = new List<Biz_MemberSalesTarget>();
            List<Biz_MemberSalesTarget> memberSalesTargetList = new List<Biz_MemberSalesTarget>();
            memberSalesTargets = this.ReadAllMemberSalesTargets();
            memberSalesTargets =
                (from memberSalesTarget in memberSalesTargets
                 where memberSalesTarget.IdBranch == branchId && memberSalesTarget.IdSalesTarget == salesTargetId
                 select memberSalesTarget).ToList();
            foreach (Biz_MemberSalesTarget memberSalesTarget in memberSalesTargets)
            {
                memberSalesTarget.Biz_BranchSalesAgents = new Biz_BranchSelesAgentData().ReadBranchSelesAgentById(Convert.ToInt16(memberSalesTarget.IdSalesAgent));
                memberSalesTarget.Biz_BranchSalesAgents.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(memberSalesTarget.Biz_BranchSalesAgents.IdStakeholder);
                memberSalesTargetList.Add(memberSalesTarget);
            }
            return memberSalesTargetList;
        }
        public List<Biz_MemberSalesTarget> ReadMappedMemberSalesTarget(long branchId)
        {
            List<Biz_MemberSalesTarget> memberSalesTargets = new List<Biz_MemberSalesTarget>();
            List<Biz_MemberSalesTarget> memberSalesTargetList = new List<Biz_MemberSalesTarget>();
            memberSalesTargets = this.ReadAllMemberSalesTargets();
            memberSalesTargets =
                (from memberSalesTarget in memberSalesTargets
                 where memberSalesTarget.IdBranch == branchId 
                 select memberSalesTarget).ToList();
            foreach (Biz_MemberSalesTarget memberSalesTarget in memberSalesTargets)
            {
                memberSalesTarget.Biz_BranchSalesAgents = new Biz_BranchSelesAgentData().ReadBranchSelesAgentById(Convert.ToInt16(memberSalesTarget.IdSalesAgent));
                memberSalesTarget.Biz_BranchSalesAgents.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(memberSalesTarget.Biz_BranchSalesAgents.IdStakeholder);
                memberSalesTargetList.Add(memberSalesTarget);
            }
            return memberSalesTargetList;
        }

        public List<Biz_BranchSalesAgent> ReadUnMappedMemberSalesTarget(long branchId)
        {
            List<Biz_BranchSalesAgent> branchSalesAgent = new List<Biz_BranchSalesAgent>();
            branchSalesAgent = new Biz_BranchSelesAgentData().ReadAllBranchSelesAgents();
            branchSalesAgent =
                (from branchSalesAgents in branchSalesAgent where branchSalesAgents.IdBranch == branchId select branchSalesAgents)
                    .ToList();

            List<Biz_MemberSalesTarget> memberSalesTargets = new List<Biz_MemberSalesTarget>();
            memberSalesTargets = this.ReadMappedMemberSalesTarget(branchId);

            List<long> branchSalesRepId = new List<long>();
            branchSalesRepId = (from id in branchSalesAgent select id.Id).ToList();

            List<long> mappedSalesRepId = new List<long>();
            mappedSalesRepId = (from id in memberSalesTargets select id.IdSalesAgent).ToList();

            List<long> branchSalesRepUnMappedId = new List<long>();
            branchSalesRepUnMappedId = branchSalesRepId.Except(mappedSalesRepId).ToList();

            List<Biz_BranchSalesAgent> branchSalesAgentList = new List<Biz_BranchSalesAgent>();
            List<Biz_BranchSalesAgent> branchSalesAgentListNew = new List<Biz_BranchSalesAgent>();
            branchSalesAgentList = (from BrSalesAgent in new Biz_BranchSelesAgentData().ReadAllBranchSelesAgents()
                                  where branchSalesRepUnMappedId.Contains(BrSalesAgent.Id)
                                  select BrSalesAgent).ToList();
            foreach (Biz_BranchSalesAgent branchSalesAgents in branchSalesAgentList)
            {
                branchSalesAgents.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(branchSalesAgents.IdStakeholder);
                branchSalesAgentListNew.Add(branchSalesAgents);
            }
            return branchSalesAgentListNew;
        }

    }
}
